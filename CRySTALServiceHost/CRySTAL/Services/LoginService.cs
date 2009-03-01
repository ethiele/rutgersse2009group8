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

        public LoginResponce LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
