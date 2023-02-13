using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ChuChat.Model;

namespace ChuChat.DB
{
    public class DataAccess
    {
        public delegate void RefreshListDelegate();
        public static event RefreshListDelegate RefreshListEvent;

        public static List<Employee> GetEmployees() => DbConnection.connection.Employee.ToList();
        public static List<Department> GetDepartments() => DbConnection.connection.Department.ToList();
        public static List<Chatroom> GetChatrooms() => DbConnection.connection.Chatroom.ToList();

        public static Employee GetEmployee(string username, string password)
        {
            return DbConnection.connection.Employee.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public static List<ChatMessage> GetChatMessages() => DbConnection.connection.ChatMessage.ToList();

        public static List<ChatMessage> GetChatMessages(Chatroom chatroom)
        {
            return GetChatMessages().FindAll(x => x.Chatroom == chatroom);
        }

        public static void SaveChatMessage(ChatMessage message)
        {
            if (message.Id == 0)
                DbConnection.connection.ChatMessage.Add(message);

            DbConnection.connection.SaveChanges();
            RefreshListEvent?.Invoke();
        }

        static string ComputeStringToSha256Hash(string plainText)
        {
            // Create a SHA256 hash from string   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computing Hash - returns here byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // now convert byte array to a string   
                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));
                }
                return stringbuilder.ToString();
            }
        }
    }
}
