using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    [ServiceContract]
    public interface IWaiter
    {
        [OperationContract]
        void PlaceOrder(string sessionID, FoodOrder order);
        [OperationContract]
        List<RejectedOrder> GetReturnedOrders(string sessionID);
    }
}
