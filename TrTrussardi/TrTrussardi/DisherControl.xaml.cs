using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.Entity;

namespace TrTrussardi
{
    public partial class DisherControl : UserControl
    {
        TrTrussardiEntities db1;
        TrTrussardiEntities db;
        public DisherControl()
        {
            InitializeComponent();
            db1 = new TrTrussardiEntities();
            db = new TrTrussardiEntities();
            db.Categories.Load();
            Categories.ItemsSource = db.Categories.Local.ToBindingList();
            db1.Dishes.Load();
            Dishes.ItemsSource = db1.Dishes.Local.ToBindingList();
            MakeFilter();
        }
        public void MakeFilter()
        {
            // здесь фильтр по категориям xdd
            Categories category;
            category = (TrTrussardi.Categories)this.Categories.SelectedItem;
            if (category != null)
            {
                var filteredData = db1.Dishes.Local.ToBindingList()
           .Where(x => x.CategoryId == category.CategoryId);
                this.Dishes.ItemsSource = filteredData.Count() > 0 ?
                    filteredData : filteredData.ToArray();
                return;
            }
            Dishes.ItemsSource = db1.Dishes.Local.ToBindingList();
        }

        private void GoSearch(object sender, RoutedEventArgs e)
        {
            // поиск блюда там внизу поиск есть xdd
            var filteredData = db1.Dishes.Local.ToBindingList()
     .Where(x => x.Name.Contains(this.FindText.Text));
            this.Dishes.ItemsSource = filteredData.Count() > 0 ?
                filteredData : filteredData.ToArray();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dishes dish;
            dish = (TrTrussardi.Dishes)this.Dishes.SelectedItem;
            dish = db1.Dishes.Find(dish.DishId);
            //изменение блюда     
            DishWindow dishWindow = new DishWindow(dish);
            dishWindow.ShowDialog();
            if (dishWindow.DialogResult != true)
                return;
            try
            {
                dish.Name = dishWindow.dishName.Text;
                dish.Val = Convert.ToInt32(dishWindow.TextVal.Text);      
                dish.CategoryId = Convert.ToInt32(dishWindow.Categories.SelectedValue);
                dish.Weight = dishWindow.textWeight.Text;
                if (dishWindow.TextCount.Text != "")
                    dish.Count = dishWindow.TextCount.Text;
                dish.Protein = Convert.ToSingle(dishWindow.TextProtein.Text);
                dish.Fat = Convert.ToSingle(dishWindow.TextFat.Text);
                dish.Carbohydrate = Convert.ToSingle(dishWindow.TextCarb.Text);
                dish.Calories = Convert.ToSingle(dishWindow.TextCalories.Text);
                db1.Entry(dish).State = EntityState.Modified;
                db1.SaveChanges();
                MessageBox.Show("Данные успешно сохранены");
                MakeFilter();
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке данных");
            }
        }
        private void Cost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            { 
                //обновление блюда
                Dishes dish;
                dish = (TrTrussardi.Dishes)this.Dishes.SelectedItem;
                dish = db1.Dishes.Find(dish.DishId);
                db1.Entry(dish).State = EntityState.Modified;
                db1.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Введены некорректные данные");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //удаление блюда
            Dishes dish;
            dish = (TrTrussardi.Dishes)this.Dishes.SelectedItem;
            dish = db1.Dishes.Find(dish.DishId);
            db1.Dishes.Remove(dish);
            db1.SaveChanges();
        }

        private void Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MakeFilter();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            db.Dispose();
            db1.Dispose();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Dishes dish = new Dishes();
            DishWindow dishWindow = new DishWindow(dish);
            //Добавление блюда
            dishWindow.ShowDialog();
            if (dishWindow.DialogResult != true)
                return;
            try
            {
                dish.Name = dishWindow.dishName.Text;
                dish.Val = Convert.ToInt32(dishWindow.TextVal.Text);
                dish.CategoryId = Convert.ToInt32(dishWindow.Categories.SelectedValue);
                dish.Weight = dishWindow.textWeight.Text;
                if (dishWindow.TextCount.Text != "")
                    dish.Count = dishWindow.TextCount.Text;
                dish.Protein = Convert.ToSingle(dishWindow.TextProtein.Text);
                dish.Fat = Convert.ToSingle(dishWindow.TextFat.Text);
                dish.Carbohydrate = Convert.ToSingle(dishWindow.TextCarb.Text);
                dish.Calories = Convert.ToSingle(dishWindow.TextCalories.Text);
                db1.Dishes.Add(dish);
                db1.SaveChanges();
                MessageBox.Show("Блюдо успешно добавлено");
                MakeFilter();
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке данных");
            }
        }
    }
}
