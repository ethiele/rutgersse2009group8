// --------------------------------
// <copyright file="ManagerService.cs" company="Rutgers Software Engineering (Group 8)">
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
using CRySTALDataConnections.CRySTALDataSetTableAdapters;

namespace CRySTAL
{
    /// <summary>
    /// Provides an implementation of the IManagerService
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ManagerService : IManagerService 
    {
        /// <summary>
        /// Gets all employees on duty.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        public List<BasicEmployee> GetAllEmployeesOnDuty(string sessionID)
        {
            List<BasicEmployee> re = new List<BasicEmployee>();
            EmployeeStatusTableAdapter esa = new EmployeeStatusTableAdapter();
            var rows = esa.GetAllWorkersOnDuty();
            foreach (var row in rows)
            {
                BasicEmployee be = new BasicEmployee();
                be.id = row.UserID;
                be.name = row.Name;
                be.role = row.Role;
                be.username = Auth.getEmployeeUsername(row.UserID);
                re.Add(be);
            }
            return re;
        }

        /// <summary>
        /// Gets a list of the shifts for employees during a timeframe.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="start">The start of the timeframe.</param>
        /// <param name="end">The end of the timeframe.</param>
        /// <returns></returns>
        public List<ShiftData> GetShiftsForEmployees(string sessionID, DateTime start, DateTime end)
        {
            List<ShiftData> re = new List<ShiftData>();
            WorkerShiftsTableAdapter wsa = new WorkerShiftsTableAdapter();
            var rows = wsa.GetDataByTimeFrame(start, end);
            foreach (var row in rows)
            {
                ShiftData sd = new ShiftData();
                sd.EmployeeID = row.EmployeeID;
                sd.StartTime = row.StartTime;
                if (row.IsEndTimeNull()) sd.EndTime = null;
                else
                    sd.EndTime = row.EndTime;
                sd.ShiftID = row.ID;
                sd.Role = row.Role;
                if (sd.EndTime != null)
                    sd.HoursWorked = (decimal)sd.EndTime.Value.Subtract(sd.StartTime).TotalHours;
                else 
                    sd.HoursWorked = 0;

                re.Add(sd);
            }
            return re;
        }

        /// <summary>
        /// Adds a new shift.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="EmployeeID">The employee ID of the employee who's shift this is.</param>
        /// <param name="role">The role for the shift.</param>
        /// <param name="start">The start time of the shift.</param>
        /// <param name="end">The end time of the shift.</param>
        public void AddShift(string sessionID, int EmployeeID, string role, DateTime start, DateTime end)
        {
            WorkerShiftsTableAdapter wta = new WorkerShiftsTableAdapter();
            wta.Insert(start, end, role, EmployeeID);
        }

        public void RemoveShift(string sessionID, int shiftNumber)
        {
            WorkerShiftsTableAdapter wta = new WorkerShiftsTableAdapter();
            wta.DeleteRow(shiftNumber);
        }

        /// <summary>
        /// Edits a shift based on its shift number.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="shiftNumber">The shift number to be edited.</param>
        /// <param name="EmployeeId">The new employee id.</param>
        /// <param name="role">The new role.</param>
        /// <param name="start">The new start time of the shift.</param>
        /// <param name="end">The new end time of the shift.</param>
        public void EditShift(string sessionID, int shiftNumber, int EmployeeId, string role, DateTime start, DateTime end)
        {
            WorkerShiftsTableAdapter wta = new WorkerShiftsTableAdapter();
            wta.Update(start, end, role, EmployeeId, shiftNumber);
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        public List<EmployeeData> GetAllEmployees(string sessionID)
        {
            UsersTableAdapter uta = new UsersTableAdapter();
            List<EmployeeData> re = new List<EmployeeData>();
            var rows = uta.GetData();
            foreach (var row in rows)
            {
                EmployeeData ed = new EmployeeData();
                ed.id = row.ID;
                ed.name = row.FirstName + " " + row.LastName;
                ed.roles = getRoles(row.ID);
                ed.username = row.Username;
                re.Add(ed);
            }
            return re;
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        private List<string> getRoles(int userID)
        {
            RolesTableAdapter rta = new RolesTableAdapter();
            var roles = rta.GetDataByUserID(userID);
            return (from p in roles select p.Role).ToList();
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="firstname">The firstname.</param>
        /// <param name="lastname">The lastname.</param>
        /// <param name="roles">The roles.</param>
        public void AddUser(string sessionID, string username, string password, string firstname, string lastname, List<string> roles)
        {
            UsersTableAdapter uta = new UsersTableAdapter();
            int id = (int)((decimal)(uta.InsertAndGetIdentity(username, password, "", firstname, lastname)));
            foreach (string role in roles)
            {
                RolesTableAdapter rta = new RolesTableAdapter();
                rta.Insert(id, role);
            }
        }

        /// <summary>
        /// Changes the user password.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="EmployeeID">The employee ID.</param>
        /// <param name="password">The new password.</param>
        public void ChangeUserPassword(string sessionID, int EmployeeID, string password)
        {
            UsersTableAdapter uta = new UsersTableAdapter();
            uta.UpdatePassword(password, EmployeeID);
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="EmployeeID">The employee ID.</param>
        public void RemoveUser(string sessionID, int EmployeeID)
        {
            UsersTableAdapter uta = new UsersTableAdapter();
            uta.DeleteUser(EmployeeID);
        }

        /// <summary>
        /// Adds the user to role.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="EmployeeID">The employee ID of the employee.</param>
        /// <param name="role">The role that employee is to be added to.</param>
        public void AddUserToRole(string sessionID, int EmployeeID, string role)
        {
            RolesTableAdapter rta = new RolesTableAdapter();
            rta.Insert(EmployeeID, role);
        }

        /// <summary>
        /// Removes the user from role.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="EmployeeID">The employee ID of hte employee.</param>
        /// <param name="role">The role the are to be removed from.</param>
        public void RemoveUserFromRole(string sessionID, int EmployeeID, string role)
        {
            RolesTableAdapter rta = new RolesTableAdapter();
            rta.DeleteUserFromRole(EmployeeID, role);
        }

        /// <summary>
        /// Gets the transactions over a time frame.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        public List<Transaction> GetTransactions(string sessionID, DateTime startTime, DateTime endTime)
        {

            CustomerTransactionsTableAdapter cta = new CustomerTransactionsTableAdapter();
            var rows = cta.GetDataByTimeFrame(startTime, endTime);
            List<Transaction> re = new List<Transaction>();
            foreach (var row in rows)
            {
                Transaction trans = new Transaction();
                trans.Bill = GetBillFromDB(row.WorkflowInstID);
                trans.AssignedTo = row.AssignedTo;
                trans.StartTime = row.StartTime;
                if (row.IsEndTimeNull()) trans.EndTime = null;
                else
                    trans.EndTime = row.EndTime;
                trans.ID = row.Id;
                trans.IsActive = row.IsActive;
                trans.NotPaied = row.NotPaied;
                trans.TableNumber = row.TableNumber;
                trans.WorkflowInstID = row.WorkflowInstID;
                re.Add(trans);
            }
            return re;
        }

        /// <summary>
        /// Gets the bill from DB.
        /// </summary>
        /// <param name="workflowInstId">The workflow inst id.</param>
        /// <returns></returns>
        public BillData GetBillFromDB(Guid workflowInstId)
        {
            BillItemsTableAdapter bia = new BillItemsTableAdapter();
            var rows = bia.GetDataByWorkflowID(workflowInstId);
            BillData bd = new BillData();
            bd.BillTotal = 0.00M;
            bd.Items = new List<BillItem>();
            foreach (var row in rows)
            {
                BillItem bi = new BillItem();
                bi.ItemName = row.Name;
                bi.ItemPrice = row.Price;
                bi.Person = row.Person;
                bd.Items.Add(bi);
                bd.BillTotal += bi.ItemPrice;
            }
            return bd;
        }

        /// <summary>
        /// Gets the payrole report.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="startTime">The start time of the report.</param>
        /// <param name="endTime">The end time of the report.</param>
        /// <returns></returns>
        public PayroleReport GetPayroleReport(string sessionID, DateTime startTime, DateTime endTime)
        {
            PayroleReport re = new PayroleReport();
            UsersTableAdapter uta = new UsersTableAdapter();
            RolePayrateTableAdapter rta = new RolePayrateTableAdapter();
            var payoutTable = rta.GetData();
            var employees = uta.GetData();
            decimal totalPayout = 0;
            re.Employees = new List<EmployeePayout>();
            foreach (var employee in employees)
            {
                EmployeePayout ep = GetEmployeePayout(employee, startTime, endTime, payoutTable);
                if (ep != null)
                {
                    totalPayout += ep.TotalPayment;
                    re.Employees.Add(ep);
                }
            }
            re.TotalPayout = totalPayout;
            re.StartReportTimeframe = startTime;
            re.EndReportTimeframe = endTime;
            return re;
        }

        /// <summary>
        /// Gets the employee payout.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <param name="start">The start date and time </param>
        /// <param name="end">The end date and time</param>
        /// <param name="payoutTable">The payout table.</param>
        /// <returns></returns>
        private EmployeePayout GetEmployeePayout(
            CRySTALDataConnections.CRySTALDataSet.UsersRow employee, 
            DateTime start, DateTime end, 
            CRySTALDataConnections.CRySTALDataSet.RolePayrateDataTable payoutTable)
        {
            WorkerShiftsTableAdapter wsa = new WorkerShiftsTableAdapter();
            var shifts = wsa.GetDataByEmployeeIDInTimeFrame(employee.ID, end, start);
            if (shifts.Count == 0) return null;

            EmployeePayout re = new EmployeePayout();
            re.EmployeeID = employee.ID;
            re.EmployeeName = employee.LastName + ", " + employee.FirstName;
            re.Roles = new List<RolePayout>();
            List<string> roles = (from p in shifts select p.Role).Distinct().ToList();
            decimal payoutTotal = 0;
            foreach (string role in roles)
            {
                RolePayout rp = new RolePayout();
                rp.HoursWorked = (decimal)(from p in shifts
                                  where (!p.IsEndTimeNull() && p.Role==role)
                                  select p.EndTime.Subtract(p.StartTime).TotalHours).Sum();
                rp.Rate = (from p in payoutTable where p.Role == role select p.PayPerHour).FirstOrDefault();
                rp.RoleName = role;
                rp.TotalPayment = rp.HoursWorked * rp.Rate;
                re.Roles.Add(rp);
                payoutTotal += rp.TotalPayment;
            }
            re.TotalPayment = payoutTotal;
            return re;
        }

        /// <summary>
        /// Gets the statistics.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="stat">The stat.</param>
        /// <param name="typeOfStat">The type of stat.</param>
        /// <param name="productID">The product ID.</param>
        /// <param name="start">The start date and time </param>
        /// <param name="end">The end date and time</param>
        /// <returns></returns>
        public List<double> GetStatistics(string sessionID, StatObject stat, StatType typeOfStat, int productID, DateTime start, DateTime end)
        {
            if (stat == StatObject.Income)
            {
                if (typeOfStat == StatType.ForEachDay)
                {
                    
                    BillItemsTableAdapter bia = new BillItemsTableAdapter();
                    CustomerTransactionsTableAdapter cta = new CustomerTransactionsTableAdapter();
                    var transactions = cta.GetDataByTimeFrame(start, end);
                    int numOfDays = (int)(end.Date.Subtract(start.Date).TotalDays);

                    double[] re = new double[numOfDays+1];
                    foreach (var trans in transactions)
                    {
                        if (!trans.IsEndTimeNull())
                        {
                            int dayVal = (int)(trans.EndTime.Date.Subtract(start.Date).TotalDays);
                            var bills = bia.GetDataByWorkflowID(trans.WorkflowInstID);
                            re[dayVal] += (double)(from p in bills select p.Price).Sum();
                        }
                    }
                    return re.ToList();
                    
                }
            }
            else if (stat == StatObject.PayroleExpence)
            {
                if (typeOfStat == StatType.ForEachDay)
                {
                    WorkerShiftsTableAdapter wta = new WorkerShiftsTableAdapter();
                    var shifts = wta.GetDataByTimeFrame(start, end);
                    int numOfDays = (int)(end.Date.Subtract(start.Date).TotalDays);
                    RolePayrateTableAdapter rta = new RolePayrateTableAdapter();
                    var payoutTable = rta.GetData();
                    List<double> re = new List<double>();
                   
                    DateTime i_start = start.Date;
                    DateTime i_end = i_start.Add(new TimeSpan(1, 0, 0, 0));
                    for (int i = 0; i < numOfDays; i++)
                    {
                        decimal v = (from p in shifts
                                     where p.StartTime > i_start && p.StartTime < i_end && 
                                     p.IsEndTimeNull() == false
                                     select (from q in payoutTable where q.Role == p.Role select q.PayPerHour).FirstOrDefault()
                                     * (decimal)(p.EndTime.Subtract(p.StartTime).TotalHours)).Sum();
                        re.Add((double)v);
                        i_start = i_end;
                        i_end = i_start.Add(new TimeSpan(1, 0, 0, 0));
                                     
                    }
                    return re;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the top sellers.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="start">The start date and time </param>
        /// <param name="end">The end date and time</param>
        /// <param name="numberOfItems">The number of items.</param>
        /// <returns></returns>
        public List<ItemSalesSummery> GetTopSellers(string sessionID, DateTime start, DateTime end, int numberOfItems)
        {
            BillItemsTableAdapter bia = new BillItemsTableAdapter();
            CustomerTransactionsTableAdapter cta = new CustomerTransactionsTableAdapter();
            var transactions = cta.GetDataByTimeFrame(start, end);
            List<CRySTALDataConnections.CRySTALDataSet.BillItemsRow> bit = new List<CRySTALDataConnections.CRySTALDataSet.BillItemsRow>();

            foreach (var trans in transactions)
            {
                var billsItems = bia.GetDataByWorkflowID(trans.WorkflowInstID).ToList();
                bit.AddRange(billsItems);
            }

            List<string> itemNames = (from p in bit select p.Name).Distinct().ToList();
            List<ItemSalesSummery> iss = new List<ItemSalesSummery>();
            foreach (string itemName in itemNames)
            {
                ItemSalesSummery sum = new ItemSalesSummery();
                sum.itemName = itemName;
                sum.totalAmountSold = (from p in bit where p.Name == itemName select p).Count();
                sum.cost = (from p in bit where p.Name == itemName select p.Price).FirstOrDefault();
                sum.totalAmount = sum.totalAmountSold * sum.cost;
                iss.Add(sum);
            }
            return (from p in iss orderby p.totalAmountSold descending select p).Take(numberOfItems).ToList();
        }
    }
}
