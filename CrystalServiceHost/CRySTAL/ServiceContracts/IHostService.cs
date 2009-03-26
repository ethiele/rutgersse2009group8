using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    [ServiceContract]
    interface IHostService
    {
        [OperationContract]
        Dictionary<TableTypes, List<Int32>> GetTables(string sessionID);
        [OperationContract]
        Dictionary<TableTypes, List<Int32>> GetFreeTablesAt(string sessionID, DateTime time);
        [OperationContract]
        void AssignTableTo(string sessionID, int table, int employeeID);
        [OperationContract]
        List<BasicEmployee> GetWaitersOnDuty(string sessionID);
    }
}
