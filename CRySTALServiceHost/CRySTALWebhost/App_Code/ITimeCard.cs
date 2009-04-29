using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: If you change the interface name "ITimeCard" here, you must also update the reference to "ITimeCard" in Web.config.
[ServiceContract]
public interface ITimeCard
{
    [OperationContract]
    void DoWork();
}
