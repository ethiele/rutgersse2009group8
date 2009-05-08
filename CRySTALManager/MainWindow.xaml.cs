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
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay.PointMarkers;
using System.Reflection;

namespace CRySTALManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sessionID = "";
        public MainWindow(string _sessionID)
        {
            InitializeComponent();
            sessionID = _sessionID;
        }

        void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        public List<CRySTALManagerService.BasicEmployee> employeesOnDuty = new List<CRySTALManagerService.BasicEmployee>();

        List<CRySTALManagerService.EmployeeData> employeeList = new List<CRySTALManager.CRySTALManagerService.EmployeeData>();

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.OriginalSource == tabControl1)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    ViewOnDuty();
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    
                   
                }
                else if (tabControl1.SelectedIndex == 4)
                {
                    LoadMenus();
                }
                else if (tabControl1.SelectedIndex == 6)
                {
                    ViewOrderHistory();
                }
                else if (tabControl1.SelectedIndex == 5)
                {
                    ViewAllEmployees();
                }
                else if (tabControl1.SelectedIndex == 7)
                {
                    ViewOrdersSummery();
                }
            }
        }

        private void LoadMenus()
        {
            CRySTALMenu.MenuServiceClient msc = new CRySTALManager.CRySTALMenu.MenuServiceClient();
            List<string> menus = msc.getMenuNames().ToList();
            MenuList.Items.Clear();
            foreach (string menu in menus)
            {
                MenuList.Items.Add(menu);
            }
        }

        private void ViewOrdersSummery()
        {

        }

        private void ViewAllEmployees()
        {
            CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
            employeesList.Items.Clear();
            employeeList = msc.GetAllEmployees(sessionID).ToList();
            foreach (var employee in employeeList)
            {
                CRySTALManagerService.BasicEmployee bi = new CRySTALManager.CRySTALManagerService.BasicEmployee();
                bi.name = employee.name;
                bi.username = employee.username;
                bi.id = employee.id;
                bi.role = "";
                foreach (var role in employee.roles)
                {
                    bi.role += role + ", ";
                }
                employeesList.Items.Add(bi);
            }
            msc.Close();
        }

        private void ViewOrderHistory()
        {
            // Prepare data in arrays
            // int N = 1000;
            
            CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
            double[] income = msc.GetStatistics(sessionID, CRySTALManager.CRySTALManagerService.StatObject.Income, CRySTALManager.CRySTALManagerService.StatType.ForEachDay, 0, DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0)), DateTime.Now);
            double[] payrole = msc.GetStatistics(sessionID, CRySTALManager.CRySTALManagerService.StatObject.PayroleExpence, CRySTALManager.CRySTALManagerService.StatType.ForEachDay, 0, DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0)), DateTime.Now);
            msc.Close();
            //double[] x = new double[y.Length];
            //for (int i = 0; i < y.Length; i++)
            //{
            //    x[i] = i;
            //}

            //// Create data sources:
            //var xDataSource = x.AsXDataSource();
            //var yDataSource = y.AsYDataSource();

            //CompositeDataSource compositeDataSource = xDataSource.Join(yDataSource);
            //// adding graph to plotter
            for (int i = 0; i < plotter.Children.Count; i++)
            {
                if (plotter.Children[i] is LineGraph) plotter.Children.RemoveAt(i);
            }
            AddListToGraph(income, "Income", Colors.Green);
            AddListToGraph(payrole, "Payrole Expence", Colors.Red);
            
            

            // Force evertyhing plotted to be visible
            plotter.FitToView();
        }

        private void AddListToGraph(double[] y, string lineName, Color color)
        {
            double[] x = new double[y.Length];
            for (int i = 0; i < y.Length; i++)
            {
                x[i] = i;
            }

            // Create data sources:
            var xDataSource = x.AsXDataSource();
            var yDataSource = y.AsYDataSource();

            CompositeDataSource compositeDataSource = xDataSource.Join(yDataSource);
            // adding graph to plotter
            
            plotter.AddLineGraph(compositeDataSource,
                color,
                3,
                lineName);

            // Force evertyhing plotted to be visible
            plotter.FitToView();
        }

        private void ViewOnDuty()
        {
            CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
            employeesOnDuty.Clear();
            OnDutyList.Items.Clear();
            employeesOnDuty.AddRange(msc.GetAllEmployeesOnDuty(sessionID));
            foreach (var employee in employeesOnDuty)
            {
                OnDutyList.Items.Add(employee);
            }
            msc.Close();
        }

        private void ShowShifts_Click(object sender, RoutedEventArgs e)
        {
            CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
            var shifts = msc.GetShiftsForEmployees(sessionID, ShiftsStartDate.SelectedDate.Value, ShiftsEndDate.SelectedDate.Value);
            ShiftData.Items.Clear();
            foreach (var shift in shifts)
            {
                ShiftData.Items.Add(new shiftsShow(GetNameFromEID(shift.EmployeeID), shift.ShiftID, shift.Role, shift.StartTime, shift.EndTime, shift.HoursWorked, shift.EmployeeID));
            }
            msc.Close();
        }

        private string GetNameFromEID(int employeeID)
        {
            return (from p in employeeList where p.id == employeeID select p.name).First();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShiftsStartDate.SelectedDate = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0));
            ShiftsEndDate.SelectedDate = DateTime.Now;
            TransactStartDate.SelectedDate = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0));
            TransactEndDate.SelectedDate = DateTime.Now;
            PayroleStart.SelectedDate = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0));
            PayroleEnd.SelectedDate = DateTime.Now;
            OrderSumStart.SelectedDate = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0));
            OrderSumEnd.SelectedDate = DateTime.Now;
            CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
            employeesList.Items.Clear();
            employeeList = msc.GetAllEmployees(sessionID).ToList();
            msc.Close();
        }

        private void ShowTransactions_Click(object sender, RoutedEventArgs e)
        {
            CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
            List<CRySTALManagerService.Transaction> trans = msc.GetTransactions(sessionID, TransactStartDate.SelectedDate.Value, TransactEndDate.SelectedDate.Value).ToList();
            TransactionHistDisplay.Items.Clear();
            foreach (var t in trans)
            {
                TransactionHistDisplay.Items.Add(t);
            }
        }

        private void TransactionHistDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TransactionHistDisplay.SelectedIndex > -1)
            {
                ShowBill.OpenBill((CRySTALManagerService.Transaction)TransactionHistDisplay.SelectedItem);
            }
        }

        private void ShiftData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditShift();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NewShift();
        }

        void NewShift()
        {
                EditShift es = new EditShift(new shiftsShow(
                    "", 0, "", DateTime.Now, DateTime.Now, 0, 0), employeeList);
                if (es.ShowDialog().Value == true)
                {
                    shiftsShow ss = es.Shift;
                    CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
                    msc.AddShift(sessionID, ss.employeeId, ss.role, ss.startTime, ss.endTime.Value);
                    msc.Close();
                }

        }
        void EditShift()
        {
            if (ShiftData.SelectedIndex > -1)
            {
                EditShift es = new EditShift((shiftsShow)ShiftData.SelectedItem, employeeList);
                if (es.ShowDialog().Value == true)
                {
                    shiftsShow ss = es.Shift;
                    CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
                    msc.EditShift(sessionID, ss.id, ss.employeeId, ss.role, ss.startTime, ss.endTime.Value);
                    msc.Close();
                }
            }
        }

        void RemoveShift()
        {
            if (ShiftData.SelectedIndex > -1)
            {
                  CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
                  msc.RemoveShift(sessionID, ((shiftsShow)(ShiftData.SelectedItem)).id);
                  msc.Close();
                
            }
        }

        private void EditShiftContextMenu_Click(object sender, RoutedEventArgs e)
        {
            EditShift();
        }

        private void RemoveShiftContextMenu_Click(object sender, RoutedEventArgs e)
        {
            RemoveShift();
        }

        private void AddUsr_Click(object sender, RoutedEventArgs e)
        {
            NewEmployee ne = new NewEmployee();
            if (ne.ShowDialog().Value)
            {
                CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
                msc.AddUser(sessionID, ne.Emp_Username, ne.Emp_Password, ne.Emp_FirstName, ne.Emp_LastName, ne.Emp_Roles.ToArray());
                msc.Close();
                ViewAllEmployees();
            }
        }

        private void RemoveUsr_Click(object sender, RoutedEventArgs e)
        {
            if (employeesList.SelectedIndex != -1)
            {
                CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
                msc.RemoveUser( sessionID, ((CRySTALManagerService.BasicEmployee)employeesList.SelectedItem).id);
                msc.Close();
                ViewAllEmployees();
            }
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (employeesList.SelectedIndex != -1)
            {
                string ch = TextInputDialog.GetText("New Password:");
                if (!string.IsNullOrEmpty(ch))
                {
                    CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
                    msc.ChangeUserPassword(sessionID, ((CRySTALManagerService.BasicEmployee)employeesList.SelectedItem).id, ch);
                    msc.Close(); 
                }
            }
        }

        private void PrintShifts_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                pd.PrintVisual(this.ShiftData, "Shifts");
            }
        }

        private void ShowPayrole_Click(object sender, RoutedEventArgs e)
        {
            CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
            CRySTALManagerService.PayroleReport pr = msc.GetPayroleReport(sessionID, PayroleStart.SelectedDate.Value, PayroleEnd.SelectedDate.Value);
            PayroleStack.Children.Clear();

            Label lbl = new Label();
            lbl.Content = "Payroll for " + PayroleStart.SelectedDate.Value.ToShortDateString() + " to " + PayroleEnd.SelectedDate.Value.ToShortDateString();
            lbl.HorizontalAlignment = HorizontalAlignment.Center;
            lbl.FontSize *= 1.5;
            PayroleStack.Children.Add(lbl);
            foreach (var employee in pr.Employees)
            {
                Label empname = new Label();
                empname.Content = employee.EmployeeName + " (" + employee.EmployeeID + ")";
                ListView lv = CreateListViewForPayrole();

                foreach (var role in employee.Roles)
                {
                    lv.Items.Add(role);
                }
                Label emptotal = new Label();
                emptotal.FontSize *= 1.5;
                emptotal.HorizontalAlignment = HorizontalAlignment.Right;
                emptotal.Content = "Employee Total: " + employee.TotalPayment.ToString("C");
                
                PayroleStack.Children.Add(empname);
                PayroleStack.Children.Add(lv);
                PayroleStack.Children.Add(emptotal);

            }
            Label payroleTotal = new Label();
            payroleTotal.FontSize *= 2;
            payroleTotal.HorizontalAlignment = HorizontalAlignment.Right;
            payroleTotal.Content = "Payrole Total: " + pr.TotalPayout.ToString("C");
            PayroleStack.Children.Add(payroleTotal);

            msc.Close();
        }

        private ListView CreateListViewForPayrole()
        {
            ListView lv = new ListView();
            GridView gv = new GridView();

            GridViewColumn newCol = new GridViewColumn();
            newCol.Header = "Role";
            newCol.DisplayMemberBinding = new Binding("RoleName");
            gv.Columns.Add(newCol);

            newCol = new GridViewColumn();
            newCol.Header = "Hours";
            newCol.DisplayMemberBinding = new Binding("HoursWorked");
            gv.Columns.Add(newCol);

            newCol = new GridViewColumn();
            newCol.Header = "Rate";
            newCol.DisplayMemberBinding = new Binding("Rate");
            gv.Columns.Add(newCol);

            newCol = new GridViewColumn();
            newCol.Header = "Pay";
            newCol.DisplayMemberBinding = new Binding("TotalPayment");
            gv.Columns.Add(newCol);

            lv.View = gv;
            return lv;
        }

        private void ShowMenu_Click(object sender, RoutedEventArgs e)
        {
            if (MenuList.SelectedIndex != -1)
            {
                string selMenu = (string)MenuList.SelectedItem;
                CRySTALMenu.MenuServiceClient msc = new CRySTALManager.CRySTALMenu.MenuServiceClient();
                List<string> cats = msc.getMenuCategoriesFromMenu(selMenu).ToList();
                List<CRySTALMenu.MenuItem> mitems = msc.getAllMenuItemsFromMenu(selMenu).ToList();
                MenuStack.Children.Clear();
                foreach (string cat in cats)
                {
                    Label catName = new Label();
                    catName.Content = cat;
                    ListView lv = CreateListviewForMenu();
                    var catItems = from p in mitems where p.category1 == cat select p;
                    foreach (var citem in catItems)
                    {
                        lv.Items.Add(citem);
                    }
                    MenuStack.Children.Add(catName);
                    MenuStack.Children.Add(lv);

                        
                }
            }
        }

        private ListView CreateListviewForMenu()
        {
            ListView lv = new ListView();
            GridView gv = new GridView();

            GridViewColumn newCol = new GridViewColumn();
            newCol.Header = "Name";
            newCol.DisplayMemberBinding = new Binding("name");
            gv.Columns.Add(newCol);

            newCol = new GridViewColumn();
            newCol.Header = "Catagory";
            newCol.DisplayMemberBinding = new Binding("category1");
            gv.Columns.Add(newCol);

            newCol = new GridViewColumn();
            newCol.Header = "Subcatagory";
            newCol.DisplayMemberBinding = new Binding("subcategory1");
            gv.Columns.Add(newCol);

            newCol = new GridViewColumn();
            newCol.Header = "Price";
            newCol.DisplayMemberBinding = new Binding("price");
            gv.Columns.Add(newCol);

            newCol = new GridViewColumn();
            newCol.Header = "Served During";
            newCol.DisplayMemberBinding = new Binding("servedDuring");
            gv.Columns.Add(newCol);

            lv.View = gv;
            return lv;
        }

        private void NewMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowOrderSum_Click(object sender, RoutedEventArgs e)
        {
            CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
            var topSellers = msc.GetTopSellers(sessionID, OrderSumStart.SelectedDate.Value, OrderSumEnd.SelectedDate.Value, 10);
            OrderSumDisplay.Items.Clear();
            foreach (var topseller in topSellers)
            {
                OrderSumDisplay.Items.Add(topseller);
            }
            msc.Close();
        }

        private void printPayroll_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                pd.PrintVisual(this.PayroleStack, "Payroll");
            }
        }
    }
}
