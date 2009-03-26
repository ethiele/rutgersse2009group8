using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    [ServiceContract]
    interface ICookService
    {
        /// <summary>
        /// Returns all non-completed food orders
        /// </summary>
        /// <param name="sessionID">The ID for this logged in session</param>
        /// <returns></returns>
        [OperationContract]
        List<FoodOrder> GetAllFoodOrders(string sessionID);
        
        /// <summary>
        /// Returns all food orders since the last time this function was called in
        /// this session
        /// </summary>
        /// <param name="sessionID">The ID for this logged in session</param>
        /// <returns></returns>
        [OperationContract]
        List<FoodOrder> GetNewFoodOrders(string sessionID);

        /// <summary>
        /// Marks the order as complete and has it sent out for delievery
        /// </summary>
        /// <param name="orderID">The ID of the order</param>
        [OperationContract]
        void MarkOrderAsComplete(int orderID);

        /// <summary>
        /// Marks the order as unable to complete, a reason must be provided 
        /// </summary>
        /// <param name="orderID">The ID of the order</param>
        /// <param name="reason">A string sent to the waiter explaing why an order cannot be compleated</param>
        [OperationContract]
        void RejectOrder(int orderID, string reason);
    }
}
