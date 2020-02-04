using CRM_UI.Models;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CRM_UI.Storage
{
    /// <summary>
    /// Логика взаимодействия для Navigation_Bar.xaml
    /// </summary>
    public partial class Navigation_Bar : UserControl
    {
        private BindingList<TodoModel> _todoData;

        public Navigation_Bar()
        {
            InitializeComponent();

           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _todoData = new BindingList<TodoModel>()
            {
                new TodoModel(){vendorcode = "TF3667", Title = "Ботинки", Measurements = "шт", CostPrice = 15.92, Price = 58.99, Weight = 20, Volume = 5,
                Url = "https://intertop.ua/ua/catalog/muzhskaya_obuv/timberland-tbl-icon-6-double-collar/?gclid=CjwKCAiA_f3uBRAmEiwAzPuaM_sPzJBm0m52fmhYSmb-XRdfXYAEABhIVbFSJD2TM7uw-_NpOZe2HhoCcCMQAvD_BwE",
                InStock = false}
                
            };

            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT* FROM Goods;", conn);
                using (var reader = command.ExecuteReader())
                {
                    foreach (DbDataRecord record in reader)
                    {
                        _todoData.Add(new TodoModel()
                        {
                            vendorcode = record.GetInt64(0).ToString(),
                            Title = record.GetString(1),
                            Price = record.GetDouble(2)
                        }) ;
                       
                    }
                }
            }

            dgXAML.ItemsSource = _todoData;

            
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        
        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                NameTextBox.BorderBrush = Brushes.Red;
                NameTextBox.Foreground = Brushes.Red;

            }

            if (NameTextBox.Text.Length > 0)
            {
                NameTextBox.BorderBrush = Brushes.Blue;
                NameTextBox.Foreground = Brushes.Black;


                NameTextBox.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
            
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UnitTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UnitTxt.Text == "")
            {
                UnitTxt.BorderBrush = Brushes.Red;
                UnitTxt.Foreground = Brushes.Red;

            }

            if (UnitTxt.Text.Length > 0)
            {
                //NameTextBox.BorderBrush = Brushes.Gray;
                //NameTextBox.Foreground = Brushes.Black;


                UnitTxt.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style; 
            }
        }

        private void CostTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CostTxt.Text == "")
            {
                CostTxt.BorderBrush = Brushes.Red;
                CostTxt.Foreground = Brushes.Red;

            }

            if (CostTxt.Text.Length > 0)
            {
                CostTxt.BorderBrush = Brushes.Blue;
                CostTxt.Foreground = Brushes.Black;


                CostTxt.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
        }

        private void PriceTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PriceTxt.Text == "")
            {
                PriceTxt.BorderBrush = Brushes.Red;
                PriceTxt.Foreground = Brushes.Red;

            }

            if (PriceTxt.Text.Length > 0)
            {
                PriceTxt.BorderBrush = Brushes.Gray;
                PriceTxt.Foreground = Brushes.Black;


                PriceTxt.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
        }

        private void OpenPopUpBox_Click(object sender, RoutedEventArgs e)
        {
            OpenPopUpBox.Visibility = Visibility.Collapsed;
            ClosedPopUpBox.Visibility = Visibility.Visible;
        }

        private void ClosedPopUpBox_Click(object sender, RoutedEventArgs e)
        {
            OpenPopUpBox.Visibility = Visibility.Visible;
            ClosedPopUpBox.Visibility = Visibility.Collapsed;
        } 

        //private void btnOpenMaterial_Click(object sender, RoutedEventArgs e)
        //{
        //    //btnOpenMaterial.Visibility = Visibility.Collapsed;
        //    //btnCloseMaterial.Visibility = Visibility.Visible;
        //}
    }
}
