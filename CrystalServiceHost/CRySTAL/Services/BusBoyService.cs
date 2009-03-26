using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class BusBoyService : IBusBoyService
    {
        #region IBusBoyService Members

        public List<FoodOrder> getAllFoodOrders(string sessionID)
        {
            throw new NotImplementedException();
        }

        public List<FoodOrder> getNewFoodOrders(string sessionID)
        {
            throw new NotImplementedException();
        }

        public void MarkOrder(int orderNumber, FoodOrder.OrderStatusList status)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
