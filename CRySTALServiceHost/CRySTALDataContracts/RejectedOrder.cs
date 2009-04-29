using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CRySTAL
{
    [DataContract]
    public class RejectedOrder
    {
        [DataMember]
        public FoodOrder order;
        [DataMember]
        public string reason;
    }
}
