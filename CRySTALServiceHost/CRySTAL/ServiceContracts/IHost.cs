using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL.ServiceContracts
{
    [ServiceContract]
    interface IHost
    {
        [OperationContract]
        Dictionary<TableTypes, List<Int32>> GetTables(string sessionID);
        [OperationContract]
        Dictionary<TableTypes, List<Int32>> GetFreeTablesAt(string sessionID, DateTime time);
        

    }
}
