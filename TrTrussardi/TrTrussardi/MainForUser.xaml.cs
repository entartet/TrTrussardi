﻿using System;
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
using System.Windows.Shapes;

namespace TrTrussardi
{
    public partial class MainForUser : Window
    {
        public MainForUser()
        {
            InitializeComponent();
            MakeOrder.IsChecked = true;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
                  Frame1.Content = new NotReadyOrdersPage();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new ReadyOrdersPage();
        }
    }
}
