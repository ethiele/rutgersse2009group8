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
    public partial class SelectJobRole : Form
    {
        public SelectJobRole()
        {
            InitializeComponent();
        }

        public string selectedJobRole = "";

        private void button1_Click(object sender, EventArgs e)
        {
            selectedJobRole = "BusBoy";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedJobRole = "Waiter";
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedJobRole = "Host";
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectedJobRole = "Cook";
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            selectedJobRole = "Manager";
            this.Close();
        }

        public static string GetJobRole()
        {
            SelectJobRole sjr = new SelectJobRole();
            sjr.ShowDialog();
            return sjr.selectedJobRole;
        }
    }
}
