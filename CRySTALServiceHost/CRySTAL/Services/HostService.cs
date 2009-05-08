// --------------------------------
// <copyright file="HostService.cs" company="Rutgers Software Engineering (Group 8)">
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
    /// Provides an implementation of the IHostService 
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class HostService : IHostService
    {
        #region IHostService Members

        /// <summary>
        /// Gets all tables.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the free tables at a given time.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        /// <remarks>Not Currently Implemented</remarks>
        public Dictionary<TableTypes, List<int>> GetFreeTablesAt(string sessionID, DateTime time)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IHostService Members


        /// <summary>
        /// Assigns the table to a waiter.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="table">The table.</param>
        /// <param name="employeeID">The employee ID of the waiter.</param>
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
                instance.Unload();
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


        /// <summary>
        /// Gets all of the waiters on duty.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
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
                    be.username = Auth.getEmployeeUsername(worker.UserID);
                    be.id = worker.UserID;
                    be.role = "waiter";
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

        /// <summary>
        /// Makes a reservation.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="tblNumber">The table number.</param>
        /// <param name="name">The name on the reservation.</param>
        /// <param name="time">The time of hte reservation.</param>
        /// <returns></returns>
        /// <remarks>Not Currently Implmented</remarks>
        public bool MakeReservation(string sessionID, int tblNumber, string name, DateTime time)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Breaks the reservation.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="resId">The reservation id.</param>
        /// <remarks>Not Currently Implmented</remarks>
        public void BreakReservation(string sessionID, int resId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the reservations.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="start">The start date and time </param>
        /// <param name="end">The end date and time</param>
        /// <returns></returns>
        /// <remarks>Not Currently Implmented</remarks>
        public List<Reservation> GetReservations(string sessionID, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
