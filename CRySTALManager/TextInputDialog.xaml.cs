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
    /// Interaction logic for TextInput.xaml
    /// </summary>
    public partial class TextInputDialog : Window
    {
        public TextInputDialog()
        {
            InitializeComponent();
        }

        private void OkBnt_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
        public static string GetText(string question)
        {
            TextInputDialog ti = new TextInputDialog();
            ti.DispText.Content = question;
            if (ti.ShowDialog().Value)
            {
                return ti.Resp.Text;
            }
            return "";
        }
    }
}
