using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TrTrussardi
{
    public partial class ReadyOrdersPage : Page
    {
        TrTrussardiEntities tr;
        public ReadyOrdersPage()
        {
            InitializeComponent();
            Refresh();
        }
        void Refresh()
        {
            tr = new TrTrussardiEntities();
        var stocks = tr.Orders.AsQueryable();
        stocks = stocks.Where(s => s.Status == true);
             stocks = stocks.Where(s => s.Time.Day == DateTime.Now.Day);
            stocks = stocks.OrderByDescending(t => t.Time);
            var result = stocks.ToList();
        ReadyOrdersGrid.ItemsSource = result;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            tr.Dispose();
        }
    }
}
