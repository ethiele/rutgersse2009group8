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
    public partial class SelectWaiter : Form
    {
        string sessionID;
        public SelectWaiter(string _sessionID)
        {
            InitializeComponent();
            sessionID = _sessionID;
        }
        private CrystalHost.BasicEmployee sel;
        public CrystalHost.BasicEmployee SelEmployee
        {
            get
            {
                return sel;
            }
        }
        CrystalHost.BasicEmployee[] lst;
        private void SelectWaiter_Load(object sender, EventArgs e)
        {
            CrystalHost.HostServiceClient cli = new CRySTALClient.CrystalHost.HostServiceClient();
            lst = cli.GetWaitersOnDuty(sessionID);
            foreach (CrystalHost.BasicEmployee emp in lst)
            {
                listBox1.Items.Add(emp.name + "(" + emp.id.ToString() + ")");
            }
        }

        private void okbnt_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                sel = lst[listBox1.SelectedIndex];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cancelBnt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

       
    }
}
