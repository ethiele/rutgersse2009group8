using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WaiterService : IWaiterService
    {
        #region IWaiter Members

        public void PlaceOrder(string sessionID, FoodOrder order)
        {
            throw new NotImplementedException();
        }

        public List<RejectedOrder> GetReturnedOrders(string sessionID)
        {
            throw new NotImplementedException();
        }

        public List<int> GetCurrentTables()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
