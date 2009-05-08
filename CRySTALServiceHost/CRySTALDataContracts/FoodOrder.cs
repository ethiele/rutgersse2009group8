// --------------------------------
// <copyright file="FoodOrder.cs" company="Rutgers Software Engineering (Group 8)">
//     The MIT License
// The MIT License
// Copyright (c) 2009 Edward Thiele (ethiele.com)
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights 
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
// </copyright>
// <author>Edward Thiele (EJ Thiele)</author>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using CRySTALDataConnections.CRySTALDataSetTableAdapters;

namespace CRySTAL
{
    [Serializable]
    [DataContract]
    public class FoodOrder
    {
        public enum OrderStatusList
        {
            sentToCook,
            readyToDeliver,
            outForDelevering,
            returned,
            orderServed,
            orderCanceled
        }

        [DataMember]
        public int orderNumber;
        [DataMember]
        public int DeliverToTable;
        [DataMember]
        public List<ItemOrder> FoodOrders;
        [DataMember]
        public string OrderComment;
        [DataMember]
        public OrderStatusList orderStatus;

        public void InsertToDatabase()
        {
            FoodOrdersTableAdapter fot = new FoodOrdersTableAdapter();
            if (OrderComment == null) OrderComment = "";
            orderNumber = (int)((decimal)(fot.InsertAndReturnIdentity(DeliverToTable, OrderComment, (int)orderStatus)));
            foreach (ItemOrder ios in FoodOrders)
            {
                ios.InsertToDatabase(orderNumber);
            }
        }

        public void UpdateOrderstatusInDB()
        {
            FoodOrdersTableAdapter foa = new FoodOrdersTableAdapter();
            foa.UpdateOrderStatus((int)orderStatus, orderNumber);
        }

        public void LoadFromDatabase(int orderNum)
        {
            FoodOrdersTableAdapter foa = new FoodOrdersTableAdapter();
            var row = foa.GetDataByOrderNumber(orderNum).First();
            DeliverToTable = row.DeliverToTable;
            orderNumber = row.OrderNumber;
            OrderComment = row.OrderCommet;
            orderStatus = (OrderStatusList)row.OrderStatus;
            ItemOrdersTableAdapter ita = new ItemOrdersTableAdapter();
            var itemOrders = ita.GetDataByOrderID(orderNum);
            FoodOrders = new List<ItemOrder>();
            
            foreach (var item in itemOrders)
            {
                ItemOrder io = new ItemOrder();
                io.LoadFromDataRow(item);
                FoodOrders.Add(io);
            }
        }
    }

    [Serializable]
    [DataContract]
    public class ItemOrder
    {
        [DataMember]
        public int productID;
        [DataMember]
        public int DeliverToPerson;
        [DataMember]
        public List<string> OrderMods;
        [DataMember]
        public string OrderComment;
        public void InsertToDatabase(int orderID)
        {
            ItemOrdersTableAdapter ioa = new ItemOrdersTableAdapter();
            if (OrderComment == null) OrderComment = "";
            int id = (int)((decimal)(ioa.InsertAndReturnIdentity(productID, DeliverToPerson, OrderComment, orderID)));
            OrderModsTableAdapter oma = new OrderModsTableAdapter();
            if (OrderMods != null)
            {
                foreach (string mod in OrderMods)
                {
                    oma.Insert(id, mod);
                }
            }
        }

        public void LoadFromDataRow(CRySTALDataConnections.CRySTALDataSet.ItemOrdersRow row)
        {
            productID = row.ProductID;
            DeliverToPerson = row.DeliverToPerson;
            OrderComment = row.OrderComment;
            OrderModsTableAdapter oma = new OrderModsTableAdapter();
            OrderMods = new List<string>();
            var mods = oma.GetDataByItemID(row.ID);
            foreach (var mod in mods)
            {
                OrderMods.Add(mod.OrderMod);
            }
        }
    }
}
