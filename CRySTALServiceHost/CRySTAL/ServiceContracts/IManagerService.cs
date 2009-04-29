using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;


namespace CRySTAL
{
    [ServiceContract]
    public interface IManagerService
    {
        [OperationContract]
        List<CRySTAL.BasicEmployee> GetAllEmployeesOnDuty(string sessionID);

        [OperationContract]
        List<ShiftData> GetShiftsForEmployees(string sessionID, DateTime start, DateTime end);

        [OperationContract]
        void AddShift(string sessionID, int EmployeeID, string role, DateTime start, DateTime end);

        [OperationContract]
        void RemoveShift(string sessionID, int shiftNumber);

        [OperationContract]
        void EditShift(string sessionID, int shiftNumber, int EmployeeId, string role, DateTime start, DateTime end);

        [OperationContract]
        List<CRySTAL.EmployeeData> GetAllEmployees(string sessionID);

        [OperationContract]
        void AddUser(string sessionID, string username, string password, string firstname, string lastname, List<string> roles);

        [OperationContract]
        void ChangeUserPassword(string sessionID, int EmployeeID, string password);

        [OperationContract]
        void RemoveUser(string sessionID, int EmployeeID);

        [OperationContract]
        void AddUserToRole(string sessionID, int EmployeeID, string role);

        [OperationContract]
        void RemoveUserFromRole(string sessionID, int EmployeeID, string role);

        [OperationContract]
        List<Transaction> GetTransactions(string sessionID, DateTime startTime, DateTime endTime);
    }
}
