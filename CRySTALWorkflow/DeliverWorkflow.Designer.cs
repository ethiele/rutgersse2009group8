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
	partial class DeliverWorkflow
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
            this.invokeDeliverWorkflow = new System.Workflow.Activities.InvokeWorkflowActivity();
            this.ItemFixed = new System.Workflow.Activities.HandleExternalEventActivity();
            this.Returned = new System.Workflow.Activities.HandleExternalEventActivity();
            this.ItemDelivered = new System.Workflow.Activities.HandleExternalEventActivity();
            this.OrderReturned = new System.Workflow.Activities.EventDrivenActivity();
            this.Delivered = new System.Workflow.Activities.EventDrivenActivity();
            this.WaitForDeliveryReturn = new System.Workflow.Activities.ListenActivity();
            this.OutForDelivery = new System.Workflow.Activities.HandleExternalEventActivity();
            // 
            // invokeDeliverWorkflow
            // 
            this.invokeDeliverWorkflow.Name = "invokeDeliverWorkflow";
            // 
            // ItemFixed
            // 
            this.ItemFixed.Name = "ItemFixed";
            // 
            // Returned
            // 
            this.Returned.Name = "Returned";
            // 
            // ItemDelivered
            // 
            this.ItemDelivered.Name = "ItemDelivered";
            // 
            // OrderReturned
            // 
            this.OrderReturned.Activities.Add(this.Returned);
            this.OrderReturned.Activities.Add(this.ItemFixed);
            this.OrderReturned.Activities.Add(this.invokeDeliverWorkflow);
            this.OrderReturned.Name = "OrderReturned";
            // 
            // Delivered
            // 
            this.Delivered.Activities.Add(this.ItemDelivered);
            this.Delivered.Name = "Delivered";
            // 
            // WaitForDeliveryReturn
            // 
            this.WaitForDeliveryReturn.Activities.Add(this.Delivered);
            this.WaitForDeliveryReturn.Activities.Add(this.OrderReturned);
            this.WaitForDeliveryReturn.Name = "WaitForDeliveryReturn";
            // 
            // OutForDelivery
            // 
            this.OutForDelivery.Name = "OutForDelivery";
            // 
            // DeliverWorkflow
            // 
            this.Activities.Add(this.OutForDelivery);
            this.Activities.Add(this.WaitForDeliveryReturn);
            this.Name = "DeliverWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private HandleExternalEventActivity ItemFixed;
        private HandleExternalEventActivity Returned;
        private HandleExternalEventActivity ItemDelivered;
        private EventDrivenActivity OrderReturned;
        private EventDrivenActivity Delivered;
        private ListenActivity WaitForDeliveryReturn;
        private InvokeWorkflowActivity invokeDeliverWorkflow;
        private HandleExternalEventActivity OutForDelivery;

    }
}
