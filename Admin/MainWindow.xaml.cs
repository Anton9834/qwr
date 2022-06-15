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

namespace Admin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }

        user_05Entities1 connection = new user_05Entities1();
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Exot_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Auth_Btn_Click(object sender, RoutedEventArgs e)
        {
            var EmployeeList = connection.Employee.ToList();

            if (EmployeeList.Count == 0)
            {
                MainFrame.NavigationService.Navigate(Pages.Class1.registration_admin);
                Exot_Btn.Visibility = Visibility.Collapsed;
                Auth_Btn.Visibility = Visibility.Collapsed;
                BK_I.Visibility = Visibility.Collapsed;
                Label_KFC.Visibility = Visibility.Collapsed;
            }

            else
            {
                MainFrame.NavigationService.Navigate(Pages.Class1.authorithations);
                Exot_Btn.Visibility = Visibility.Collapsed;
                Auth_Btn.Visibility = Visibility.Collapsed;
                BK_I.Visibility = Visibility.Collapsed;
                Label_KFC.Visibility = Visibility.Collapsed;
            }
        }
    }
}
