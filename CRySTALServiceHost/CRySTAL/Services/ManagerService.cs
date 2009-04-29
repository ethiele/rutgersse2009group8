using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using CRySTALDataConnections.CRySTALDataSetTableAdapters;

namespace CRySTAL
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ManagerService : IManagerService 
    {
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
                re.Add(be);
            }
            return re;
        }

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

        public void EditShift(string sessionID, int shiftNumber, int EmployeeId, string role, DateTime start, DateTime end)
        {
            WorkerShiftsTableAdapter wta = new WorkerShiftsTableAdapter();
            wta.Update(start, end, role, EmployeeId, shiftNumber);
        }

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
                re.Add(ed);
            }
            return re;
        }

        private List<string> getRoles(int userID)
        {
            RolesTableAdapter rta = new RolesTableAdapter();
            var roles = rta.GetDataByUserID(userID);
            return (from p in roles select p.Role).ToList();
        }

        public void AddUser(string sessionID, string username, string password, string firstname, string lastname, List<string> roles)
        {
            UsersTableAdapter uta = new UsersTableAdapter();
            uta.Insert(username, password, "", firstname, lastname);
        }

        public void ChangeUserPassword(string sessionID, int EmployeeID, string password)
        {
            UsersTableAdapter uta = new UsersTableAdapter();
            uta.UpdatePassword(password, EmployeeID);
        }

        public void RemoveUser(string sessionID, int EmployeeID)
        {
            UsersTableAdapter uta = new UsersTableAdapter();
            uta.DeleteUser(EmployeeID);
        }

        public void AddUserToRole(string sessionID, int EmployeeID, string role)
        {
            RolesTableAdapter rta = new RolesTableAdapter();
            rta.Insert(EmployeeID, role);
        }

        public void RemoveUserFromRole(string sessionID, int EmployeeID, string role)
        {
            RolesTableAdapter rta = new RolesTableAdapter();
            rta.DeleteUserFromRole(EmployeeID, role);
        }

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

        public BillData GetBillFromDB(Guid workflowInstId)
        {
            BillItemsTableAdapter bia = new BillItemsTableAdapter();
            var rows =bia.GetDataByWorkflowID(workflowInstId);
            BillData  bd = new BillData();
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
    }
}
