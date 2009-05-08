using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRySTALManager
{
    /// <summary>
    /// Interaction logic for NewEmployee.xaml
    /// </summary>
    public partial class NewEmployee : Window
    {
        public NewEmployee()
        {
            InitializeComponent();
        }

        public string Emp_FirstName;
        public string Emp_LastName;
        public string Emp_Username;
        public string Emp_Password;
        public List<string> Emp_Roles = new List<string>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Emp_FirstName = FirstName.Text;
            Emp_LastName = LastName.Text;
            Emp_Username = UserName.Text;
            Emp_Password = Password.Text;
            string[] rolelist = Roles.Text.Split(',');
            foreach (string r in rolelist)
            {
                if (r.Trim().Length > 0) Emp_Roles.Add(r.Trim());
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
