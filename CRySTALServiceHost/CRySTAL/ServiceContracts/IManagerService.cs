// --------------------------------
// <copyright file="IManagerService.cs" company="Rutgers Software Engineering (Group 8)">
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


namespace CRySTAL
{
    /// <summary>
    /// Defines a WCF service that contains methods used by the manager client to accomplish the goals of the manager role
    /// </summary>
    [ServiceContract]
    public interface IManagerService
    {
        /// <summary>
        /// Gets all employees on duty.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        [OperationContract]
        List<CRySTAL.BasicEmployee> GetAllEmployeesOnDuty(string sessionID);

        /// <summary>
        /// Gets a list of the shifts for employees during a timeframe.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="start">The start of the timeframe.</param>
        /// <param name="end">The end of the timeframe.</param>
        /// <returns></returns>
        [OperationContract]
        List<ShiftData> GetShiftsForEmployees(string sessionID, DateTime start, DateTime end);

        /// <summary>
        /// Adds a new shift.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="EmployeeID">The employee ID of the employee who's shift this is.</param>
        /// <param name="role">The role for the shift.</param>
        /// <param name="start">The start time of the shift.</param>
        /// <param name="end">The end time of the shift.</param>
        [OperationContract]
        void AddShift(string sessionID, int EmployeeID, string role, DateTime start, DateTime end);

        /// <summary>
        /// Removes a shift.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="shiftNumber">The shift number to be removed.</param>
        [OperationContract]
        void RemoveShift(string sessionID, int shiftNumber);

        /// <summary>
        /// Edits a shift based on its shift number.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="shiftNumber">The shift number to be edited.</param>
        /// <param name="EmployeeId">The new employee id.</param>
        /// <param name="role">The new role.</param>
        /// <param name="start">The new start time of the shift.</param>
        /// <param name="end">The new end time of the shift.</param>
        [OperationContract]
        void EditShift(string sessionID, int shiftNumber, int EmployeeId, string role, DateTime start, DateTime end);

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        [OperationContract]
        List<CRySTAL.EmployeeData> GetAllEmployees(string sessionID);

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="firstname">The firstname.</param>
        /// <param name="lastname">The lastname.</param>
        /// <param name="roles">The roles.</param>
        [OperationContract]
        void AddUser(string sessionID, string username, string password, string firstname, string lastname, List<string> roles);

        /// <summary>
        /// Changes the user password.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="EmployeeID">The employee ID.</param>
        /// <param name="password">The new password.</param>
        [OperationContract]
        void ChangeUserPassword(string sessionID, int EmployeeID, string password);

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="EmployeeID">The employee ID.</param>
        [OperationContract]
        void RemoveUser(string sessionID, int EmployeeID);

        /// <summary>
        /// Adds the user to role.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="EmployeeID">The employee ID of the employee.</param>
        /// <param name="role">The role that employee is to be added to.</param>
        [OperationContract]
        void AddUserToRole(string sessionID, int EmployeeID, string role);

        /// <summary>
        /// Removes the user from role.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="EmployeeID">The employee ID of hte employee.</param>
        /// <param name="role">The role the are to be removed from.</param>
        [OperationContract]
        void RemoveUserFromRole(string sessionID, int EmployeeID, string role);

        /// <summary>
        /// Gets the transactions over a time frame.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        [OperationContract]
        List<Transaction> GetTransactions(string sessionID, DateTime startTime, DateTime endTime);

        /// <summary>
        /// Gets the payrole report.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="startTime">The start time of the report.</param>
        /// <param name="endTime">The end time of the report.</param>
        /// <returns></returns>
        [OperationContract]
        PayroleReport GetPayroleReport(string sessionID, DateTime startTime, DateTime endTime);

        [OperationContract]
        List<double> GetStatistics(string sessionID, StatObject stat, StatType typeOfStat, int productID, DateTime start, DateTime end);

        [OperationContract]
        List<ItemSalesSummery> GetTopSellers(string sessionID, DateTime start, DateTime end, int numberOfItems);
    }
}
