// --------------------------------
// <copyright file="TimeCardService.cs" company="Rutgers Software Engineering (Group 8)">
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
    /// Provides an implementation of the ITimeCardService
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class TimeCardService : ITimeCardService
    {

        /// <summary>
        /// Starts a new shift of the given logged in in the given role.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <param name="role">The role.</param>
        public void StampShiftStart(string sessionID, string role)
        {
            WorkerShiftsTableAdapter wta = new WorkerShiftsTableAdapter();
            wta.Insert(DateTime.Now, null, role, Auth.getEmployeeID(sessionID));
            EmployeeStatusTableAdapter est = new EmployeeStatusTableAdapter();
            est.UpdateStatus(true, role, Auth.getEmployeeID(sessionID));
        }

        /// <summary>
        /// Ends the shift of the given user if they are in a shift.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns>
        /// Returns true if the user's shift could be ended, else returns false
        /// </returns>
        public bool StampShiftEnd(string sessionID)
        {
            WorkerShiftsTableAdapter wta = new WorkerShiftsTableAdapter();
            var lastStartTime = wta.GetDataByEmployeeID(Auth.getEmployeeID(sessionID), DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).FirstOrDefault();
            EmployeeStatusTableAdapter est = new EmployeeStatusTableAdapter();
            est.UpdateStatus(false, "", Auth.getEmployeeID(sessionID));

            if (lastStartTime == null || !lastStartTime.IsEndTimeNull())
            {
                return false;
            }
            else
            {
                lastStartTime.EndTime = DateTime.Now;
                wta.Update(lastStartTime);
                return true;
            }
        }

        /// <summary>
        /// Determines whether this instance can stamp out the current user.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns>
        /// 	<c>true</c> if this instance can stamp out the current user; otherwise, <c>false</c>.
        /// </returns>
        public bool CanStampOut(string sessionID)
        {
            WorkerShiftsTableAdapter wta = new WorkerShiftsTableAdapter();
            var lastStartTime =  wta.GetDataByEmployeeID(Auth.getEmployeeID(sessionID), DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).FirstOrDefault();
            if (lastStartTime == null || !lastStartTime.IsEndTimeNull())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets the last weeks worth of shifts for the current user.
        /// </summary>
        /// <param name="sessionID">The sessionID of the current session</param>
        /// <returns></returns>
        public List<ShiftData> GetLastWeeksShifts(string sessionID)
        {
            WorkerShiftsTableAdapter wta = new WorkerShiftsTableAdapter();
            var lastWeekShifts = wta.GetDataByEmployeeID(Auth.getEmployeeID(sessionID), DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0)));
            List<ShiftData> re = new List<ShiftData>();
            foreach (var shift in lastWeekShifts)
            {
                ShiftData sd = new ShiftData();
                sd.EmployeeID = shift.EmployeeID;
                if (shift.IsEndTimeNull()) sd.EndTime = null; 
                else
                    sd.EndTime = shift.EndTime;
                sd.StartTime = shift.StartTime;
                sd.Role = shift.Role;
                sd.ShiftID = shift.ID;
                if (sd.EndTime != null)
                {
                    sd.HoursWorked = (decimal)sd.EndTime.Value.Subtract(sd.StartTime).TotalHours;
                }
                else
                {
                    sd.HoursWorked = 0;
                }
                re.Add(sd);
            }
            return re;
        }
    }
}
