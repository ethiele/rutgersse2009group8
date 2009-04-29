using System;
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
            this.ChcekPaid = new System.Workflow.Activities.HandleExternalEventActivity();
            this.PriceAdjust = new System.Workflow.Activities.HandleExternalEventActivity();
            this.invokeOrderWorkflow = new System.Workflow.Activities.InvokeWorkflowActivity();
            this.FoodOrder = new System.Workflow.Activities.HandleExternalEventActivity();
            this.CheckRequested = new System.Workflow.Activities.HandleExternalEventActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.PayDispute = new System.Workflow.Activities.EventDrivenActivity();
            this.FoodWillBeOrdered = new System.Workflow.Activities.EventDrivenActivity();
            this.CheckWillBeRequested = new System.Workflow.Activities.EventDrivenActivity();
            this.WaitForUserResp = new System.Workflow.Activities.ListenActivity();
            this.WaitForUserAction = new System.Workflow.Activities.ListenActivity();
            this.ReadyForUse = new System.Workflow.Activities.HandleExternalEventActivity();
            this.Cleaning = new System.Workflow.Activities.HandleExternalEventActivity();
            this.TableIsDirty = new System.Workflow.Activities.CallExternalMethodActivity();
            this.WhileCheckNotPaid = new System.Workflow.Activities.WhileActivity();
            this.ChcekDelivered = new System.Workflow.Activities.HandleExternalEventActivity();
            this.WhileCheckNotRequested = new System.Workflow.Activities.WhileActivity();
            this.Update_Table_Database = new System.Workflow.Activities.CodeActivity();
            // 
            // ChcekPaid
            // 
            this.ChcekPaid.Name = "ChcekPaid";
            // 
            // PriceAdjust
            // 
            this.PriceAdjust.Name = "PriceAdjust";
            // 
            // invokeOrderWorkflow
            // 
            this.invokeOrderWorkflow.Name = "invokeOrderWorkflow";
            // 
            // FoodOrder
            // 
            this.FoodOrder.Name = "FoodOrder";
            // 
            // CheckRequested
            // 
            this.CheckRequested.Name = "CheckRequested";
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.ChcekPaid);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // PayDispute
            // 
            this.PayDispute.Activities.Add(this.PriceAdjust);
            this.PayDispute.Name = "PayDispute";
            // 
            // FoodWillBeOrdered
            // 
            this.FoodWillBeOrdered.Activities.Add(this.FoodOrder);
            this.FoodWillBeOrdered.Activities.Add(this.invokeOrderWorkflow);
            this.FoodWillBeOrdered.Name = "FoodWillBeOrdered";
            // 
            // CheckWillBeRequested
            // 
            this.CheckWillBeRequested.Activities.Add(this.CheckRequested);
            this.CheckWillBeRequested.Name = "CheckWillBeRequested";
            // 
            // WaitForUserResp
            // 
            this.WaitForUserResp.Activities.Add(this.PayDispute);
            this.WaitForUserResp.Activities.Add(this.eventDrivenActivity2);
            this.WaitForUserResp.Name = "WaitForUserResp";
            // 
            // WaitForUserAction
            // 
            this.WaitForUserAction.Activities.Add(this.CheckWillBeRequested);
            this.WaitForUserAction.Activities.Add(this.FoodWillBeOrdered);
            this.WaitForUserAction.Name = "WaitForUserAction";
            // 
            // ReadyForUse
            // 
            this.ReadyForUse.Name = "ReadyForUse";
            // 
            // Cleaning
            // 
            this.Cleaning.Name = "Cleaning";
            // 
            // TableIsDirty
            // 
            this.TableIsDirty.Name = "TableIsDirty";
            // 
            // WhileCheckNotPaid
            // 
            this.WhileCheckNotPaid.Activities.Add(this.WaitForUserResp);
            this.WhileCheckNotPaid.Condition = null;
            this.WhileCheckNotPaid.Name = "WhileCheckNotPaid";
            // 
            // ChcekDelivered
            // 
            this.ChcekDelivered.Name = "ChcekDelivered";
            // 
            // WhileCheckNotRequested
            // 
            this.WhileCheckNotRequested.Activities.Add(this.WaitForUserAction);
            this.WhileCheckNotRequested.Condition = null;
            this.WhileCheckNotRequested.Name = "WhileCheckNotRequested";
            // 
            // Update_Table_Database
            // 
            this.Update_Table_Database.Name = "Update_Table_Database";
            // 
            // CustomerWorkflow
            // 
            this.Activities.Add(this.Update_Table_Database);
            this.Activities.Add(this.WhileCheckNotRequested);
            this.Activities.Add(this.ChcekDelivered);
            this.Activities.Add(this.WhileCheckNotPaid);
            this.Activities.Add(this.TableIsDirty);
            this.Activities.Add(this.Cleaning);
            this.Activities.Add(this.ReadyForUse);
            this.Name = "CustomerWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private InvokeWorkflowActivity invokeOrderWorkflow;
        private HandleExternalEventActivity FoodOrder;
        private HandleExternalEventActivity CheckRequested;
        private EventDrivenActivity FoodWillBeOrdered;
        private EventDrivenActivity CheckWillBeRequested;
        private ListenActivity WaitForUserAction;
        private WhileActivity WhileCheckNotRequested;
        private HandleExternalEventActivity ChcekPaid;
        private HandleExternalEventActivity PriceAdjust;
        private EventDrivenActivity eventDrivenActivity2;
        private EventDrivenActivity PayDispute;
        private ListenActivity WaitForUserResp;
        private HandleExternalEventActivity ReadyForUse;
        private HandleExternalEventActivity Cleaning;
        private CallExternalMethodActivity TableIsDirty;
        private WhileActivity WhileCheckNotPaid;
        private HandleExternalEventActivity ChcekDelivered;
        private CodeActivity Update_Table_Database;

    }
}
