using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRySTALClient
{
    public partial class TimeCard : Form
    {
        string sessionID;
        string username;

        public TimeCard(string _sessionID, string _username)
        {
            InitializeComponent();
            sessionID = _sessionID;
            username = _username;
            this.Text = "TimeCard - " + username;
        }

        private void TimeCard_Load(object sender, EventArgs e)
        {

        }

        private void PunchInBnt_Click(object sender, EventArgs e)
        {
            CRySTALTimeCard.TimeCardServiceClient tcc = new CRySTALClient.CRySTALTimeCard.TimeCardServiceClient();
            tcc.StampShiftStart(this.sessionID, SelectJobRole.GetJobRole());
            tcc.Close();
        }

        private void PunchOutBnt_Click(object sender, EventArgs e)
        {
            CRySTALTimeCard.TimeCardServiceClient tcc = new CRySTALClient.CRySTALTimeCard.TimeCardServiceClient();
            if (tcc.StampShiftEnd(this.sessionID) == false)
            {
                MessageBox.Show("Unable to end shift. No shift in progress. Please see a manager if you feel this is an error");
            }
            tcc.Close();
        }

        private void GetShiftHistory_Click(object sender, EventArgs e)
        {
            CRySTALTimeCard.TimeCardServiceClient tcc = new CRySTALClient.CRySTALTimeCard.TimeCardServiceClient();
            CRySTALTimeCard.ShiftData[] sd = tcc.GetLastWeeksShifts(this.sessionID);
            ShiftHistoryBox.Items.Clear();
            foreach (CRySTALTimeCard.ShiftData shift in sd)
            {
                ShiftHistoryBox.Items.Add(shift.StartTime.ToString() + " - " + shift.EndTime.ToString() + " as " + shift.Role + ". Hours Worked: " + shift.HoursWorked);
            }
            tcc.Close();
        }
    }
}
