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
    /// Interaction logic for ShowBill.xaml
    /// </summary>
    public partial class ShowBill : Window
    {
        public ShowBill(CRySTALManagerService.Transaction trans)
        {
            InitializeComponent();
            BillID.Content = trans.ID.ToString();
            Waiter.Content = trans.AssignedTo.ToString();
            Table.Content = trans.TableNumber.ToString();

            BillItemList.Items.Clear();
            foreach (var item in trans.Bill.Items)
            {
                BillItemList.Items.Add(item);
            }
            TotalValue.Content = trans.Bill.BillTotal.ToString();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public static void OpenBill(CRySTALManagerService.Transaction trans)
        {
            ShowBill sb = new ShowBill(trans);
            sb.Show();
        }
    }
}
