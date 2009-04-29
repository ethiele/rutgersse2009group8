using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace CRySTALWorkflow
{
	public sealed partial class ReservationWorkflow: SequentialWorkflowActivity
	{
		public ReservationWorkflow()
		{
			InitializeComponent();
		}

        public bool HasTableLocked = false;

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
           
        }

        public static DependencyProperty ReservationTimeProperty = DependencyProperty.Register("ReservationTime", typeof(DateTime), typeof(ReservationWorkflow));

        [DescriptionAttribute("ReservationTime")]
        [CategoryAttribute("ReservationTime Category")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public DateTime ReservationTime
        {
            get
            {
                return ((DateTime)(base.GetValue(ReservationWorkflow.ReservationTimeProperty)));
            }
            set
            {
                base.SetValue(ReservationWorkflow.ReservationTimeProperty, value);
            }
        }

        public static DependencyProperty ReservationNameProperty = DependencyProperty.Register("ReservationName", typeof(string), typeof(ReservationWorkflow));

        [DescriptionAttribute("ReservationName")]
        [CategoryAttribute("ReservationName Category")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public string ReservationName
        {
            get
            {
                return ((string)(base.GetValue(ReservationWorkflow.ReservationNameProperty)));
            }
            set
            {
                base.SetValue(ReservationWorkflow.ReservationNameProperty, value);
            }
        }

        public static DependencyProperty ReservationTableProperty = DependencyProperty.Register("ReservationTable", typeof(int), typeof(ReservationWorkflow));

        [DescriptionAttribute("ReservationTable")]
        [CategoryAttribute("ReservationTable Category")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public int ReservationTable
        {
            get
            {
                return ((int)(base.GetValue(ReservationWorkflow.ReservationTableProperty)));
            }
            set
            {
                base.SetValue(ReservationWorkflow.ReservationTableProperty, value);
            }
        }

        private void ReserveTableDelayInit(object sender, EventArgs e)
        {
            int MinBeforeReservationToReserveTable = 60;
            if (ReservationTime.Subtract(DateTime.Now).TotalMinutes < MinBeforeReservationToReserveTable)
            {
                WaitUntilTimeToReserveTable.TimeoutDuration = new TimeSpan(0);
            }
            else
            {
                WaitUntilTimeToReserveTable.TimeoutDuration =
                    ReservationTime.Subtract(DateTime.Now).Subtract(new TimeSpan(0, MinBeforeReservationToReserveTable, 0));
            }
        }

        private void TryToMarkTableAsReserved(object sender, EventArgs e)
        {

        }
	}

}
