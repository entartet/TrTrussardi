using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.IO;
using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace TrTrussardi
{
    public partial class DishWindow : Window
    {
        TrTrussardiEntities db;
        Dishes dish;
        public DishWindow(Dishes dishes)
        {
            InitializeComponent();
            if (dishes != null)
            {
                db = new TrTrussardiEntities();
                db.Categories.Load();
                Categories.ItemsSource = db.Categories.Local.ToBindingList();
                dish = dishes;
                dishName.Text = dish.Name;
                TextVal.Text = dish.Val.ToString();
                Categories.SelectedValue = dish.CategoryId;
                textWeight.Text = dish.Weight;
                TextCount.Text = dish.Count;
                TextProtein.Text = dish.Protein.ToString();
                TextFat.Text = dish.Fat.ToString();
                TextCarb.Text = dish.Carbohydrate.ToString();
                TextCalories.Text = dish.Calories.ToString();
                DishPhoto.Source = ConvertByteArrayToImage(dish.Picture);
            }
        }
        public DishWindow()
        {
            dish = new Dishes();
            InitializeComponent();
            db = new TrTrussardiEntities();
            db.Categories.Load();
            Categories.ItemsSource = db.Categories.Local.ToBindingList();
        }
        private byte[] ConvertImageToByteArray(string fileName)
        {
            Bitmap bitMap = new Bitmap(fileName);
            ImageFormat bmpFormat = bitMap.RawFormat;
            var imageToConvert = System.Drawing.Image.FromFile(fileName);
            using (MemoryStream ms = new MemoryStream())
            {
                imageToConvert.Save(ms, bmpFormat);
                return ms.ToArray();
            }
        }
        public BitmapImage ConvertByteArrayToImage(byte[] array)
        {
            if (array != null)
            {
                using (var ms = new MemoryStream(array, 0, array.Length))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
            return null;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "";
            dlg.Filter = "Image files (*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp|All Files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                byte[] vs = ConvertImageToByteArray(selectedFileName);
                dish.Picture = vs;
                DishPhoto.Source = ConvertByteArrayToImage(dish.Picture);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Categories.SelectedValue!="0" && dishName.Text!="" && TextVal.Text!="" && textWeight.Text!="" && TextProtein.Text!="" && TextFat.Text!="" && TextCarb.Text!="" && TextCalories.Text!="")
            this.DialogResult = true;
            else
            MessageBox.Show("Введены некорректные данные");
        }
        private void Cost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void TextFat_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string inputSymbol = e.Text.ToString();

            if (!Regex.Match(inputSymbol, @"[0-9]|\,").Success)
            {
                e.Handled = true;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
