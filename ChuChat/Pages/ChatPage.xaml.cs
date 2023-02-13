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
    public partial class ChatPage : Page
    {
        public Chatroom Chatroom { get; set; }
        public ChatPage(Chatroom chatroom)
        {
            InitializeComponent();
            Chatroom = chatroom;
            //DataAccess.RefreshListEvent += DataAccess_RefreshListEvent;
            DataContext = this;
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            lvMessages.ItemsSource = DataAccess.GetChatMessages(Chatroom);
            lvMessages.Items.Refresh();
        }

        private void ChangeTopicBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LeaveChatBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SendMessageBtn_Click(object sender, RoutedEventArgs e)
        {
            var message = new ChatMessage
            {
                Chatroom = Chatroom,
                Employee = App.Employee,
                Message = tbMessage.Text,
                Date = DateTime.Now,
            };

            DataAccess.SaveChatMessage(message);
            lvMessages.ItemsSource = DataAccess.GetChatMessages(Chatroom);
            lvMessages.Items.Refresh();
        }
    }
}
