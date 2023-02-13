using ChuChat.DB;
using System.Windows;
using System.Windows.Controls;

namespace ChuChat.Pages
{
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            tbName.Text = Properties.Settings.Default.Username;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            var username = tbName.Text;
            var password = pbPassword.Password.ToString();
            if (DataAccess.GetEmployee(username, password) != null)
            {
                App.Employee = DataAccess.GetEmployee(username, password);

                if ((bool)cbRememberMe.IsChecked)
                {
                    Properties.Settings.Default.Username = App.Employee.Username;
                    Properties.Settings.Default.Save();
                }
                //NavigationService.Navigate(new Pages.ChatListPage());
            }
            else
                MessageBox.Show("Unknown username or password");
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}
