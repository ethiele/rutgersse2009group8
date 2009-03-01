using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WFServiceLibrary1
{
	// NOTE: If you change the interface name "IWorkflow1" here, you must also update the reference to "IWorkflow1" in App.config.
	[ServiceContract]
	public interface IWorkflow1
	{

		[OperationContract]
		string GetData(int value);

		// TODO: Add your service operations here
	}
}
