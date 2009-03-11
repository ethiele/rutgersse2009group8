using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    [ServiceContract]
    interface ILoginService
    {
        /// <summary>
        /// Attempts to login the user with a username and password
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns></returns>
        /// 
        [OperationContract]
        LoginResponse LoginUser(string username, string password);

        /// <summary>
        /// Attempts to login the user via a security token such as an RFID tag or smartcard.
        /// Requires the terminal's credentals
        /// </summary>
        /// <param name="terminalName"></param>
        /// <param name="terminalPassword"></param>
        /// <param name="uservalue"></param>
        /// <returns></returns>
        [OperationContract]
        LoginResponse LoginUserWithID(string terminalName, string terminalPassword, string uservalue);

    }
}
