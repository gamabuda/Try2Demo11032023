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

namespace Try2Demo11032023.Windows
{
    /// <summary>
    /// Логика взаимодействия для FinderWindow.xaml
    /// </summary>
    public partial class FinderWindow : Window
    {
        public FinderWindow()
        {
            InitializeComponent();

            DepartamentLB.ItemsSource = Data.DataBaseManager.DataBase.Departament.ToList();
            EmployeeLB.ItemsSource = Data.DataBaseManager.DataBase.Employee.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var cuurentLst = Data.DataBaseManager.DataBase.Employee.ToList();

            if(SearchTB.Text != String.Empty)
            {
                cuurentLst = Data.DataBaseManager.DataBase.Employee.Where(z => (z.Name.Contains(SearchTB.Text))).ToList();
            }

            EmployeeLB.ItemsSource = cuurentLst;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as CheckBox;

            if(item.IsChecked == true)
            {
                EmployeeLB.ItemsSource = Data.DataBaseManager.DataBase.Employee.Where(x => x.Departament.Name == item.Content).ToList();
            }
            else
            {
                EmployeeLB.ItemsSource = Data.DataBaseManager.DataBase.Employee.ToList();
            }
        }

        //first commit
    }
}
