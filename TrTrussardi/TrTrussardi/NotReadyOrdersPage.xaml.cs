using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace TrTrussardi
{
    public partial class NotReadyOrdersPage : Page
    {
        TrTrussardiEntities db1;
        TrTrussardiEntities db;
        TrTrussardiEntities dbOrder;
        TrTrussardiEntities dbOrderedDishes;
        public NotReadyOrdersPage()
        {
            InitializeComponent();
            db1 = new TrTrussardiEntities();
            db = new TrTrussardiEntities();
            dbOrder = new TrTrussardiEntities();
            dbOrderedDishes = new TrTrussardiEntities();
            db.Categories.Load();
            Categories.ItemsSource = db.Categories.Local.ToBindingList();
            db1.Dishes.Load();
            Dishes.ItemsSource = db1.Dishes.Local.ToBindingList();
            dbOrder.Orders.Load();
            dbOrderedDishes.OrderedDishes.Load();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AllCost.Text = "0";
            Corzina.Items.Clear();
        }

        private void Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MakeFilter();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Dishes sdishes = Dishes.SelectedItem as Dishes;
            int sum = 0;
            sum = Convert.ToInt32(AllCost.Text);
            sum += sdishes.Val;
            AllCost.Text = sum.ToString();
            Corzina.Items.Add(Dishes.SelectedItem as Dishes);
        }
        public void DoubleClickHandler(object sender, MouseEventArgs e)
        {
            Dishes sdishes = Corzina.SelectedItem as Dishes;
            int sum = 0;
            sum = Convert.ToInt32(AllCost.Text);
            sum -= sdishes.Val;
            AllCost.Text = sum.ToString();
            Corzina.Items.RemoveAt(Corzina.SelectedIndex);
        }
        private void GoSearch(object sender, RoutedEventArgs e)
        {
            // поиск блюда там внизу поиск есть xdd
            var filteredData = db1.Dishes.Local.ToBindingList()
     .Where(x => x.Name.Contains(this.FindText.Text));
            this.Dishes.ItemsSource = filteredData.Count() > 0 ?
                filteredData : filteredData.ToArray();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if(Corzina.HasItems == true)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Подтвердите заказ", "", System.Windows.MessageBoxButton.OKCancel);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    //Здесь выполняем заказ
                    Orders orders = new Orders();
                    orders.Status = false;
                    orders.Time = DateTime.Now;
                    dbOrder.Orders.Add(orders);
                    dbOrder.SaveChanges();
                    OrderedDishes orderedDishes = new OrderedDishes();
                    // добавляем заказаные блюда
                    foreach (Dishes dish in Corzina.Items)
                    {
                        orderedDishes.OrderId = orders.OrderId;
                        orderedDishes.DishId = dish.DishId;
                        dbOrderedDishes.OrderedDishes.Add(orderedDishes);
                        dbOrderedDishes.SaveChanges();
                    }
                    MessageBox.Show("Заказ успешно выполнен");
                }
                else
                {
                    MessageBox.Show("Корзина пуста");
                }
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            db.Dispose();
            db1.Dispose();
            dbOrder.Dispose();
            dbOrderedDishes.Dispose();
        }
    }
}
