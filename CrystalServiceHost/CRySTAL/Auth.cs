using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRySTAL
{
    /// <summary>
    /// Provides authentication related services
    /// </summary>
    public class Auth
    {
        public static bool VerifySession(string sessionID)
        {

            return true;
        }

        public static int getEmployeeID(string sessionID)
        {
            CRySTALDataConnections.CRySTALDataSetTableAdapters.SessionsTableAdapter sta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.SessionsTableAdapter();
            CRySTALDataConnections.CRySTALDataSet.SessionsDataTable sdt;
            sdt = sta.GetDataBySessionID(new Guid(sessionID));
            if (sdt.Rows.Count == 0) return 0;
            return sdt.First().UserID;
        }

        public static bool VerifySession(string sessionID, string role)
        {
            return true;
        }

    }
}
