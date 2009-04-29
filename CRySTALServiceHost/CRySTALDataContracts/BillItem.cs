using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CRySTAL
{
    [DataContract]
    public class BillItem
    {
        [DataMember]
        public string ItemName;
        [DataMember]
        public decimal ItemPrice;
        [DataMember]
        public int Person;
    }
}
