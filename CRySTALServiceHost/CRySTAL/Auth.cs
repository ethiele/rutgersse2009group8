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
            // While the database supports this operation, to make testing / demoing easier 
            // this method always returns true
        }

        public static int getEmployeeID(string sessionID)
        {
            CRySTALDataConnections.CRySTALDataSetTableAdapters.SessionsTableAdapter sta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.SessionsTableAdapter();
            CRySTALDataConnections.CRySTALDataSet.SessionsDataTable sdt;
            sdt = sta.GetDataBySessionID(new Guid(sessionID));
            if (sdt.Rows.Count == 0) return 0;
            return sdt.First().UserID;
        }

        public static string getEmployeeUsername(int id)
        {
            CRySTALDataConnections.CRySTALDataSetTableAdapters.UsersTableAdapter uta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.UsersTableAdapter();
            var users = uta.GetData();
            return (from p in users where p.ID == id select p.Username).First();
        }

        public static bool VerifySession(string sessionID, string role)
        {
            return true;
            // While the database supports this operation, to make testing / demoing easier 
            // this method always returns true
        }

    }
}
