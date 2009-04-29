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
    public partial class HostView : Form
    {
        string sessionID;
        string username;

        public HostView(string _sessionID, string _username)
        {
            InitializeComponent();
            sessionID = _sessionID;
            username = _username;
        }

        List<Button> tableButtons = new List<Button>();

        private void HostView_Load(object sender, EventArgs e)
        {
            createSampleTables();
            UpdateView();
            this.Text += username;
        }

        void createSampleTables()
        {
            addBnt(Tbl1);
            addBnt(Tbl2);
            addBnt(Tbl3);
            addBnt(Tbl4);
            addBnt(Tbl5);
            addBnt(Tbl6);
        }
        void addBnt(Button bnt)
        {
            bnt.Click += new EventHandler(bnt_Click);
            tableButtons.Add(bnt);
        }

        void bnt_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as Button).Tag.ToString());
            SelectWaiter sw = new SelectWaiter(sessionID);
            if (sw.ShowDialog() == DialogResult.OK)
            {
                CrystalHost.HostServiceClient cli = new CRySTALClient.CrystalHost.HostServiceClient();
                cli.AssignTableTo(sessionID, id, sw.SelEmployee.id);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateView()
        {
            CrystalHost.HostServiceClient hsc = new CRySTALClient.CrystalHost.HostServiceClient();
            Dictionary<CrystalHost.TableTypes, int[]> tableStatus;
            tableStatus = hsc.GetTables(sessionID);
            foreach (int i in tableStatus[CRySTALClient.CrystalHost.TableTypes.Clean])
            {
                tableButtons[i - 1].BackColor = Color.LightGreen;
            }
            foreach (int i in tableStatus[CRySTALClient.CrystalHost.TableTypes.InUse])
            {
                tableButtons[i - 1].BackColor = Color.LightBlue;
            }
            foreach (int i in tableStatus[CRySTALClient.CrystalHost.TableTypes.Dirty])
            {
                tableButtons[i - 1].BackColor = Color.Red;
            }
            foreach (int i in tableStatus[CRySTALClient.CrystalHost.TableTypes.Cleaning])
            {
                tableButtons[i - 1].BackColor = Color.Orange;
            }
            foreach (int i in tableStatus[CRySTALClient.CrystalHost.TableTypes.CannotBeUsed])
            {
                tableButtons[i - 1].BackColor = Color.Gray;
            }
            hsc.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UpdateView();
        }

        
    }
}
