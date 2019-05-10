using System;
using System.Diagnostics;

using MaterialDesignThemes.Wpf;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace TrTrussardi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            Refresh();
        }
        public void Refresh()
        {
            int index = Itemss.SelectedIndex;
            switch (index)
            {
                case 0:
                    if (GridPrincipal != null)
                    {
                        GridPrincipal.Children.Clear();
                        GridPrincipal.Children.Add(new DisherControl());
                    }
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UsersControl());
                    break;
                default:
                    break;
            }
        }
        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        private void Itemss_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
