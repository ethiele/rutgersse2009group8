using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using CRySTALDataConnections;

namespace CRySTAL
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class LoginService : ILoginService
    {
        #region ILoginService Members

        public LoginResponse LoginUser(string username, string password)
        {

            CRySTALDataConnections.CRySTALDataSet.UsersDataTable usrs;
            CRySTALDataConnections.CRySTALDataSet.RolesDataTable roles;
            CRySTALDataConnections.CRySTALDataSet.SessionsDataTable sessions;
            CRySTALDataConnections.CRySTALDataSetTableAdapters.UsersTableAdapter uta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.UsersTableAdapter();
            CRySTALDataConnections.CRySTALDataSetTableAdapters.RolesTableAdapter rta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.RolesTableAdapter();
            CRySTALDataConnections.CRySTALDataSetTableAdapters.SessionsTableAdapter sta = new CRySTALDataConnections.CRySTALDataSetTableAdapters.SessionsTableAdapter();
            usrs = uta.GetDataByUnPass(username, password);
            
            LoginResponse resp = new LoginResponse();

            resp.LoginSuccess = false;
            if (usrs.Rows.Count > 0)
            {
                roles = rta.GetDataByUserID((int)usrs.Rows[0].ItemArray[0]);
                Guid g = Guid.NewGuid();
                resp.LoginSuccess = true;
                resp.Roles = new List<string>();
                resp.SessionID = g.ToString();
                foreach (CRySTALDataConnections.CRySTALDataSet.RolesRow role in roles.Rows)
                {
                    resp.Roles.Add(role.Role);
                }
                sta.InsertLoginEvent(g, (int)usrs.Rows[0].ItemArray[0], DateTime.Now);

            }
            return resp;
        }

        public LoginResponse LoginUserWithID(string terminalName, string terminalPassword, string uservalue)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
