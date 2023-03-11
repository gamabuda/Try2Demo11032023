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

namespace Try2Demo11032023
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Model.Employee Employee { get; set; } = Data.DataBaseManager.CurrentUser;
        public MainWindow()
        {
            InitializeComponent();

            HelloUserTB.DataContext = Employee;

            var items = Data.DataBaseManager.DataBase.Employee_Chatroom.Where(x => x.Id == Employee.Id).ToList();
            var chatrooms = new List<Model.Chatroom>();

            foreach(var i in items)
            {
                chatrooms.Add(i.Chatroom);
            }

            TopicLB.ItemsSource = chatrooms;


        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FinderBtn_Click(object sender, RoutedEventArgs e)
        {
            new Windows.FinderWindow().ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Model.Chatroom chatroom = TopicLB.SelectedItem as Model.Chatroom;

            if (chatroom != null)
            {
                new Windows.ChatWindow(chatroom).ShowDialog();
            }
        }
    }
}
