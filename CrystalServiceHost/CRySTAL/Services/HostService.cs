using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

namespace CRySTAL
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class HostService : IHostService
    {
        #region IHostService Members

        public Dictionary<TableTypes, List<int>> GetTables(string sessionID)
        {
            Dictionary<TableTypes, List<int>> returnList = new Dictionary<TableTypes, List<int>>();
            CRySTALDataConnections.CrystalTablesDataContext db = new CRySTALDataConnections.CrystalTablesDataContext();
            var cleanTbls = from p in db.TablesTbls
                            where p.Status == (int)TableTypes.Clean
                            select p.ID;
            returnList.Add(TableTypes.Clean, cleanTbls.ToList());

            var dirty = from p in db.TablesTbls
                            where p.Status == (int)TableTypes.Dirty
                            select p.ID;
            returnList.Add(TableTypes.Dirty, dirty.ToList());

            var inuse = from p in db.TablesTbls
                            where p.Status == (int)TableTypes.InUse
                            select p.ID;
            returnList.Add(TableTypes.InUse, inuse.ToList());

            var cannotbeused = from p in db.TablesTbls
                            where p.Status == (int)TableTypes.CannotBeUsed
                            select p.ID;
            returnList.Add(TableTypes.CannotBeUsed, cannotbeused.ToList());

            var cleaning = from p in db.TablesTbls
                            where p.Status == (int)TableTypes.Cleaning
                            select p.ID;
            returnList.Add(TableTypes.Cleaning, cleaning.ToList());

            return returnList;
        }

        public Dictionary<TableTypes, List<int>> GetFreeTablesAt(string sessionID, DateTime time)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IHostService Members


        public void AssignTableTo(string sessionID, int table, int employeeID)
        {
            if (Auth.VerifySession(sessionID, "host"))
            {
                WorkflowRuntime workflowRuntime = AppDomain.CurrentDomain.GetData("WorkflowRuntime") as WorkflowRuntime;
                ManualWorkflowSchedulerService manualScheduler = AppDomain.CurrentDomain.GetData("ManualScheduler") as ManualWorkflowSchedulerService;
                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(CRySTALWorkflow.CustomerWorkflow));
                instance.Start();
                CRySTALDataConnections.CRySTALDataSetTableAdapters.CustomerTransactionsTableAdapter cta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.CustomerTransactionsTableAdapter();
                cta.InsertTransaction(instance.InstanceId, employeeID, table, true);
                manualScheduler.RunWorkflow(instance.InstanceId);

                CRySTALDataConnections.CRySTALDataSetTableAdapters.TablesTblTableAdapter tta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.TablesTblTableAdapter();
                tta.SetStatus(1, table);
            }
            else
            {
                CRySTALerror err = new CRySTALerror();
                err.ErrorType = CRySTALerror.ErrorTypes.sessionError;
                err.sessionID = sessionID;
                err.errorMessage = "Unable to verify session ID"; 
                throw new FaultException<CRySTALerror>(err);
            }
        }

        #endregion

        #region IHostService Members


        public List<BasicEmployee> GetWaitersOnDuty(string sessionID)
        {
            if (Auth.VerifySession(sessionID, "host"))
            {
                List<BasicEmployee> returnList = new List<BasicEmployee>();
                CRySTALDataConnections.CRySTALDataSetTableAdapters.EmployeeStatusTableAdapter esa = new CRySTALDataConnections.CRySTALDataSetTableAdapters.EmployeeStatusTableAdapter();
                CRySTALDataConnections.CRySTALDataSet.EmployeeStatusDataTable est;
                est = esa.GetOnDutyWorkers("waiter");
               
                foreach (CRySTALDataConnections.CRySTALDataSet.EmployeeStatusRow worker in est.Rows)
                {
                    BasicEmployee be = new BasicEmployee();
                    be.name = worker.Name;
                    be.id = worker.UserID;
                    returnList.Add(be);
                }
                return returnList;
            }
            else
            {
                CRySTALerror err = new CRySTALerror();
                err.ErrorType = CRySTALerror.ErrorTypes.sessionError;
                err.sessionID = sessionID;
                err.errorMessage = "Unable to verify session ID";
                throw new FaultException<CRySTALerror>(err);
            } 
        }

        #endregion
    }
}
