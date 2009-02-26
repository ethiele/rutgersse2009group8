using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL.ServiceContracts
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
        LoginResponce LoginUser(string username, string password);
    }
}
