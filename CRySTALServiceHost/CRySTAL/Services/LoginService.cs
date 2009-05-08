// --------------------------------
// <copyright file="LoginService.cs" company="Rutgers Software Engineering (Group 8)">
//     The MIT License
// The MIT License
// Copyright (c) 2009 Edward Thiele (ethiele.com)
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights 
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
// </copyright>
// <author>Edward Thiele (EJ Thiele)</author>
// ---------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using CRySTALDataConnections;

namespace CRySTAL
{
    /// <summary>
    /// Provides an implementation of the ILoginService
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class LoginService : ILoginService
    {
        #region ILoginService Members

        /// <summary>
        /// Attempts to login the user with a username and password
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns></returns>
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

        /// <summary>
        /// Attempts to login the user via a security token such as an RFID tag or smartcard.
        /// Requires the terminal's credentals
        /// </summary>
        /// <param name="terminalName"></param>
        /// <param name="terminalPassword"></param>
        /// <param name="uservalue"></param>
        /// <returns></returns>
        /// <remarks>Not Currently Implmented</remarks>
        public LoginResponse LoginUserWithID(string terminalName, string terminalPassword, string uservalue)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
