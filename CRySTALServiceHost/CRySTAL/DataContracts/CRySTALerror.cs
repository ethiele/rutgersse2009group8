using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CRySTAL
{
    [DataContract]
    public class CRySTALerror
    {
        public enum ErrorTypes
        {
            loginError,
            sessionError,
            databaseError,
            inputError,
            generalError,
            catastrophicError
        };

        [DataMember]
        public string sessionID;
        [DataMember]
        public string errorMessage;
        [DataMember]
        public ErrorTypes ErrorType;
    }
}
