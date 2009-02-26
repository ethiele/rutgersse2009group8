using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CRySTAL
{
    [DataContract]
    public class FoodOrder
    {
        public enum OrderStatusList
        {
            sentToCook,
            readyToDelever,
            outForDelevering,
            returned,
            orderServed
        }

        [DataMember]
        public int orderNumber;
        [DataMember]
        public int DeleverToTable;
        [DataMember]
        public List<ItemOrder> FoodOrders;
        [DataMember]
        public string OrderComment;
        [DataMember]
        public OrderStatusList orderStatus;
    }

    [DataContract]
    public class ItemOrder
    {
        [DataMember]
        public int productID;
        [DataMember]
        public int DeleverToPerson;
        [DataMember]
        public List<string> OrderMods;
        [DataMember]
        public string OrderComment;
    }
}
