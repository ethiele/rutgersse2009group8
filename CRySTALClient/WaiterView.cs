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
    public partial class WaiterView : Form
    {
        string sessionID;
        string username;

        public WaiterView(string _sessionID, string _username)
        {
            InitializeComponent();
            sessionID = _sessionID;
            username = _username;
        }

        private void WaiterView_Load(object sender, EventArgs e)
        {

            updateView();
        }
        int[] tbls;
        int[] paymentTbls;
        void updateView()
        {
            listBox1.Items.Clear();
            CRySTALWaiter.WaiterServiceClient wsc = new CRySTALClient.CRySTALWaiter.WaiterServiceClient();
            tbls = wsc.GetCurrentTables(sessionID);
            foreach (int i in tbls)
            {
                listBox1.Items.Add(i);
            }
            paymentTbls = wsc.GetInPaymentTables(sessionID);
            listBox2.Items.Clear();
            foreach (int i in paymentTbls)
            {
                listBox2.Items.Add(i);
            }
            wsc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateView();
        }

        private void RequestCheck_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string bill = "";
                CRySTALWaiter.WaiterServiceClient wc = new CRySTALClient.CRySTALWaiter.WaiterServiceClient();
                CRySTALWaiter.BillItem[] bil = wc.GetReceipt(sessionID, tbls[listBox1.SelectedIndex]);
                wc.Close();
                foreach (CRySTALWaiter.BillItem b in bil)
                {
                    bill += b.ItemName + " " + b.ItemPrice.ToString() + Environment.NewLine;
                }
                MessageBox.Show(bill);
                updateView();
            }
        }

        private void PaiedBnt_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                CRySTALWaiter.WaiterServiceClient wc = new CRySTALClient.CRySTALWaiter.WaiterServiceClient();
                wc.MarkPaied(sessionID, paymentTbls[listBox2.SelectedIndex]);
                wc.Close();
                updateView();
            }
        }

        private void AddItemToBill_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                CreateFoodOrder cfo = new CreateFoodOrder(sessionID);
                if (cfo.ShowDialog() == DialogResult.OK)
                {
                    CRySTALWaiter.FoodOrder fo = cfo.FoodOrder;
                    fo.DeliverToTable = tbls[listBox1.SelectedIndex];
                    CRySTALWaiter.WaiterServiceClient wc = new CRySTALClient.CRySTALWaiter.WaiterServiceClient();
                    wc.AddItemToBill(sessionID, fo);
                    wc.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                CreateFoodOrder cfo = new CreateFoodOrder(sessionID);
                if (cfo.ShowDialog() == DialogResult.OK)
                {
                    CRySTALWaiter.FoodOrder fo = cfo.FoodOrder;
                    fo.DeliverToTable = tbls[listBox1.SelectedIndex];
                    CRySTALWaiter.WaiterServiceClient wc = new CRySTALClient.CRySTALWaiter.WaiterServiceClient();
                    wc.PlaceOrder(sessionID, fo);
                    wc.Close();
                }
            }
        }
    }
}
