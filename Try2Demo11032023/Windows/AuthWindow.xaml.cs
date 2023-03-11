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
using Try2Demo11032023.Data;

namespace Try2Demo11032023
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();

            //var user = DataBaseManager.DataBase.RemeberMeSpan.ToList().Last();

            //if(user != null)
            //{
            //    UsernameTB.Text = user.Employee.Username;
            //    PasswordTB.Password = user.Employee.Password;
            //}
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            if(UsernameTB.Text == String.Empty && PasswordTB.Password == String.Empty)
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }

            var user = DataBaseManager.DataBase.Employee.FirstOrDefault(x => x.Username == UsernameTB.Text && x.Password == PasswordTB.Password);

            if(user == null)
            {
                MessageBox.Show("Такого пользователя не существует!");
                return;
            }

            DataBaseManager.CurrentUser = user;
            new MainWindow().Show();
            this.Close();
        }

        private void RememberCB_Click(object sender, RoutedEventArgs e)
        {
            if(RememberCB.IsChecked == true)
            {
                var user = DataBaseManager.DataBase.Employee.FirstOrDefault(x => x.Username == UsernameTB.Text && x.Password == PasswordTB.Password);

                if (user == null)
                {
                    MessageBox.Show("Такого пользователя не существует!");
                    return;
                }

                DataBaseManager.DataBase.RemeberMeSpan.Add(
                    new Model.RemeberMeSpan
                    {
                        Employee = user
                    });
            }
            else
            {
                DataBaseManager.DataBase.RemeberMeSpan.Remove(DataBaseManager.DataBase.RemeberMeSpan.Last());
            }
        }
    }
}
