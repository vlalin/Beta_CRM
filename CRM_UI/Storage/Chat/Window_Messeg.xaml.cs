using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CRM_UI.Storage.Chat
{
    /// <summary>
    /// Логика взаимодействия для Window_Messeg.xaml
    /// </summary>
    public partial class Window_Messeg : UserControl
    {
        public Window_Messeg()
        {
            InitializeComponent();
        }

        private void Messeg_Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Messeg_Txt.Text == "")
            {
                Messeg_Txt.BorderBrush = Brushes.Red;
                Messeg_Txt.Foreground = Brushes.Red;


                SendMesseg_Btn.Visibility = Visibility.Collapsed;
                SendMessegOff_Btn.Visibility = Visibility.Visible;
            }

            if (Messeg_Txt.Text.Length > 0)
            {
                Messeg_Txt.BorderBrush = Brushes.Gray;
                Messeg_Txt.Foreground = Brushes.Black;


                SendMesseg_Btn.Visibility = Visibility.Visible;
                SendMessegOff_Btn.Visibility = Visibility.Collapsed;
                Messeg_Txt.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
        }

        private void Return_btn_Click(object sender, RoutedEventArgs e)
        {
            //StackPanel s = (this.Parent as StackPanel);
            //s.Children.Clear();
            //var r = (s.Parent as Grid);
            //r.Children.Clear();

            

            GC.Collect();
        }

        
    }
}