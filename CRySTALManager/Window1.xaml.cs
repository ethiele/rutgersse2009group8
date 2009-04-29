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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRySTALManager
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();

            if (e.ClickCount == 2)
            {
                if (this.WindowState == WindowState.Normal)
                    this.WindowState = WindowState.Maximized;
                else
                    this.WindowState = WindowState.Normal;
            }
        }


        void Minimize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        void Maximize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        void Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBnt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginBnt_Click(object sender, RoutedEventArgs e)
        {
            CRySTALLogin.LoginServiceClient lsc = new CRySTALManager.CRySTALLogin.LoginServiceClient();
            CRySTALLogin.LoginResponse re = lsc.LoginUser(UsernameTxt.Text, PasswordTxt.Password);
            lsc.Close();
            if (re.LoginSuccess)
            {
                MainWindow mw = new MainWindow(re.SessionID);
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }

        }
	}
}
