using System.Data.Entity;
using System.Linq;
using System.Windows;


namespace TrTrussardi
{
    public partial class LoginWindow : Window
    {
        TrTrussardiEntities db;
        public LoginWindow()
        {
            InitializeComponent();
            db = new TrTrussardiEntities();
        }
        private void Exitt_Click(object sender, RoutedEventArgs e)
        {
            db.Dispose();
            Close();
        }
        private void SignIn_Click_1(object sender, RoutedEventArgs e)
        {
            
            db.Users.Load();
            if (comboBox1.Text.Trim() != "" && txtPassword.Password.Trim() != "")
            {
                var auth_login = db.Users.Where(a => a.Login == (comboBox1.Text.Trim()));
                auth_login = auth_login.Where(a => a.Password == txtPassword.Password);
                Users user = auth_login.First();
                if(user != null)
                    // успешный вход пароль и логин правильные
                    if (user.PositionId == 3)
                    {
                        // Открываем форму администратора
                        MainWindow main = new MainWindow();
                        main.Show();
                        Close();
                        return;
                    }
                    if (user.PositionId == 2)
                    {
                        // Открываем форму кассира
                        MainForUser main = new MainForUser();
                        main.Show();
                        Close();
                        return;
                    }
                    if (user.PositionId == 1)
                    {
                        // Открываем форму повара
                        CookWindow main = new CookWindow();
                        main.Show();
                        Close();
                        return;
                    }
                else
                {
                    MessageBox.Show("Введены неверные данные");
                }
                db.Dispose();
            }
            MessageBox.Show("Необходимо заполнить все поля");
        }

        private void LogForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
             db.Dispose();
        }
    }
}
