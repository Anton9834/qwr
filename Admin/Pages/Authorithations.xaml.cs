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
    /// Логика взаимодействия для Authorithations.xaml
    /// </summary>
    public partial class Authorithations : Page
    {
        user_05Entities1 connection = new user_05Entities1();
        private string code = "";
        private int failcount = 0;
        private double blocktime = 0;
        private int blockInterval = 60000;
        private const string filename = "data.lock";
        public Authorithations()
        {
            InitializeComponent();


            string chars = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890@?#";
            Random random = new Random((int)DateTime.Now.Ticks);
            for(int i = 0; i<6; i++)
            {
                int a = random.Next(0, chars.Length-1);
                code += chars.Substring(a, 1);
            }

            Captcha_Box.Text = code;

#if DEBUG
            Number_TBOX_2.Text = "89512654570";
            Password_TBOX_2.Password = "12345";
#endif
        }


       


        

        private void Exot_Btn_3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Enter_Btn_Click(object sender, RoutedEventArgs e)
        {
            string number_ad = Number_TBOX_2.Text;
            string password_ad = Password_TBOX_2.Password;
            string cap = Captcha_3.Text;

            if ((number_ad.Length == 0) && (password_ad.Length == 0) && (cap.Length == 0))
            {
                MessageBox.Show("Все поля пустые!");
                return;
            }

            if (Captcha_3.Text != code)
            {
                MessageBox.Show("Неверный код проверки!!!");
                failcount++;
                return;
            }

            else
            {

                var employee = connection.Employee.Where(em => em.Phone == number_ad && em.Password == password_ad).FirstOrDefault();

                if (employee != null)
                {
                   // MessageBox.Show("Вход выполнен!");
                    NavigationService.Navigate(Pages.Class1.select);
                }
                else
                {
                    MessageBox.Show("Введены некорректные данные!!!");
                }

            }
        }
    }
}
