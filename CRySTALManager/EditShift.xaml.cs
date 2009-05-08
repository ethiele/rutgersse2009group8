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
    /// Interaction logic for EditShift.xaml
    /// </summary>
    public partial class EditShift : Window
    {
        public EditShift(shiftsShow _shift, List<CRySTALManagerService.EmployeeData> _employeeList)
        {
            InitializeComponent();
            Shift = _shift;
            
            EmployeeList = _employeeList;
            StartDate.SelectedDate = Shift.startTime;
            StartTime.SelectedTime = Shift.startTime.TimeOfDay;
            EndDate.SelectedDate = Shift.endTime;
            EndTime.SelectedTime = Shift.endTime.Value.TimeOfDay;
            RoleTxt.Text = Shift.role;
            EmployeeSelection.Items.Clear();
            foreach (var emp in EmployeeList)
            {
                EmployeeSelection.Items.Add(new EmployeeSelectionClass(emp.name, emp.id));
                if (emp.id == Shift.employeeId)
                {
                    EmployeeSelection.SelectedIndex = EmployeeSelection.Items.Count - 1;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        List<CRySTALManagerService.EmployeeData> EmployeeList;
        public shiftsShow Shift;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Shift.employeeId = ((EmployeeSelectionClass)(EmployeeSelection.SelectedItem)).EmployeeID;
            Shift.role = RoleTxt.Text;
            Shift.startTime = StartDate.SelectedDate.Value;
            Shift.startTime =  Shift.startTime.Add(StartTime.SelectedTime);
            Shift.endTime = EndDate.SelectedDate;
            Shift.endTime = Shift.endTime.Value.Add(EndTime.SelectedTime);
            this.DialogResult = true;
            this.Close();
        }

    }

    public class EmployeeSelectionClass
    {
        public override string ToString()
        {
            return EmployeeName + " (" + EmployeeID + ")";
        }

        public EmployeeSelectionClass(string empName, int id)
        {
            EmployeeName = empName;
            EmployeeID = id;
        }
        public string EmployeeName = "";
        public int EmployeeID = 0;
    }
}
