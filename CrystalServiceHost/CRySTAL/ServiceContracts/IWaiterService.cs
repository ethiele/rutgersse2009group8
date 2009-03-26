using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    [ServiceContract]
    public interface IWaiterService
    {
        [OperationContract]
        void PlaceOrder(string sessionID, FoodOrder order);
        [OperationContract]
        void AddItemToBill(string sessionID, FoodOrder order);
        [OperationContract]
        List<RejectedOrder> GetReturnedOrders(string sessionID);
        [OperationContract]
        List<int> GetCurrentTables(string sessionID);
        [OperationContract]
        List<int> GetInPaymentTables(string sessionID);
        [OperationContract]
        void MarkPaied(string sessionID, int tblNumber);
        [OperationContract]
        List<BillItem> GetReceipt(string sessionID, int tblNumber);

    }
}
