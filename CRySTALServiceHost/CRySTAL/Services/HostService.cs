using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class HostService : IHostService
    {
        #region IHostService Members

        public Dictionary<TableTypes, List<int>> GetTables(string sessionID)
        {
            throw new NotImplementedException();
        }

        public Dictionary<TableTypes, List<int>> GetFreeTablesAt(string sessionID, DateTime time)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
