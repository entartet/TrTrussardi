using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace TrTrussardi
{
    public partial class UsersControl : System.Windows.Controls.UserControl
    {
        TrTrussardiEntities users;
        public UsersControl()
        {
            InitializeComponent();
            users = new TrTrussardiEntities();
            users.Users.Load();
            UsersGrid.ItemsSource = users.Users.Local.ToBindingList();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            users.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem != null)
            {
                // ищем нужного пользователя
                Users users1 = (Users)UsersGrid.SelectedItem;
                Users user = users.Users.Find(users1.UserId);
                users.Users.Remove(user);
                users.SaveChanges();
                System.Windows.MessageBox.Show("Объект удален");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(UsersGrid.SelectedItem!=null)
            {
                Users editUser = UsersGrid.SelectedItem as Users;
                editUser = users.Users.Find(editUser.UserId);
                UsersWindow editUserWindow = new UsersWindow(editUser);
                editUserWindow.ShowDialog();
                if (editUserWindow.DialogResult != true)
                    return;
                try
                {
                    editUser.Login = editUserWindow.textLogin.Text;
                    editUser.Password = editUserWindow.textPass.Text;
                    editUser.Name = editUserWindow.textName.Text;
                    editUser.PositionId = (int)editUserWindow.ComboPosition.SelectedValue;
                    users.Entry(editUser).State = EntityState.Modified;
                    users.SaveChanges();
                    System.Windows.MessageBox.Show("Данные успешно изменены");
                    UsersGrid.ItemsSource = users.Users.ToList();
                }
                catch
                {
                    System.Windows.MessageBox.Show("Были введены некорректные данные");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Выберите пользователя");
            }
            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // добавляю с помощью окна UsersWindow нового пользователя
            UsersWindow usersWindow = new UsersWindow();
            usersWindow.ShowDialog();
            if (usersWindow.DialogResult != true)
                return;
            try
            {
                Users user = new Users();
                user.Login = usersWindow.textLogin.Text;
                user.Password = usersWindow.textPass.Text;
                user.Name = usersWindow.textName.Text;
                user.PositionId = (int)usersWindow.ComboPosition.SelectedValue;
                users.Users.Add(user);
                users.SaveChanges();
                System.Windows.MessageBox.Show("Новый пользователь добавлен");
            }
            catch
            {
                System.Windows.MessageBox.Show("Введены некорректные данные");
            }
        }
    }
}
