using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CRySTAL
{
    [DataContract]
    public class Transaction
    {
        [DataMember]
        public int ID;
        [DataMember]
        public Guid WorkflowInstID;
        [DataMember]
        public int AssignedTo;
        [DataMember]
        public int TableNumber;
        [DataMember]
        public bool IsActive;
        [DataMember]
        public bool NotPaied;
        [DataMember]
        public DateTime StartTime;
        [DataMember]
        public DateTime? EndTime;
        [DataMember]
        public BillData Bill;
    }
}
