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
    public partial class ModeSelection : Form
    {
        public ModeSelection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                HostView hv = new HostView(frm.SessionID, frm.Username);
                hv.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                WaiterView wv = new WaiterView(frm.SessionID, frm.Username);
                wv.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                TimeCard tc = new TimeCard(frm.SessionID, frm.Username);
                tc.Show();
            }
        }
    }
}
