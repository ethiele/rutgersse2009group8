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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private string _sessionID;
        public string SessionID
        {
            get
            {
                return _sessionID;
            }
            set
            {
                _sessionID = value;
            }
        }
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        private string[] _roles;
        public string[] Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
            }
        }

        private void LoginBnt_Click(object sender, EventArgs e)
        {
            CRySTALLogin.LoginServiceClient lsc = new CRySTALClient.CRySTALLogin.LoginServiceClient();
            CRySTALLogin.LoginResponse resp = lsc.LoginUser(UsernameTxt.Text, PasswordTxt.Text);
            if (resp.LoginSuccess)
            {
                MessageBox.Show("Login Ok");
                _sessionID = resp.SessionID;
                _roles = resp.Roles;
                _username = UsernameTxt.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Failure");
            }
        }
    }
}
