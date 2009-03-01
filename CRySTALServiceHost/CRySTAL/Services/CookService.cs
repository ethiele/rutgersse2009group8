using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

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
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                CRySTALerror err = new CRySTALerror();
                err.errorMessage = e.ToString();
                err.ErrorType = CRySTALerror.ErrorTypes.sessionError;
                err.sessionID = sessionID;
                throw new FaultException<CRySTALerror>(err);
            }
        }

        public List<FoodOrder> GetNewFoodOrders(string sessionID)
        {
            throw new NotImplementedException();
        }

        public void MarkOrderAsComplete(int orderID)
        {
            throw new NotImplementedException();
        }

        public void RejectOrder(int orderID, string reason)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
