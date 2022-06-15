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

namespace Admin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Select.xaml
    /// </summary>
    public partial class Select : Page
    {
        public Select()
        {
            InitializeComponent();
        }

        private void Exot_Btn_Sel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Work_With_Employee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Class1.work_employee);
        }

        private void Work_With_Dihes_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Class1.work_dishes);
        }
    }
}
