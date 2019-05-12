using MaterialDesignThemes.Wpf;
using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TrTrussardi
{
    public partial class CategoriesControl : UserControl
    {
        TrTrussardiEntities tr;
        private void Sample1_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("SAMPLE 1: Closing dialog with parameter: " + (eventArgs.Parameter ?? ""));
            if (!Equals(eventArgs.Parameter, true)) return;

            if (!string.IsNullOrWhiteSpace(FruitTextBox.Text))
            {
                Categories categories = new Categories();
                categories.Name = FruitTextBox.Text.Trim();
                tr.Categories.Add(categories);
                tr.SaveChanges();
            }
                
        }
        public void DoubleClickHandler(object sender, MouseEventArgs e)
        {
            //удаляем категорию
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Вы уверены, что хотите удалить выбранный раздел из базы данных, все блюда, входящие в данный раздел будут также удалены?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Categories sdishes = Cats.SelectedItem as Categories;
                tr.Categories.Remove(sdishes);
                tr.SaveChanges();
            }
        }
        public CategoriesControl()
        {
            InitializeComponent();
            tr = new TrTrussardiEntities();
            tr.Categories.Load();
            Cats.ItemsSource = tr.Categories.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tr.SaveChanges();
        }
    }
}
