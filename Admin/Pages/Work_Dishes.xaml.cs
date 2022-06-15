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
    /// Логика взаимодействия для Work_Dishes.xaml
    /// </summary>
    public partial class Work_Dishes : Page
    {

        user_05Entities1 connection = new user_05Entities1();

        public Work_Dishes()
        {
            InitializeComponent();
            LoadUnit();
            LoadDish();


        }



        private void LoadDish()
        {
            HashSet<Dish> dishes = new HashSet<Dish>();

            var dish = connection.DishCompound.ToList();
            foreach (var d in dish)
            {
                dishes.Add(d.Dish1);
            }

            Dish_List.ItemsSource = dishes.ToList();


        }

        private void LoadUnit()
        {
            var unit = connection.Unit.ToList();
            foreach (var u in unit)
            {

                Unit.Items.Add(u.Unit1);
            }
            //  Position_CBOX.Items.Remove("Администратор");
        }


        private void Back_Select_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Class1.select);
        }

        private void Exit_B_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Add_Dishes_Click(object sender, RoutedEventArgs e)
        {
            string name_dish = Name_Dish.Text;
            string price_dish = Price_Dish.Text;

            if (name_dish.Length == 0 && price_dish.Length == 0)
            {
                MessageBox.Show("Все поля пусыте!!!");
                return;
            }

            if (name_dish.Length == 0)
            {
                MessageBox.Show("Введите название блюда!!!");
                return;
            }

            if (price_dish.Length == 0)
            {
                MessageBox.Show("Введите цену блюда!!!");
                return;
            }

            

            


            Dish isExist = connection.Dish.Where(global => global.Name == name_dish).FirstOrDefault();

            if (isExist != null)
            {
                MessageBox.Show("Такое блюдо уже есть!");
            }

          
            else
            {

                Dish dish = new Dish();
                dish.Name = name_dish;
                dish.Price = Convert.ToDecimal(price_dish);



                connection.Dish.Add(dish);

                int result = connection.SaveChanges();
                if (result == 1)
                {
                    Name_Dish.Text = "";
                    Price_Dish.Text = "";


                    //MessageBox.Show("Сотрудник успешно добавлен!");
                }
            }
        }

        private void Back_Select_2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Class1.select);
        }

        private void Exit_B_2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Add_Ingredient_Click(object sender, RoutedEventArgs e)
        {
            string name_ing = Name_Ingredient.Text;
            string unit_ing = Unit.Text;


            if (name_ing.Length == 0 && unit_ing.Length == 0)
            {
                MessageBox.Show("Все поля пусыте!!!");
                return;
            }

            if (name_ing.Length == 0)
            {
                MessageBox.Show("Введите навзание ингредиента!!!");
                return;
            }

            if (unit_ing.Length == 0)
            {
                MessageBox.Show("Введите единицу измерения!!!");
                return;
            }

            Ingredient isExist_1 = connection.Ingredient.Where(global_1 => global_1.Name == name_ing).FirstOrDefault();

            if (isExist_1 != null)
            {
                MessageBox.Show("Такой ингредиент уже есть!");
            }

            

            else
            {

                Ingredient ingredient = new Ingredient();
                ingredient.Name = name_ing;
                ingredient.Unit = unit_ing;



                connection.Ingredient.Add(ingredient);

                int result = connection.SaveChanges();
                if (result == 1)
                {
                    Name_Ingredient.Text = "";
                    Unit.Text = "";


                    //MessageBox.Show("Сотрудник успешно добавлен!");
                }
            }


        }

        private void Back_Select_3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Class1.select);
        }

        private void Exit_B_3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }
    }
}
