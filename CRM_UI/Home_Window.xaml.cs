using CRM_UI.Storage;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CRM_UI
{

    /// <summary>
    /// Логика взаимодействия для Home_Window.xaml
    /// </summary>
    public partial class Home_Window : Window
    {
        public Home_Window()
        {
            InitializeComponent();
            Process.Start("Test_Bot.exe");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnFullscreenExit_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                btnFullscreenExit.Visibility = Visibility.Collapsed;
                btnFullscreen.Visibility = Visibility.Visible;
            }
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnFullscreen_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                btnFullscreenExit.Visibility = Visibility.Visible;
                btnFullscreen.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            
            switch (index)
            {
                case 6:

                    
                    GridWindow.Children.Clear();
                    Storage_Window form = new Storage_Window();
                    GridWindow.Children.Add(form);
                    break;
                default:
                    break;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GC.Collect();
        }
    }
}
