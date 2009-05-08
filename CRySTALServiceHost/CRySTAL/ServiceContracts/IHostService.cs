// --------------------------------
// <copyright file="IHostService.cs" company="Rutgers Software Engineering (Group 8)">
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
    /// Defines a WCF service that contains methods used by the host client to accomplish the goals of the host role
    /// </summary>
    [ServiceContract]
    interface IHostService
    {
        /// <summary>
        /// Gets all tables.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        [OperationContract]
        Dictionary<TableTypes, List<Int32>> GetTables(string sessionID);
        /// <summary>
        /// Gets the free tables at a given time.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        [OperationContract]
        Dictionary<TableTypes, List<Int32>> GetFreeTablesAt(string sessionID, DateTime time);
        /// <summary>
        /// Assigns the table to a waiter.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="table">The table.</param>
        /// <param name="employeeID">The employee ID of the waiter.</param>
        [OperationContract]
        void AssignTableTo(string sessionID, int table, int employeeID);
        /// <summary>
        /// Gets all of the waiters on duty.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        [OperationContract]
        List<BasicEmployee> GetWaitersOnDuty(string sessionID);
        /// <summary>
        /// Makes a reservation.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="tblNumber">The table number.</param>
        /// <param name="name">The name on the reservation.</param>
        /// <param name="time">The time of hte reservatoin.</param>
        /// <returns></returns>
        bool MakeReservation(string sessionID, int tblNumber, string name, DateTime time);
        /// <summary>
        /// Breaks the reservation.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="resId">The reservation id.</param>
        [OperationContract]
        void BreakReservation(string sessionID, int resId);
        [OperationContract]
        List<Reservation> GetReservations(string sessionID, DateTime start, DateTime end);

    }
}
