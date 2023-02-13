using System.Windows;

namespace ChuChat
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new Pages.AuthorizationPage());
        }
    }
}
