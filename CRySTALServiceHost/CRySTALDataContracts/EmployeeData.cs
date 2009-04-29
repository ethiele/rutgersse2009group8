using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CRySTAL
{
    [DataContract]
    public class EmployeeData
    {
        [DataMember]
        public int id;
        [DataMember]
        public string name;
        [DataMember]
        public List<string> roles;
    }
}
