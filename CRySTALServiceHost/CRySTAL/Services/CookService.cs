// --------------------------------
// <copyright file="CookService.cs" company="Rutgers Software Engineering (Group 8)">
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
using System.ServiceModel;
using CRySTALDataConnections.CRySTALDataSetTableAdapters;

namespace CRySTAL
{
    /// <summary>
    /// Provides an implementation of the ICookService 
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CookService :ICookService
    {

        #region ICookService Members
        /// <summary>
        /// Returns all non-completed food orders
        /// </summary>
        /// <param name="sessionID">The ID for this logged in session</param>
        /// <returns></returns>
        public List<FoodOrder> GetAllFoodOrders(string sessionID)
        {
            List<FoodOrder> re = new List<FoodOrder>();
            
            FoodOrdersTableAdapter foa = new FoodOrdersTableAdapter();
            var orders = foa.GetDataByStatus((int)CRySTAL.FoodOrder.OrderStatusList.sentToCook);
            foreach (var order in orders)
            {
                FoodOrder fo = new FoodOrder();
                fo.LoadFromDatabase(order.OrderNumber);
                re.Add(fo);
            }
            return re;
            //catch (Exception e)
            //{
            //    CRySTALerror err = new CRySTALerror();
            //    err.errorMessage = e.ToString();
            //    err.ErrorType = CRySTALerror.ErrorTypes.sessionError;
            //    err.sessionID = sessionID;
            //    throw new FaultException<CRySTALerror>(err);
            //}
        }

        /// <summary>
        /// Returns all food orders since the last time this function was called in
        /// this session
        /// </summary>
        /// <param name="sessionID">The ID for this logged in session</param>
        /// <returns></returns>
        /// <remarks>Not Currently Implemented</remarks>
        public List<FoodOrder> GetNewFoodOrders(string sessionID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Marks the order as complete and has it sent out for delievery
        /// </summary>
        /// <param name="orderID">The ID of the order</param>
        public void MarkOrderAsComplete(int orderID)
        {
            FoodOrdersTableAdapter fta = new FoodOrdersTableAdapter();
            fta.UpdateOrderStatus((int)CRySTAL.FoodOrder.OrderStatusList.readyToDeliver, orderID);
            fta.UpdateEndTime(orderID);
        }

        /// <summary>
        /// Marks the order as unable to complete, a reason must be provided
        /// </summary>
        /// <param name="orderID">The ID of the order</param>
        /// <param name="reason">A string sent to the waiter explaing why an order cannot be compleated</param>
        public void RejectOrder(int orderID, string reason)
        {
            FoodOrdersTableAdapter fta = new FoodOrdersTableAdapter();
            fta.UpdateOrderStatus((int)CRySTAL.FoodOrder.OrderStatusList.orderCanceled, orderID);
            fta.UpdateEndTime(orderID);
        }

        #endregion
    }
}
