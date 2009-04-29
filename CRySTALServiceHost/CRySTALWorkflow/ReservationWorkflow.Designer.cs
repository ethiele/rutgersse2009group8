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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.WaitToTryAgain = new System.Workflow.Activities.DelayActivity();
            this.AttemptToReserveTable = new System.Workflow.Activities.CodeActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.TryToReserveTable = new System.Workflow.Activities.WhileActivity();
            this.WaitUntilTimeToReserveTable = new System.Workflow.Activities.DelayActivity();
            this.handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.HoldTableTime = new System.Workflow.Activities.EventDrivenActivity();
            this.ReservationCanceld = new System.Workflow.Activities.EventDrivenActivity();
            this.WaitforCancelOrStartTime = new System.Workflow.Activities.ListenActivity();
            this.SetupReservation = new System.Workflow.Activities.CodeActivity();
            // 
            // WaitToTryAgain
            // 
            this.WaitToTryAgain.Name = "WaitToTryAgain";
            this.WaitToTryAgain.TimeoutDuration = System.TimeSpan.Parse("00:01:00");
            // 
            // AttemptToReserveTable
            // 
            this.AttemptToReserveTable.Name = "AttemptToReserveTable";
            this.AttemptToReserveTable.ExecuteCode += new System.EventHandler(this.TryToMarkTableAsReserved);
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.AttemptToReserveTable);
            this.sequenceActivity1.Activities.Add(this.WaitToTryAgain);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // TryToReserveTable
            // 
            this.TryToReserveTable.Activities.Add(this.sequenceActivity1);
            ruleconditionreference1.ConditionName = "Condition1";
            this.TryToReserveTable.Condition = ruleconditionreference1;
            this.TryToReserveTable.Name = "TryToReserveTable";
            // 
            // WaitUntilTimeToReserveTable
            // 
            this.WaitUntilTimeToReserveTable.Name = "WaitUntilTimeToReserveTable";
            this.WaitUntilTimeToReserveTable.TimeoutDuration = System.TimeSpan.Parse("00:00:00");
            this.WaitUntilTimeToReserveTable.InitializeTimeoutDuration += new System.EventHandler(this.ReserveTableDelayInit);
            // 
            // handleExternalEventActivity1
            // 
            this.handleExternalEventActivity1.Enabled = false;
            this.handleExternalEventActivity1.Name = "handleExternalEventActivity1";
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:00");
            // 
            // HoldTableTime
            // 
            this.HoldTableTime.Activities.Add(this.WaitUntilTimeToReserveTable);
            this.HoldTableTime.Activities.Add(this.TryToReserveTable);
            this.HoldTableTime.Name = "HoldTableTime";
            // 
            // ReservationCanceld
            // 
            this.ReservationCanceld.Activities.Add(this.delayActivity1);
            this.ReservationCanceld.Activities.Add(this.handleExternalEventActivity1);
            this.ReservationCanceld.Name = "ReservationCanceld";
            // 
            // WaitforCancelOrStartTime
            // 
            this.WaitforCancelOrStartTime.Activities.Add(this.ReservationCanceld);
            this.WaitforCancelOrStartTime.Activities.Add(this.HoldTableTime);
            this.WaitforCancelOrStartTime.Name = "WaitforCancelOrStartTime";
            // 
            // SetupReservation
            // 
            this.SetupReservation.Name = "SetupReservation";
            this.SetupReservation.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // ReservationWorkflow
            // 
            this.Activities.Add(this.SetupReservation);
            this.Activities.Add(this.WaitforCancelOrStartTime);
            this.Name = "ReservationWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private DelayActivity delayActivity1;
        private DelayActivity WaitToTryAgain;
        private CodeActivity AttemptToReserveTable;
        private SequenceActivity sequenceActivity1;
        private DelayActivity WaitUntilTimeToReserveTable;
        private HandleExternalEventActivity handleExternalEventActivity1;
        private EventDrivenActivity HoldTableTime;
        private EventDrivenActivity ReservationCanceld;
        private ListenActivity WaitforCancelOrStartTime;
        private WhileActivity TryToReserveTable;
        private CodeActivity SetupReservation;









    }
}
