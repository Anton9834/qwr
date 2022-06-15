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
    /// Логика взаимодействия для Registration_Admin.xaml
    /// </summary>
    public partial class Registration_Admin : Page
    {
        user_05Entities1 connection = new user_05Entities1();
        public Registration_Admin()
        {
            InitializeComponent();
        }

        private void Reg_Btn_Click(object sender, RoutedEventArgs e)
        {
            string number_admin = Number_TBOX.Text;
            string password_admin = Password_TBOX.Password;
            string surname_admib  = Surname_TBOX.Text;
            string name_admin = Name_TBOX.Text;
            string patr_admin = Patronymic_TBOX.Text;

            if ((number_admin.Length == 0) && (password_admin.Length == 0) && (surname_admib.Length == 0) && (name_admin.Length == 0 && patr_admin.Length == 0))
            {
                MessageBox.Show("Все поля пустые!");
                return;
            }

            if ((password_admin.Length == 0) && (surname_admib.Length == 0) && (name_admin.Length == 0) && (patr_admin.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }
            if ((number_admin.Length == 0) && (surname_admib.Length == 0) && (name_admin.Length == 0) && (patr_admin.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((number_admin.Length == 0) && (password_admin.Length == 0) && (name_admin.Length == 0) && (patr_admin.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((number_admin.Length == 0) && (password_admin.Length == 0) && (surname_admib.Length == 0) && (patr_admin.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((number_admin.Length == 0) && (password_admin.Length == 0) && (surname_admib.Length == 0) && (name_admin.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((surname_admib.Length == 0) && (name_admin.Length == 0) && (patr_admin.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((password_admin.Length == 0) && (name_admin.Length == 0) && (patr_admin.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((password_admin.Length == 0) && (surname_admib.Length == 0) && (patr_admin.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((password_admin.Length == 0) && (name_admin.Length == 0) && (surname_admib.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if (number_admin.Length == 0)
            {
                MessageBox.Show("Введите телефон!");
                return;
            }

            if (password_admin.Length == 0)
            {
                MessageBox.Show("Введите пароль!");
                return;
            }

            if (surname_admib.Length == 0)
            {
                MessageBox.Show("Введите фамилию!");
                return;
            }

            if (name_admin.Length == 0)
            {
                MessageBox.Show("Введите имя!");
                return;
            }

            if (patr_admin.Length == 0)
            {
                MessageBox.Show("Введите отчество!");
                return;
            }

           

                Employee isExist = connection.Employee.Where(global => global.Phone == number_admin).FirstOrDefault();
                
                if (isExist != null)
                {
                    MessageBox.Show("Такой номер уже зарегистрирован!");
                }

             else
             {

                Employee employee = new Employee();
                employee.Phone = number_admin;
                employee.Password = password_admin;
                employee.Surname = surname_admib;
                employee.Name = name_admin;
                employee.Patronymic = patr_admin;
                employee.Position = "Администратор";
                employee.Status = "Работает";
                //employee

                connection.Employee.Add(employee);

                int result = connection.SaveChanges();
                if (result == 1)
                {
                    Number_TBOX.Text = "";
                    Password_TBOX.Password = "";
                    Surname_TBOX.Text = "";
                    Name_TBOX.Text = "";
                    Patronymic_TBOX.Text = "";

                   // MessageBox.Show("Администратор успешно добавлен!");
                }


                NavigationService.Navigate(Pages.Class1.authorithations);
               // MessageBox.Show("Вы успешно зарегистрированы.\nВы будете перенаправлены на страницу входа автоматически");

            }


            
        }
    }
}
