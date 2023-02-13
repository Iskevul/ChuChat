using ChuChat.DB;
using ChuChat.Model;
using System;
using System.Collections.Generic;
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

namespace ChuChat.Pages
{
    public partial class FilterPage : Page
    {
        public List<Department> Departments { get; set; }
        public List<Employee> Employees { get; set; }
        public FilterPage()
        {
            InitializeComponent();
            Departments = DataAccess.GetDepartments();
            Employees = new List<Employee>();
            DataContext = this;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DepartmentCb_Click(object sender, RoutedEventArgs e)
        {
            Employees = new List<Employee>();
            foreach (Department department in Departments)
            {
                //if (department.IsChecked)
                Employees.AddRange(DataAccess.GetEmployees().Where(x => x.DepartmentId == department.Id));
            }
            lvEmployees.ItemsSource = Employees;
            lvEmployees.Items.Refresh();
        }

        private void lvEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedMember = (sender as ListView).SelectedItem as Employee;

            NavigationService.Navigate(new ChatPage(
                new Chatroom
                {
                    EmployeesInChatroom = new List<EmployeesInChatroom>
                {
                    new EmployeesInChatroom {Employee = App.Employee},
                    new EmployeesInChatroom{ Employee = selectedMember},
                }
                }));
        }
    }
}
