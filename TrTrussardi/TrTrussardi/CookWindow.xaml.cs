using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace TrTrussardi
{
    public partial class CookWindow : Window
    {
        TrTrussardiEntities tr;
        public CookWindow()
        {
            InitializeComponent();
            tr = new TrTrussardiEntities();
            Refresh();
        }
        public void DoubleClickHandler(object sender, MouseEventArgs e)
        {
            Orders order = NeedReadyOrdersGrid.SelectedItem as Orders;
            AboutOrder aboutOrder = new AboutOrder(order);
            aboutOrder.ShowDialog();
            if(aboutOrder.DialogResult == true)
            {
                var s = NeedReadyOrdersGrid.SelectedItem as Orders;
                s.Status = true;
                tr.Entry(s).State = EntityState.Modified;
                tr.SaveChanges();
                Refresh();
            }
        }
        void Refresh()
        {
            var stocks = tr.Orders.AsQueryable();
            stocks = stocks.Where(s => s.Status == false);
            stocks = stocks.Where(s => s.Time.Day == DateTime.Now.Day);
            stocks = stocks.OrderBy(t => t.Time);
            var result = stocks.ToList();
            NeedReadyOrdersGrid.ItemsSource = result;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tr.Dispose();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
