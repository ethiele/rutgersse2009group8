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
	partial class ReservationWorkflow
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
            this.invokeFoodOrderWorkflow = new System.Workflow.Activities.InvokeWorkflowActivity();
            this.IfFoodOrder = new System.Workflow.Activities.IfElseBranchActivity();
            this.UserBreaksReservation = new System.Workflow.Activities.HandleExternalEventActivity();
            this.ReservationTaken = new System.Workflow.Activities.HandleExternalEventActivity();
            this.IfThereIsAFoodOrder = new System.Workflow.Activities.IfElseActivity();
            this.WaitUntil15BeforeReservation = new System.Workflow.Activities.DelayActivity();
            this.ReservationIsBroken = new System.Workflow.Activities.EventDrivenActivity();
            this.UserTakesReservation = new System.Workflow.Activities.EventDrivenActivity();
            this.cancellationHandlerActivity1 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.WaitForActivity = new System.Workflow.Activities.ListenActivity();
            this.Update_Reservation_DB = new System.Workflow.Activities.CodeActivity();
            // 
            // invokeFoodOrderWorkflow
            // 
            this.invokeFoodOrderWorkflow.Name = "invokeFoodOrderWorkflow";
            // 
            // IfFoodOrder
            // 
            this.IfFoodOrder.Activities.Add(this.invokeFoodOrderWorkflow);
            this.IfFoodOrder.Name = "IfFoodOrder";
            // 
            // UserBreaksReservation
            // 
            this.UserBreaksReservation.Name = "UserBreaksReservation";
            // 
            // ReservationTaken
            // 
            this.ReservationTaken.Name = "ReservationTaken";
            // 
            // IfThereIsAFoodOrder
            // 
            this.IfThereIsAFoodOrder.Activities.Add(this.IfFoodOrder);
            this.IfThereIsAFoodOrder.Name = "IfThereIsAFoodOrder";
            // 
            // WaitUntil15BeforeReservation
            // 
            this.WaitUntil15BeforeReservation.Name = "WaitUntil15BeforeReservation";
            this.WaitUntil15BeforeReservation.TimeoutDuration = System.TimeSpan.Parse("00:00:00");
            // 
            // ReservationIsBroken
            // 
            this.ReservationIsBroken.Activities.Add(this.UserBreaksReservation);
            this.ReservationIsBroken.Name = "ReservationIsBroken";
            // 
            // UserTakesReservation
            // 
            this.UserTakesReservation.Activities.Add(this.WaitUntil15BeforeReservation);
            this.UserTakesReservation.Activities.Add(this.IfThereIsAFoodOrder);
            this.UserTakesReservation.Activities.Add(this.ReservationTaken);
            this.UserTakesReservation.Name = "UserTakesReservation";
            // 
            // cancellationHandlerActivity1
            // 
            this.cancellationHandlerActivity1.Name = "cancellationHandlerActivity1";
            // 
            // WaitForActivity
            // 
            this.WaitForActivity.Activities.Add(this.UserTakesReservation);
            this.WaitForActivity.Activities.Add(this.ReservationIsBroken);
            this.WaitForActivity.Name = "WaitForActivity";
            // 
            // Update_Reservation_DB
            // 
            this.Update_Reservation_DB.Name = "Update_Reservation_DB";
            // 
            // ReservationWorkflow
            // 
            this.Activities.Add(this.Update_Reservation_DB);
            this.Activities.Add(this.WaitForActivity);
            this.Activities.Add(this.cancellationHandlerActivity1);
            this.Name = "ReservationWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private EventDrivenActivity ReservationIsBroken;
        private EventDrivenActivity UserTakesReservation;
        private HandleExternalEventActivity UserBreaksReservation;
        private DelayActivity WaitUntil15BeforeReservation;
        private CodeActivity Update_Reservation_DB;
        private InvokeWorkflowActivity invokeFoodOrderWorkflow;
        private IfElseBranchActivity IfFoodOrder;
        private HandleExternalEventActivity ReservationTaken;
        private IfElseActivity IfThereIsAFoodOrder;
        private CancellationHandlerActivity cancellationHandlerActivity1;
        private ListenActivity WaitForActivity;


    }
}
