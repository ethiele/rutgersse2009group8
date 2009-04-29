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
    public partial class CreateFoodOrder : Form
    {
        string sessionID;
        public CreateFoodOrder(string _sessionID)
        {
            InitializeComponent();
            sessionID = _sessionID;
        }

        private List<CRySTALWaiter.ItemOrder> iol = new List<CRySTALClient.CRySTALWaiter.ItemOrder>();
        private CRySTALWaiter.FoodOrder fo = new CRySTALClient.CRySTALWaiter.FoodOrder();
        public CRySTALWaiter.FoodOrder FoodOrder
        {
            get
            {
                return fo;
            }
        }

        private void CreateFoodOrder_Load(object sender, EventArgs e)
        {
            updateCat1();
        }

        string[] cat1;
        void updateCat1()
        {
            CRySTALMenu.MenuServiceClient mc = new CRySTALClient.CRySTALMenu.MenuServiceClient();
            cat1 = mc.getMenuCategories();
            listBox1.Items.Clear();
            foreach (string s in cat1)
            {
                listBox1.Items.Add(s);
            }
            listBox2.Items.Clear();
            mc.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        CRySTALMenu.MenuItem[] itemList;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                List<CRySTALMenu.MenuItem> ml = new List<CRySTALClient.CRySTALMenu.MenuItem>();
                CRySTALMenu.MenuServiceClient mc = new CRySTALClient.CRySTALMenu.MenuServiceClient();
                CRySTALMenu.MenuItem[] lst = mc.getAllMenuItems();
                var fromCat = from p in lst
                              where p.category1 == cat1[listBox1.SelectedIndex]
                              select p;
                itemList = fromCat.ToArray();
                listBox2.Items.Clear();
                foreach (CRySTALMenu.MenuItem mi in itemList)
                {
                    listBox2.Items.Add(mi.name);
                }
            }
        }

        private void PlaceOrder_Click(object sender, EventArgs e)
        {
            fo.FoodOrders = iol.ToArray();
            fo.OrderComment = OrderComment.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelOrder_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddToOrder_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                CRySTALWaiter.ItemOrder io = new CRySTALClient.CRySTALWaiter.ItemOrder();
                io.DeliverToPerson = (int)numericUpDown1.Value;
                io.OrderComment = ItemComment.Text;
                io.productID = itemList[listBox2.SelectedIndex].productID;
                iol.Add(io);
                listBox3.Items.Add(itemList[listBox2.SelectedIndex].name);
            }
        }
    }
}
