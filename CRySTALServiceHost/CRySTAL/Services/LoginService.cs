using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CRySTAL
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class LoginService : ILoginService
    {
        #region ILoginService Members

        public LoginResponse LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public LoginResponse LoginUserWithID(string terminalName, string terminalPassword, string uservalue)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
