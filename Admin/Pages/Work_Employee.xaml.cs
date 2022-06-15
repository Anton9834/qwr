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
    /// Логика взаимодействия для Work_Employee.xaml
    /// </summary>
    public partial class Work_Employee : Page
    {
        user_05Entities1 connection = new user_05Entities1();
        public Work_Employee()
        {
            InitializeComponent();
            LoadVPos();
            LoadVEmp();
        }

        private void LoadVPos()
        {
            var pos = connection.Position.ToList();
            foreach (var p in pos)
            {

                Position_CBOX.Items.Add(p.Name);
            }
            Position_CBOX.Items.Remove("Администратор");
        }

        private void LoadVEmp()
        {
            Employee_List.Items.Clear();
            var em = connection.Employee.Where(e => e.Status != "Уволен").ToList();
            foreach (var e in em)
            {
                Employee_List.Items.Add(e);
            }
        }


        private void Add_Employee_Click(object sender, RoutedEventArgs e)
        {
            string number_admin_2 = Number_TBOX_2.Text;
            string password_admin_2 = Password_TBOX_2.Password;
            string surname_admib_2 = Surname_TBOX_2.Text;
            string name_admin_2 = Name_TBOX_2.Text;
            string patr_admin_2 = Patronymic_TBOX_2.Text;
            string pos_admin = Position_CBOX.Text;

            if ((number_admin_2.Length == 0) && (password_admin_2.Length == 0) && (surname_admib_2.Length == 0) && (name_admin_2.Length == 0 && patr_admin_2.Length == 0) && (pos_admin.Length == 0))
            {
                MessageBox.Show("Все поля пустые!");
                return;
            }

            if ((password_admin_2.Length == 0) && (surname_admib_2.Length == 0) && (name_admin_2.Length == 0) && (patr_admin_2.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }
            if ((number_admin_2.Length == 0) && (surname_admib_2.Length == 0) && (name_admin_2.Length == 0) && (patr_admin_2.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((number_admin_2.Length == 0) && (password_admin_2.Length == 0) && (name_admin_2.Length == 0) && (patr_admin_2.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((number_admin_2.Length == 0) && (password_admin_2.Length == 0) && (surname_admib_2.Length == 0) && (patr_admin_2.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((number_admin_2.Length == 0) && (password_admin_2.Length == 0) && (surname_admib_2.Length == 0) && (name_admin_2.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((number_admin_2.Length == 0) && (password_admin_2.Length == 0) && (surname_admib_2.Length == 0) && (name_admin_2.Length == 0) && (patr_admin_2.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((surname_admib_2.Length == 0) && (name_admin_2.Length == 0) && (patr_admin_2.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((password_admin_2.Length == 0) && (name_admin_2.Length == 0) && (patr_admin_2.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((password_admin_2.Length == 0) && (surname_admib_2.Length == 0) && (patr_admin_2.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if ((password_admin_2.Length == 0) && (name_admin_2.Length == 0) && (surname_admib_2.Length == 0))
            {
                MessageBox.Show("Введите остальные поля!");
                return;
            }

            if (number_admin_2.Length == 0)
            {
                MessageBox.Show("Введите телефон!");
                return;
            }

            if (password_admin_2.Length == 0)
            {
                MessageBox.Show("Введите пароль!");
                return;
            }

            if (surname_admib_2.Length == 0)
            {
                MessageBox.Show("Введите фамилию!");
                return;
            }

            if (name_admin_2.Length == 0)
            {
                MessageBox.Show("Введите имя!");
                return;
            }

            if (patr_admin_2.Length == 0)
            {
                MessageBox.Show("Введите отчество!");
                return;
            }

            if (pos_admin.Length == 0)
            {
                MessageBox.Show("Выберите должность!");
                return;
            }


            Employee isExist = connection.Employee.Where(global => global.Phone == number_admin_2).FirstOrDefault();

            if (isExist != null)
            {
                MessageBox.Show("Такой номер уже зарегистрирован!");
            }

            else
            {

                Employee employee = new Employee();
                employee.Phone = number_admin_2;
                employee.Password = password_admin_2;
                employee.Surname = surname_admib_2;
                employee.Name = name_admin_2;
                employee.Patronymic = patr_admin_2;
                employee.Position = pos_admin;
                employee.Status = "Работает";

                connection.Employee.Add(employee);

                int result = connection.SaveChanges();
                if (result == 1)
                {
                    Number_TBOX_2.Text = "";
                    Password_TBOX_2.Password = "";
                    Surname_TBOX_2.Text = "";
                    Name_TBOX_2.Text = "";
                    Patronymic_TBOX_2.Text = "";
                    Position_CBOX.Text = "";

                    //MessageBox.Show("Сотрудник успешно добавлен!");
                }
                LoadVEmp();



            }
        }

        private void Del_Employee_Click(object sender, RoutedEventArgs e)
        {
            var employee = Employee_List.SelectedItem as Employee;

            if (employee != null)
            {
                employee.Status = "Уволен";
                Employee_List.Items.Remove(employee);
                //MessageBox.Show("Сотрудник уволен");
                connection.SaveChanges();
            }
        }

        private void Exit_Employee_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Back_Employee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Class1.select);
        }
    }
}
