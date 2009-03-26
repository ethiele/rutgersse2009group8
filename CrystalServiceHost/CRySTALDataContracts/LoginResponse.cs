using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace CRySTAL
{
    [DataContract]
    public class LoginResponse
    {
        [DataMember]
        public bool LoginSuccess;
        [DataMember]
        public string SessionID;
        [DataMember]
        public List<string> Roles;
    }
}
