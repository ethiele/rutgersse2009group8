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

        private void ViewOrdersSummery()
        {

        }

        private void ViewAllEmployees()
        {
            CRySTALManagerService.ManagerServiceClient msc = new CRySTALManager.CRySTALManagerService.ManagerServiceClient();
            OnDutyList.Items.Clear();
            employeesList.Items.Clear();
            employeeList = msc.GetAllEmployees(sessionID).ToList();
            foreach (var employee in employeeList)
            {
                CRySTALManagerService.BasicEmployee bi = new CRySTALManager.CRySTALManagerService.BasicEmployee();
                bi.name = employee.name;
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
            const int N = 1000;
            double[] x = new double[N];
            double[] y = new double[N];

            for (int i = 0; i < N; i++)
            {
                x[i] = i * 0.1;
                y[i] = Math.Sin(x[i]);
            }

            // Create data sources:
            var xDataSource = x.AsXDataSource();
            var yDataSource = y.AsYDataSource();

            CompositeDataSource compositeDataSource = xDataSource.Join(yDataSource);
            // adding graph to plotter
            for (int i = 0; i < plotter.Children.Count; i++)
            {
                if (plotter.Children[i] is LineGraph) plotter.Children.RemoveAt(i);
            }

           
            plotter.AddLineGraph(compositeDataSource,
                Colors.Goldenrod,
                3,
                "Sine");

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
                ShiftData.Items.Add(new shiftsShow("", shift.EmployeeID, shift.Role, shift.StartTime, shift.EndTime, shift.HoursWorked));
            }
            msc.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShiftsStartDate.SelectedDate = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0));
            ShiftsEndDate.SelectedDate = DateTime.Now;
            TransactStartDate.SelectedDate = DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0));
            TransactEndDate.SelectedDate = DateTime.Now;
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
            if (TransactionHistDisplay.SelectedIndex != 0)
            {
                ShowBill.OpenBill((CRySTALManagerService.Transaction)TransactionHistDisplay.SelectedItem);
            }
        }
    }
}
