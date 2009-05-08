// --------------------------------
// <copyright file="WaiterService.cs" company="Rutgers Software Engineering (Group 8)">
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
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

namespace CRySTAL
{
    /// <summary>
    /// Provides an implementation of the IWaiter
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WaiterService : IWaiterService
    {
        /// <summary>
        /// Throws the session exp.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        void throwSessionExp(string sessionID)
        {
            CRySTALerror err = new CRySTALerror();
            err.ErrorType = CRySTALerror.ErrorTypes.sessionError;
            err.sessionID = sessionID;
            err.errorMessage = "Unable to verify session ID";
            throw new FaultException<CRySTALerror>(err);
        }
        #region IWaiter Members

        /// <summary>
        /// Places the order a new order, sends it to the cook and adds the items to the bill.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="order">The order to be placed.</param>
        public void PlaceOrder(string sessionID, FoodOrder order)
        {
            if (Auth.VerifySession(sessionID, "waiter"))
            {

                Guid id = getWorkflowIdFromTable(order.DeliverToTable);
                WorkflowInterface.WorkflowInterface.CustomerWF.RaisePlaceFoodOrder(
                    new WorkflowLocalService.FoodOrderEventArgs(id,
                        order));
                ManualWorkflowSchedulerService manualScheduler = AppDomain.CurrentDomain.GetData("ManualScheduler") as ManualWorkflowSchedulerService;
                manualScheduler.RunWorkflow(id);
            }
            else
            {
                throwSessionExp(sessionID);
            }
        }

        /// <summary>
        /// Gets the returned orders from the cook.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        public List<RejectedOrder> GetReturnedOrders(string sessionID)
        {
            return new List<RejectedOrder>();
        }

        /// <summary>
        /// Gets the current tables assigned to this waiter.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        public List<int> GetCurrentTables(string sessionID)
        {
            List<int> returnList = new List<int>();
            CRySTALDataConnections.CRySTALDataSetTableAdapters.CustomerTransactionsTableAdapter cta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.CustomerTransactionsTableAdapter();
            CRySTALDataConnections.CRySTALDataSet.CustomerTransactionsDataTable ctd;
            ctd = cta.GetDataByEmplyee(Auth.getEmployeeID(sessionID));
            foreach (CRySTALDataConnections.CRySTALDataSet.CustomerTransactionsRow row in ctd.Rows)
            {
                returnList.Add(row.TableNumber);
            }
            return returnList;
        }

        #endregion

        #region IWaiterService Members


        /// <summary>
        /// Adds the item to bill and markes it as done. Does not send the order to the cook.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="order">The order to be added to the bill.</param>
        public void AddItemToBill(string sessionID, FoodOrder order)
        {
            if (Auth.VerifySession(sessionID, "waiter"))
            {
                Guid id = getWorkflowIdFromTable(order.DeliverToTable);
                WorkflowInterface.WorkflowInterface.CustomerWF.RaiseAddFoodOrderToBill(
                    new WorkflowLocalService.FoodOrderEventArgs(id,
                        order));
                ManualWorkflowSchedulerService manualScheduler = AppDomain.CurrentDomain.GetData("ManualScheduler") as ManualWorkflowSchedulerService;
                manualScheduler.RunWorkflow(id);
            }
            else
            {
                throwSessionExp(sessionID);
            }
        }

        private Guid getWorkflowIdFromTable(int tblNumber)
        {
            CRySTALDataConnections.CRySTALDataSetTableAdapters.CustomerTransactionsTableAdapter cta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.CustomerTransactionsTableAdapter();
            CRySTALDataConnections.CRySTALDataSet.CustomerTransactionsDataTable cdt = cta.GetDataByActiveTableNumber(tblNumber);
            if (cdt.Count > 0)
            {
                return cdt.First().WorkflowInstID;
            }
            return new Guid();
        }

        #endregion

        #region IWaiterService Members


        /// <summary>
        /// Gets the receipt.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="tblNumber">The table number.</param>
        /// <returns></returns>
        public List<BillItem> GetReceipt(string sessionID, int tblNumber)
        {
            if (Auth.VerifySession(sessionID, "waiter"))
            {
                Guid id = getWorkflowIdFromTable(tblNumber);
                WorkflowInterface.WorkflowInterface.CustomerWF.RaiseCheckRequest(new System.Workflow.Activities.ExternalDataEventArgs(id));
                ManualWorkflowSchedulerService manualScheduler = AppDomain.CurrentDomain.GetData("ManualScheduler") as ManualWorkflowSchedulerService;
                manualScheduler.RunWorkflow(id);

                List<BillItem> returnList = new List<BillItem>();
                CRySTALDataConnections.CRySTALDataSet.BillItemsDataTable bit;
                CRySTALDataConnections.CRySTALDataSetTableAdapters.BillItemsTableAdapter bia = new CRySTALDataConnections.CRySTALDataSetTableAdapters.BillItemsTableAdapter();
                bit = bia.GetDataByWorkflowID(id);
                foreach (CRySTALDataConnections.CRySTALDataSet.BillItemsRow row in bit.Rows)
                {
                    BillItem bi = new BillItem();
                    bi.ItemName = row.Name;
                    bi.ItemPrice = row.Price;
                    bi.Person = row.Person;
                    returnList.Add(bi);
                }
                return returnList;
            }
            else
            {
                throwSessionExp(sessionID);
            }
            return new List<BillItem>();
        }

        

        #endregion

        #region IWaiterService Members


        /// <summary>
        /// Gets the tables who have finished there order and who now need to pay
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        public List<int> GetInPaymentTables(string sessionID)
        {
            List<int> returnList = new List<int>();
            CRySTALDataConnections.CRySTALDataSetTableAdapters.CustomerTransactionsTableAdapter cta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.CustomerTransactionsTableAdapter();
            CRySTALDataConnections.CRySTALDataSet.CustomerTransactionsDataTable ctd;
            ctd = cta.GetInPaymentData(Auth.getEmployeeID(sessionID));
            foreach (CRySTALDataConnections.CRySTALDataSet.CustomerTransactionsRow row in ctd.Rows)
            {
                returnList.Add(row.TableNumber);
            }
            return returnList;
        }

        #endregion

        #region IWaiterService Members


        /// <summary>
        /// Marks the order as paid and marks the table to be cleaned.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="tblNumber">The table number.</param>
        public void MarkPaid(string sessionID, int tblNumber)
        {
            if (Auth.VerifySession(sessionID, "waiter"))
            {
                Guid id = getWorkflowIdFromTable(tblNumber);
                WorkflowInterface.WorkflowInterface.CustomerWF.RaiseOrderPaid(new System.Workflow.Activities.ExternalDataEventArgs(id));
                ManualWorkflowSchedulerService manualScheduler = AppDomain.CurrentDomain.GetData("ManualScheduler") as ManualWorkflowSchedulerService;
                manualScheduler.RunWorkflow(id);
            }
            else
            {
                throwSessionExp(sessionID);
            }
        }

        #endregion


    }
}
