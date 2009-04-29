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
	partial class OrderWorkflow
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
            this.Rejected = new System.Workflow.Activities.HandleExternalEventActivity();
            this.invokeDeliverWorkflow = new System.Workflow.Activities.InvokeWorkflowActivity();
            this.OrderReady = new System.Workflow.Activities.HandleExternalEventActivity();
            this.OrderIsProcededing = new System.Workflow.Activities.HandleExternalEventActivity();
            this.OrderIsRejected = new System.Workflow.Activities.EventDrivenActivity();
            this.OrderIsAccepted = new System.Workflow.Activities.EventDrivenActivity();
            this.WaitForCook = new System.Workflow.Activities.ListenActivity();
            // 
            // Rejected
            // 
            this.Rejected.Name = "Rejected";
            // 
            // invokeDeliverWorkflow
            // 
            this.invokeDeliverWorkflow.Name = "invokeDeliverWorkflow";
            // 
            // OrderReady
            // 
            this.OrderReady.Name = "OrderReady";
            // 
            // OrderIsProcededing
            // 
            this.OrderIsProcededing.Name = "OrderIsProcededing";
            // 
            // OrderIsRejected
            // 
            this.OrderIsRejected.Activities.Add(this.Rejected);
            this.OrderIsRejected.Name = "OrderIsRejected";
            // 
            // OrderIsAccepted
            // 
            this.OrderIsAccepted.Activities.Add(this.OrderIsProcededing);
            this.OrderIsAccepted.Activities.Add(this.OrderReady);
            this.OrderIsAccepted.Activities.Add(this.invokeDeliverWorkflow);
            this.OrderIsAccepted.Name = "OrderIsAccepted";
            // 
            // WaitForCook
            // 
            this.WaitForCook.Activities.Add(this.OrderIsAccepted);
            this.WaitForCook.Activities.Add(this.OrderIsRejected);
            this.WaitForCook.Name = "WaitForCook";
            // 
            // OrderWorkflow
            // 
            this.Activities.Add(this.WaitForCook);
            this.Name = "OrderWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private HandleExternalEventActivity Rejected;
        private HandleExternalEventActivity OrderIsProcededing;
        private EventDrivenActivity OrderIsRejected;
        private EventDrivenActivity OrderIsAccepted;
        private InvokeWorkflowActivity invokeDeliverWorkflow;
        private HandleExternalEventActivity OrderReady;
        private ListenActivity WaitForCook;

    }
}
