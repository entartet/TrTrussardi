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
using System.Windows.Shapes;

namespace TrTrussardi
{
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
        }
        public UsersWindow(Users users)
        {
            InitializeComponent();
            textLogin.Text = users.Login;
            textPass.Text = users.Password;
            textName.Text = users.Name;
            checkAdmin.IsChecked = users.AdminPrivileges;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textLogin.Text != "" && textPass.Text != "")
                DialogResult = true;
            else MessageBox.Show("Введены некорректные данные");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
