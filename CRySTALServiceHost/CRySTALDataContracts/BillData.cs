using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CRySTAL
{
    [DataContract]
    public class BillData
    {
        [DataMember]
        public List<BillItem> Items;
        [DataMember]
        public decimal BillTotal;
    }
}
