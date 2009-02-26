using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace CRySTAL
{
    [DataContract]
    public class LoginResponce
    {
        [DataMember]
        public bool LoginSuccess;
        [DataMember]
        public string SessionID;
    }
}
