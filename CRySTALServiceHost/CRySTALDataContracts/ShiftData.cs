using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CRySTAL
{
    [DataContract]
    public class ShiftData
    {
        [DataMember]
        public DateTime StartTime;
        [DataMember]
        public DateTime? EndTime;
        [DataMember]
        public decimal HoursWorked;
        [DataMember]
        public string Role;
        [DataMember]
        public int EmployeeID;
        [DataMember]
        public int ShiftID;
    }
}
