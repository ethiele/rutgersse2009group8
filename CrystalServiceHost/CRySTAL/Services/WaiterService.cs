using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

namespace CRySTAL
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WaiterService : IWaiterService
    {
        void throwSessionExp(string sessionID)
        {
            CRySTALerror err = new CRySTALerror();
            err.ErrorType = CRySTALerror.ErrorTypes.sessionError;
            err.sessionID = sessionID;
            err.errorMessage = "Unable to verify session ID";
            throw new FaultException<CRySTALerror>(err);
        }
        #region IWaiter Members

        public void PlaceOrder(string sessionID, FoodOrder order)
        {
            if (Auth.VerifySession(sessionID, "waiter"))
            {

                Guid id = getWorkflowIdFromTable(order.DeleverToTable);
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

        public List<RejectedOrder> GetReturnedOrders(string sessionID)
        {
            throw new NotImplementedException();
        }

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


        public void AddItemToBill(string sessionID, FoodOrder order)
        {
            if (Auth.VerifySession(sessionID, "waiter"))
            {
                Guid id = getWorkflowIdFromTable(order.DeleverToTable);
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


        public void MarkPaied(string sessionID, int tblNumber)
        {
            if (Auth.VerifySession(sessionID, "waiter"))
            {
                Guid id = getWorkflowIdFromTable(tblNumber);
                WorkflowInterface.WorkflowInterface.CustomerWF.RaiseOrderPaied(new System.Workflow.Activities.ExternalDataEventArgs(id));
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
