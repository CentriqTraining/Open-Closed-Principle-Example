using SalesCommissionCorrect.baseClasses;
using SalesCommissionCorrect.Entities;
using SalesCommissionCorrect.TestData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> _Marketers = null;
        private List<Customer> _Customers = null;
        private List<Registration> _Registrations = null;
        private List<Course> _Courses = null;
        private List<Commission> _Commissions = null;

        public MainWindow()
        {
            try
            {
                InitializeComponent();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GenerateTestData();
            EmployeeGrid.SelectedIndex = 0;
        }

        private void GenerateTestData()
        {
            _Commissions = new List<Commission>();
            _Marketers = TestUtilities.GenerateTestNames<Employee>(12);
            TestUtilities.AssignTierLevel(_Marketers, 2, 3, 3, 2, 2);

            _Courses = TestUtilities.CreateCourses(50);

            _Customers = TestUtilities.GenerateTestNames<Customer>(600);
            _Registrations = TestUtilities.CreateRegistrations(_Marketers, _Customers, _Courses, 300);
            EmployeeGrid.DataContext = _Marketers;
            CommissionGrid.DataContext = _Commissions;
        }

        private void EmployeeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RegistrationGrid.DataContext = null;
            var grid = sender as DataGrid;
            var item = grid.SelectedItem as Employee;
            if (item != null)
            {
                var sales = _Registrations.Where(emp => emp.Marketer.ID == item.ID).ToList();
                RegistrationGrid.DataContext = sales;

                var commissions = _Commissions.Where(emp => emp.Registration.Marketer.ID == item.ID).ToList();
                if (commissions.Count() > 0)
                {
                    CommissionGrid.DataContext = commissions;
                }
                else
                    CommissionGrid.DataContext = null;
            }
        }

        private void cmdCalculate_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var item in _Registrations)
            {
                var tierLevel = Enum.GetName(typeof(TierLevel), (TierLevel)item.Marketer.CommissionTierLevel);

                var Proccessor = IoCManager.Current.FetchDependency<CommissionProcessor>(tierLevel);
                Proccessor.Execute(item, _Registrations, _Commissions);
            }
            sw.Stop();
            Debug.WriteLine($"Commission calculated Correctly - {sw.Elapsed}");
            var selitem = EmployeeGrid.SelectedItem as Employee;
            if (selitem != null)
            {
                var commissions = _Commissions.Where(emp => emp.Registration.Marketer.ID == selitem.ID).ToList();
                if (commissions.Count() > 0)
                {
                    CommissionGrid.DataContext = commissions;
                }
                else
                    CommissionGrid.DataContext = null;
            }
        }
    }
}
