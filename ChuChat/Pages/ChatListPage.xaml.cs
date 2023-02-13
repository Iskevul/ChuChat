using ChuChat.DB;
using ChuChat.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ChuChat.Model;

namespace ChuChat.Pages
{
    public partial class ChatListPage : Page
    {
        public Employee Employee { get; set; }
        public List<Chatroom> Chatrooms { get; set; }

        public ChatListPage()
        {
            InitializeComponent();

            Employee = App.Employee;
            Chatrooms = DataAccess.GetChatrooms();
            DataContext = this;
        }

        private void FinderBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.FilterPage());
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }

        private void lvChats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chatroom = (lvChats.SelectedItem as EmployeesInChatroom).Chatroom;
            NavigationService.Navigate(new ChatPage(chatroom));
        }
    }
}
