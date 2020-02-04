using System;
using System.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Markup;
using System.IO;
using System.Xml;
using System.Data.SQLite;
using System.Data.Common;
using CRM_UI.Models;
using CRM_UI.Storage.Chat;
using System.Collections.Generic;

namespace CRM_UI.Storage
{
    /// <summary>
    /// Логика взаимодействия для Storage_Window.xaml
    /// </summary>
    public partial class Storage_Window : UserControl
    {
        private BindingList<BaseModel> _todoData;
        long selected_categorie = 0;
        private int gridRow = 0;

        public Storage_Window()
        {
            InitializeComponent();
            _todoData = new BindingList<BaseModel>();

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
        private void ClearDataView()
        {
            //if(_todoData)
            _todoData.Clear();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SelectFolders();
            SelectGoods();
            UpdateDataView();
        }
        private void SelectFolders()
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM Categories;", conn);
                using (var reader = command.ExecuteReader())
                {
                    foreach (DbDataRecord record in reader)
                    {
                        _todoData.Add(new FolderModel()
                        {
                            vendorcode = record.GetInt64(0).ToString(),
                            Title = record.GetString(1),
                            icon_path = CRM_UI.String_Resources.Folder_icon_path
                        });
                    }
                }
            }
        }
        private void UpdateDataView()
        {
            dgXAML.ItemsSource = _todoData;
        }
        private void SelectGoods()
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"SELECT* FROM Goods WHERE ID_CATEGORI = {selected_categorie};", conn);
                using (var reader = command.ExecuteReader())
                {
                    foreach (DbDataRecord record in reader)
                    {
                        _todoData.Add(new ProductModel()
                        {
                            vendorcode = record.GetInt64(0).ToString(),
                            Title = record.GetString(1),
                            Price = record.GetDouble(2).ToString()
                        });

                    }
                }
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

        private void VendorTxt_TextChanged(object sender, TextChangedEventArgs e)
        {


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
                NameTextBox.BorderBrush = Brushes.Gray;
                NameTextBox.Foreground = Brushes.Black;


                NameTextBox.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
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
                UnitTxt.BorderBrush = Brushes.Gray;
                UnitTxt.Foreground = Brushes.Black;


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
                CostTxt.BorderBrush = Brushes.Gray;
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

        private void WeightTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void VolumetTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UrltTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxNumber.Text == "")
            {
                TextBoxNumber.BorderBrush = Brushes.Red;
                TextBoxNumber.Foreground = Brushes.Red;


                btnOnAdd.Visibility = Visibility.Collapsed;
                btnOffAdd.Visibility = Visibility.Visible;
            }

            if (TextBoxNumber.Text.Length > 0 && ComboBoxMaterial.SelectedIndex >= 0)
            {
                TextBoxNumber.BorderBrush = Brushes.Gray;
                TextBoxNumber.Foreground = Brushes.Black;


                btnOnAdd.Visibility = Visibility.Visible;
                btnOffAdd.Visibility = Visibility.Collapsed;
                TextBoxNumber.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }
        }

        private void ComboBoxMaterial_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ComboBoxMaterial.ItemsSource == null)
            {
                btnOnAdd.Visibility = Visibility.Collapsed;
                btnOffAdd.Visibility = Visibility.Visible;
            }
        }




        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GC.Collect();
        }

        private void ComboBoxMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxMaterial.SelectedIndex < 0)
            {
                ComboBoxMaterial.BorderBrush = Brushes.Red;
                ComboBoxMaterial.Foreground = Brushes.Red;


                btnOnAdd.Visibility = Visibility.Collapsed;
                btnOffAdd.Visibility = Visibility.Visible;
            }

            if (ComboBoxMaterial.SelectedIndex >= 0 && TextBoxNumber.Text.Length > 0)
            {
                ComboBoxMaterial.BorderBrush = Brushes.Gray;
                ComboBoxMaterial.Foreground = Brushes.Black;


                btnOnAdd.Visibility = Visibility.Visible;
                btnOffAdd.Visibility = Visibility.Collapsed;
                ComboBoxMaterial.Style = this.FindResource("MaterialDesignFloatingHintComboBox") as Style;
            }
        }

        private void TextBoxNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBoxNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Escape))
            {
                CancelDHMinusMaterial.Command.Execute("x:Static materialDesign:DialogHost.CloseDialogCommand");
            }
            if (e.Key.Equals(Key.LeftCtrl) || e.Key.Equals(Key.RightCtrl))
                e.Handled = true;
        }

        private void TextBoxNumber_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
         e.Command == ApplicationCommands.Cut ||
         e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void popupbox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.Focusable = true;
            this.Focus();
        }

        private void CancelMaterialWindow_Cancel_MouseEnter(object sender, MouseEventArgs e)
        {
            CancelMaterialWindow_Cancel.Style = this.FindResource("MaterialDesignFloatingActionMiniAccentButton") as Style;
            CancelMaterialWindow_Cancel.Background = Brushes.Red;
        }
        private void CancelMaterialWindow_Cancel_MouseLeave(object sender, MouseEventArgs e)
        {
            CancelMaterialWindow_Cancel.Background = null;
            CancelMaterialWindow_Cancel.Style = this.FindResource("MaterialDesignFloatingActionMiniAccentButton") as Style;
        }

        private void dgXAML_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgXAML.SelectedItem is FolderModel)
            {
                selected_categorie = long.Parse((dgXAML.SelectedItem as FolderModel).vendorcode);
                ClearDataView();
                if (selected_categorie > 0)
                {
                    AddReturnFolder();
                    SelectGoods();
                }
                else
                {
                    SelectFolders();
                }
            }
            if (dgXAML.SelectedItem is ProductModel)
            {
                MessageBox.Show((dgXAML.SelectedItem as ProductModel).Title);
            }
            UpdateDataView();
        }

        private void AddReturnFolder()
        {
            _todoData.Add(new FolderModel() { icon_path = CRM_UI.String_Resources.Folder_return_icon_path, Title = CRM_UI.String_Resources.Folder_return_text, vendorcode = "0" });
        }

        private void AddCategorie_btn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"INSERT INTO Categories(NAME) values(@name);", conn);
                command.Parameters.Add(new SQLiteParameter("@name", NameCategorie_Tb.Text));
                command.ExecuteNonQuery();
            }
            GC.Collect();
            ClearDataView();
            SelectFolders();
            UpdateDataView();

        }

        private void OpenMaterial_Loaded(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM Categories;", conn);
                using (var reader = command.ExecuteReader())
                {
                    foreach (DbDataRecord record in reader)
                    {
                        SelectCategorie_CB.Items.Add(record.GetString(1));
                    }
                }
            }
            SelectCategorie_CB.SelectedIndex = 0;
        }

        private void AddMaterial_Btn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"INSERT INTO Goods(NAME,PRICE,ID_CATEGORI) values(@name,@price,@cat_id);", conn);
                command.Parameters.Add(new SQLiteParameter("@name", NameTextBox.Text));
                command.Parameters.Add(new SQLiteParameter("@price", PriceTxt.Text));
                command.Parameters.Add(new SQLiteParameter("@cat_id", ++SelectCategorie_CB.SelectedIndex));
                command.ExecuteNonQuery();
            }
        }

        private void btnOnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"DELETE FROM Goods WHERE NAME = '{ComboBoxMaterial.Items[ComboBoxMaterial.SelectedIndex].ToString()}';", conn);
                command.ExecuteNonQuery();
            }
            GC.Collect();
            ClearDataView();
            SelectFolders();
            UpdateDataView();
        }
        private void ComboBoxMaterial_Loaded(object sender, RoutedEventArgs e)
        {
            if (ComboBoxMaterial.Items.Count > 0)
                ComboBoxMaterial.Items.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"SELECT* FROM Goods;", conn);
                using (var reader = command.ExecuteReader())
                {
                    foreach (DbDataRecord record in reader)
                    {
                        ComboBoxMaterial.Items.Add(record.GetString(1));
                    }
                }
            }
        }

        private void AddCbTb_Btn_Click(object sender, RoutedEventArgs e)
        {
            GenerateNewGoodLine();

        }
        private void GenerateNewGoodLine()
        {
            gridRow++;
            Grid innerGrid = new Grid();
            innerGrid.Name = $"Grid_{gridRow}";
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            innerGrid.ColumnDefinitions.Add(new ColumnDefinition());

            MaterialsPanel.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            MaterialsPanel.Children.Add(innerGrid);
            Grid.SetRow(innerGrid, gridRow);


            var c = (ComboBox)XamlReader.Load(XmlReader.Create(new StringReader(XamlWriter.Save(AddMaterial_Cb))));
            var t = ((TextBox)XamlReader.Load(XmlReader.Create(new StringReader(XamlWriter.Save(AddNumber_Tb)))));
            var b = (Button)XamlReader.Load(XmlReader.Create(new StringReader(XamlWriter.Save(DelCbTb_Btn))));

            innerGrid.Children.Add(c);
            Grid.SetColumn(c, 0);
            innerGrid.Children.Add(t);
            Grid.SetColumn(t, 1);
            t.PreviewTextInput += AddNumber_Tb_PreviewTextInput;
            innerGrid.Children.Add(b);
            Grid.SetColumn(b, 2);
            b.Visibility = Visibility.Visible;
            b.Click += deleteThisGrid;

        }

        private void deleteThisGrid(object sender, RoutedEventArgs e)
        {
            MaterialsPanel.Children.Remove((sender as Button).Parent as Grid);
        }

        private void AddMaterialOnStorage_Btn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddMaterialOnStorage_Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            AddMaterialOnStorage_Btn.Background = null;
            AddMaterialOnStorage_Btn.Foreground = Brushes.Gray;
            AddMaterialOnStorage_Btn.BorderBrush = Brushes.Gray;
        }

        private void AddMaterialOnStorage_Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            AddMaterialOnStorage_Btn.Background = Brushes.Gray;
            AddMaterialOnStorage_Btn.Foreground = Brushes.White;
        }

        private void Cancel_Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Cancel_Btn.Background = null;
            Cancel_Btn.Foreground = Brushes.Gray;
            Cancel_Btn.BorderBrush = Brushes.Gray;
        }

        private void Cancel_Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Cancel_Btn.Background = Brushes.Gray;
            Cancel_Btn.Foreground = Brushes.White;
        }

        private void AddMaterialOnStorageTwo_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddMaterial_Cb_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (AddMaterial_Cb.ItemsSource == null)
            {
                AddMaterialOnStorageTwo_Btn.Visibility = Visibility.Collapsed;
                AddMaterialOnStorage_Btn.Visibility = Visibility.Visible;
            }
        }

        private void AddMaterial_Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AddMaterial_Cb.SelectedIndex < 0)
            {
                AddMaterial_Cb.BorderBrush = Brushes.Red;
                AddMaterial_Cb.Foreground = Brushes.Red;


                AddMaterialOnStorageTwo_Btn.Visibility = Visibility.Collapsed;
                AddMaterialOnStorage_Btn.Visibility = Visibility.Visible;
            }

            if (AddMaterial_Cb.SelectedIndex >= 0 && AddNumber_Tb.Text.Length > 0)
            {
                AddMaterial_Cb.BorderBrush = Brushes.Gray;
                AddMaterial_Cb.Foreground = Brushes.Black;


                AddMaterialOnStorageTwo_Btn.Visibility = Visibility.Visible;
                AddMaterialOnStorage_Btn.Visibility = Visibility.Collapsed;
                AddMaterial_Cb.Style = this.FindResource("MaterialDesignFloatingHintComboBox") as Style;
            }
        }

        private void AddNumber_Tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void AddNumber_Tb_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
         e.Command == ApplicationCommands.Cut ||
         e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }

        }

        private void AddNumber_Tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AddNumber_Tb.Text == "")
            {
                AddNumber_Tb.BorderBrush = Brushes.Red;
                AddNumber_Tb.Foreground = Brushes.Red;


                AddMaterialOnStorageTwo_Btn.Visibility = Visibility.Collapsed;
                AddMaterialOnStorage_Btn.Visibility = Visibility.Visible;
            }

            if (AddNumber_Tb.Text.Length > 0)
            {
                AddNumber_Tb.BorderBrush = Brushes.Gray;
                AddNumber_Tb.Foreground = Brushes.Black;

                if (AddMaterial_Cb.SelectedIndex >= 0)
                {
                    AddMaterialOnStorage_Btn.Visibility = Visibility.Collapsed;
                    AddMaterialOnStorageTwo_Btn.Visibility = Visibility.Visible;
                }
                AddNumber_Tb.Style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            }

        }

        private void OpenAddMaterial_Loaded(object sender, RoutedEventArgs e)
        {


            GC.Collect();
            //GenerateNewGoodLine();
        }

        private void CancelMaterialWindow_Cancel_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }

        private void ContactGrupe_btn_Click(object sender, RoutedEventArgs e)
        {
            //int index = int.Parse(((Button)e.Source).Uid);

            //GridCursor.Margin = new Thickness(10 + (170 * index), 0, 0, 0);

            //switch (index)
            //{
            //    case 0:
            //        ChatUsers_Grid.Children.Clear();
            //        ChatUsers_Grid.Children.Add(new UserControlListUser());
            //        break;

            //    case 1:
            //        ChatUsers_Grid.Children.Clear();
            //        ChatUsers_Grid.Children.Add(new UserControlListAdmin());
            //        break;
            //    default:
            //        break;
            //}


        }

        private void StartChatWithUser_btn_Click(object sender, RoutedEventArgs e)
        {

            
        }

        private void Chat_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WindowChat_Initialized(object sender, EventArgs e)
        {
            //List<string> users = new List<string>();
            //using (SQLiteConnection conn = new SQLiteConnection(string.Format($"Data Source=TestDB.db;")))
            //{
            //    conn.Open();
            //    SQLiteCommand command = new SQLiteCommand($"SELECT* FROM [User];", conn);
            //    using (var reader = command.ExecuteReader())
            //    {
            //        foreach (DbDataRecord record in reader)
            //        {
            //            users.Add(record.GetValue(0).ToString());

            //        }
            //    }
            //}
            //foreach (var item in users)
            //{
            //    ChatUsers_Grid.Children.Add(new Label() { Content = item });
            //}
        }
    }
}
