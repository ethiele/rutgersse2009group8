﻿using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace CRySTALWorkflow
{
	partial class CustomerWorkflow
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.CheckRequested = new System.Workflow.Activities.HandleExternalEventActivity();
            this.AddToBill = new System.Workflow.Activities.HandleExternalEventActivity();
            this.FoodIsRequested = new System.Workflow.Activities.HandleExternalEventActivity();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.CustomerRequestsCheck = new System.Workflow.Activities.EventDrivenActivity();
            this.AddFoodToBill = new System.Workflow.Activities.EventDrivenActivity();
            this.FoodOrderRequest = new System.Workflow.Activities.EventDrivenActivity();
            this.WaitForCustomerInput = new System.Workflow.Activities.ListenActivity();
            this.faultHandlersActivity2 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.cancellationHandlerActivity1 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.CustomerPaied = new System.Workflow.Activities.HandleExternalEventActivity();
            this.OrderLoop = new System.Workflow.Activities.WhileActivity();
            // 
            // CheckRequested
            // 
            this.CheckRequested.EventName = "RequestCheck";
            this.CheckRequested.InterfaceType = typeof(WorkflowLocalService.ICustomerLocalService);
            this.CheckRequested.Name = "CheckRequested";
            this.CheckRequested.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.CheckRequest);
            // 
            // AddToBill
            // 
            this.AddToBill.EventName = "AddFoodOrderToBill";
            this.AddToBill.InterfaceType = typeof(WorkflowLocalService.ICustomerLocalService);
            this.AddToBill.Name = "AddToBill";
            this.AddToBill.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.AddFoodOrderToBill);
            // 
            // FoodIsRequested
            // 
            this.FoodIsRequested.EventName = "PlaceFoodOrder";
            this.FoodIsRequested.InterfaceType = typeof(WorkflowLocalService.ICustomerLocalService);
            this.FoodIsRequested.Name = "FoodIsRequested";
            this.FoodIsRequested.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.AddFoodRequest);
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // CustomerRequestsCheck
            // 
            this.CustomerRequestsCheck.Activities.Add(this.CheckRequested);
            this.CustomerRequestsCheck.Name = "CustomerRequestsCheck";
            // 
            // AddFoodToBill
            // 
            this.AddFoodToBill.Activities.Add(this.AddToBill);
            this.AddFoodToBill.Name = "AddFoodToBill";
            // 
            // FoodOrderRequest
            // 
            this.FoodOrderRequest.Activities.Add(this.FoodIsRequested);
            this.FoodOrderRequest.Name = "FoodOrderRequest";
            // 
            // WaitForCustomerInput
            // 
            this.WaitForCustomerInput.Activities.Add(this.FoodOrderRequest);
            this.WaitForCustomerInput.Activities.Add(this.AddFoodToBill);
            this.WaitForCustomerInput.Activities.Add(this.CustomerRequestsCheck);
            this.WaitForCustomerInput.Activities.Add(this.faultHandlersActivity1);
            this.WaitForCustomerInput.Name = "WaitForCustomerInput";
            // 
            // faultHandlersActivity2
            // 
            this.faultHandlersActivity2.Name = "faultHandlersActivity2";
            // 
            // cancellationHandlerActivity1
            // 
            this.cancellationHandlerActivity1.Name = "cancellationHandlerActivity1";
            // 
            // CustomerPaied
            // 
            this.CustomerPaied.EventName = "OrderPaid";
            this.CustomerPaied.InterfaceType = typeof(WorkflowLocalService.ICustomerLocalService);
            this.CustomerPaied.Name = "CustomerPaied";
            this.CustomerPaied.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.Paied);
            // 
            // OrderLoop
            // 
            this.OrderLoop.Activities.Add(this.WaitForCustomerInput);
            ruleconditionreference1.ConditionName = "Condition1";
            this.OrderLoop.Condition = ruleconditionreference1;
            this.OrderLoop.Name = "OrderLoop";
            // 
            // CustomerWorkflow
            // 
            this.Activities.Add(this.OrderLoop);
            this.Activities.Add(this.CustomerPaied);
            this.Activities.Add(this.cancellationHandlerActivity1);
            this.Activities.Add(this.faultHandlersActivity2);
            this.Name = "CustomerWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private FaultHandlersActivity faultHandlersActivity1;
        private FaultHandlersActivity faultHandlersActivity2;
        private CancellationHandlerActivity cancellationHandlerActivity1;
        private HandleExternalEventActivity CustomerPaied;
        private WhileActivity OrderLoop;
        private HandleExternalEventActivity FoodIsRequested;
        private EventDrivenActivity AddFoodToBill;
        private EventDrivenActivity FoodOrderRequest;
        private ListenActivity WaitForCustomerInput;
        private HandleExternalEventActivity CheckRequested;
        private HandleExternalEventActivity AddToBill;
        private EventDrivenActivity CustomerRequestsCheck;









    }
}
