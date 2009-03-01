using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace WFServiceLibrary1
{
	partial class Workflow1
	{
		#region Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
			this.CanModifyActivities = true;
			System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
			System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
			System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
			System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
			System.Workflow.Activities.TypedOperationInfo typedoperationinfo1 = new System.Workflow.Activities.TypedOperationInfo();
			System.Workflow.Activities.WorkflowServiceAttributes workflowserviceattributes1 = new System.Workflow.Activities.WorkflowServiceAttributes();
			this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
			this.receiveActivity1 = new System.Workflow.Activities.ReceiveActivity();
			this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
			this.stateActivity1 = new System.Workflow.Activities.StateActivity();
			this.Workflow1InitialState = new System.Workflow.Activities.StateActivity();
			// 
			// setStateActivity1
			// 
			this.setStateActivity1.Name = "setStateActivity1";
			this.setStateActivity1.TargetStateName = "stateActivity1";
			// 
			// receiveActivity1
			//
			this.receiveActivity1.CanCreateInstance = true; 
			this.receiveActivity1.Name = "receiveActivity1";
			activitybind1.Name = "Workflow1";
			activitybind1.Path = "ReturnValue";
			workflowparameterbinding1.ParameterName = "(ReturnValue)";
			workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
			activitybind2.Name = "Workflow1";
			activitybind2.Path = "InputValue";
			workflowparameterbinding2.ParameterName = "value";
			workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
			this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding1);
			this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding2);
			typedoperationinfo1.ContractType = typeof(WFServiceLibrary1.IWorkflow1);
			typedoperationinfo1.Name = "GetData";
			this.receiveActivity1.ServiceOperationInfo = typedoperationinfo1;
			// 
			// eventDrivenActivity1
			// 
			this.eventDrivenActivity1.Activities.Add(this.receiveActivity1);
			this.eventDrivenActivity1.Activities.Add(this.setStateActivity1);
			this.eventDrivenActivity1.Name = "eventDrivenActivity1";
			// 
			// stateActivity1
			// 
			this.stateActivity1.Name = "stateActivity1";
			// 
			// Workflow1InitialState
			// 
			this.Workflow1InitialState.Activities.Add(this.eventDrivenActivity1);
			this.Workflow1InitialState.Name = "Workflow1InitialState";
			workflowserviceattributes1.ConfigurationName = "Workflow1";
			workflowserviceattributes1.Name = "Workflow1";
			// 
			// Workflow1
			// 
			this.Activities.Add(this.Workflow1InitialState);
			this.Activities.Add(this.stateActivity1);
			this.CompletedStateName = "stateActivity1";
			this.DynamicUpdateCondition = null;
			this.InitialStateName = "Workflow1InitialState";
			this.Name = "Workflow1";
			this.SetValue(System.Workflow.Activities.ReceiveActivity.WorkflowServiceAttributesProperty, workflowserviceattributes1);
			this.CanModifyActivities = false;

		}

		#endregion

		private SetStateActivity setStateActivity1;
		private ReceiveActivity receiveActivity1;
		private EventDrivenActivity eventDrivenActivity1;
		private StateActivity stateActivity1;
		private StateActivity Workflow1InitialState;



	}
}
