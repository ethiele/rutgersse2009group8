using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    [ServiceContract]
    interface ITimeCardService
    {
        [OperationContract]
        void StampShiftStart(string sessionID, string role);

        [OperationContract]
        bool StampShiftEnd(string sessionID);

        [OperationContract]
        List<ShiftData> GetLastWeeksShifts(string sessionID);
    }
}
