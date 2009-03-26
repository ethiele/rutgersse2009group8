using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CRySTAL
{
    [DataContract]
    public class BasicEmployee
    {
        [DataMember]
        public int id;
        [DataMember]
        public string name;
    }
}
