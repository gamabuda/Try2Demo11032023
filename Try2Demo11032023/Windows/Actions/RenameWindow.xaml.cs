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

namespace Try2Demo11032023.Windows.Actions
{
    /// <summary>
    /// Логика взаимодействия для RenameWindow.xaml
    /// </summary>
    public partial class RenameWindow : Window
    {
        public Model.Chatroom Chatroom { get; set; }
        public RenameWindow(Model.Chatroom chatroom)
        {
            InitializeComponent();
            Chatroom = chatroom;
            this.DataContext = Chatroom;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Data.DataBaseManager.DataBase.SaveChanges();
            new ChatWindow(Chatroom).Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
