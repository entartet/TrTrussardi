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
            Refresh();
        }
        void Refresh()
        {
            tr = new TrTrussardiEntities();
            tr.Orders.Load();
            OrdersGrid.ItemsSource = tr.Orders.Local.ToBindingList();
            
        }
    }
}
