using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using CRySTALDataConnections.CRySTALDataSetTableAdapters;

namespace CRySTAL
{
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

        public List<FoodOrder> GetNewFoodOrders(string sessionID)
        {
            throw new NotImplementedException();
        }

        public void MarkOrderAsComplete(int orderID)
        {
            FoodOrdersTableAdapter fta = new FoodOrdersTableAdapter();
            fta.UpdateOrderStatus((int)CRySTAL.FoodOrder.OrderStatusList.readyToDeliver, orderID);
            fta.UpdateEndTime(orderID);
        }

        public void RejectOrder(int orderID, string reason)
        {
            FoodOrdersTableAdapter fta = new FoodOrdersTableAdapter();
            fta.UpdateOrderStatus((int)CRySTAL.FoodOrder.OrderStatusList.orderCanceled, orderID);
            fta.UpdateEndTime(orderID);
        }

        #endregion
    }
}
