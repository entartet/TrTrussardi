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
    public partial class OrdersControl : UserControl
    {
        TrTrussardiEntities tr;
        public OrdersControl()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            Ot.SelectedDate = DateTime.Now.AddDays(-7);
            Do.SelectedDate = DateTime.Now;
            Refresh();
        }
        void Refresh()
        {
            tr = new TrTrussardiEntities();
            tr.Orders.Load();
            var ord = tr.Orders.AsQueryable();
            bool status = true;
            bool canStatus = false;
            if (comboBox1.SelectedIndex == 0)
                canStatus = true;
            if (comboBox1.SelectedIndex == 1)
                    status = true;
            if (comboBox1.SelectedIndex == 2)
                status = false;
            if(canStatus==false)
                ord = ord.Where(a => a.Status == status);
            ord = ord.Where(a => a.Time >= Ot.SelectedDate);
            ord = ord.Where(a => a.Time <= Do.SelectedDate);
            int sum = 0;
            foreach(Orders orders in ord.ToList())
                sum += (int)orders.AllCost;
            AllCostText.Text = sum.ToString();
            OrdersGrid.ItemsSource = ord.ToList();
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Ot_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
