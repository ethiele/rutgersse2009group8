using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: If you change the interface name "IManager" here, you must also update the reference to "IManager" in Web.config.
[ServiceContract]
public interface IManager
{
    [OperationContract]
    void DoWork();
}
