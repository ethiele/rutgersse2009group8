using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    [ServiceContract]
    public interface IBusBoyService
    {

        /// <summary>
        /// Returns all food orders with a status of readyToDelever and outForDelivery
        /// </summary>
        /// <param name="sessionID">The ID for this logged in session</param>
        /// <returns></returns>
        [OperationContract]
        List<FoodOrder> getAllFoodOrders(string sessionID);

        /// <summary>
        /// Returns all food orders with a status of readyToDelever and outForDelivery
        /// that have been added since the last call to this method
        /// </summary>
        /// <param name="sessionID">The ID for this logged in session</param>
        /// <returns></returns>
        [OperationContract]
        List<FoodOrder> getNewFoodOrders(string sessionID);

        /// <summary>
        /// Sets the selected orders status
        /// </summary>
        /// <param name="orderNumber">The order number who's status you wish to set</param>
        /// <param name="status">The status it is to be set to</param>
        [OperationContract]
        void MarkOrder(int orderNumber, FoodOrder.OrderStatusList status);
    }
}
