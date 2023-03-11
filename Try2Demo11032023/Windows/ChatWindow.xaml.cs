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
using System.Windows.Shapes;
using Try2Demo11032023.Windows.Actions;

namespace Try2Demo11032023.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        Model.Chatroom Chatroom { get; set; }
        public ChatWindow(Model.Chatroom chatroom)
        {
            InitializeComponent();

            Chatroom = chatroom;
            this.DataContext = Chatroom;

            UsersLV.ItemsSource = Data.DataBaseManager.DataBase.Employee_Chatroom.Where(x => x.Chatroom_Id == Chatroom.Id).ToList();
            MessageLB.ItemsSource = Data.DataBaseManager.DataBase.ChatMessage.Where(x => x.Chatroom_Id == Chatroom.Id).ToList();
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Data.DataBaseManager.DataBase.ChatMessage.Add(
                    new Model.ChatMessage()
                    {
                        Chatroom = Chatroom,
                        Employee = Data.DataBaseManager.CurrentUser,
                        Message = MsgTB.Text,
                        Date = DateTime.Now
                    });

                Data.DataBaseManager.DataBase.SaveChanges();
                MessageLB.ItemsSource = Data.DataBaseManager.DataBase.ChatMessage.Where(x => x.Id == Chatroom.Id).ToList();
                MsgTB.Text = String.Empty;
            }
            catch
            {
                MessageBox.Show("Попробуйте позже!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new RenameWindow(Chatroom).ShowDialog();
            this.Close();
        }
    }
}
