using System.Windows;
using System.Windows.Controls;

namespace CRM_UI.Storage.Chat
{
    /// <summary>
    /// Логика взаимодействия для WindowHomeChat.xaml
    /// </summary>
    public partial class WindowHomeChat : UserControl
    {
        public WindowHomeChat()
        {
            InitializeComponent();
        }

        private void ContactGrupe_btn_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (170 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    ChatUsers_Grid.Children.Clear();
                    ChatUsers_Grid.Children.Add(new UserControlListUser());
                    break;

                case 1:
                    ChatUsers_Grid.Children.Clear();
                    ChatUsers_Grid.Children.Add(new UserControlListAdmin());
                    break;
                default:
                    break;
            }
        }
    }
}
