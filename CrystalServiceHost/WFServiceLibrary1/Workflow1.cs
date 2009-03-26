using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace WFServiceLibrary1
{
	public sealed partial class Workflow1 : StateMachineWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

		// These variables are bound to the input and output parameters of the ReceiveActivity.
		private String returnValue;
		private Int32 inputValue;

		public Int32 InputValue
		{
			get{ return inputValue; }
			set{ inputValue = value; }
		}

		public string ReturnValue
		{
			get{ return returnValue; }
			set{ returnValue = value; }
		}
	}
}
