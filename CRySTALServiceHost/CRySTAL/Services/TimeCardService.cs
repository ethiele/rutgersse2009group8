using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using CRySTALDataConnections.CRySTALDataSetTableAdapters;

namespace CRySTAL
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class TimeCardService : ITimeCardService
    {

        public void StampShiftStart(string sessionID, string role)
        {
            WorkerShiftsTableAdapter wta = new WorkerShiftsTableAdapter();
            wta.Insert(DateTime.Now, null, role, Auth.getEmployeeID(sessionID));
            EmployeeStatusTableAdapter est = new EmployeeStatusTableAdapter();
            est.UpdateStatus(true, role, Auth.getEmployeeID(sessionID));
        }

        public bool StampShiftEnd(string sessionID)
        {
            WorkerShiftsTableAdapter wta = new WorkerShiftsTableAdapter();
            var lastStartTime = wta.GetDataByEmployeeID(Auth.getEmployeeID(sessionID), DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).First();
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

        public bool CanStampOut(string sessionID)
        {
            WorkerShiftsTableAdapter wta = new WorkerShiftsTableAdapter();
            var lastStartTime = wta.GetDataByEmployeeID(Auth.getEmployeeID(sessionID), DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0))).First();
            if (lastStartTime == null || !lastStartTime.IsEndTimeNull())
            {
                return false;
            }
            return true;
        }

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
