using System.Windows;
using System.Windows.Controls;
using HandyControl.Themes;

namespace MaplestoryTodo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonConfig_OnClick(object sender, RoutedEventArgs e) => PopupConfig.IsOpen = true;

        private void ButtonSkins_OnClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                // PopupConfig.IsOpen = false;
                if (button.Tag is ApplicationTheme tag)
                {
                    App.UpdateTheme(tag);
                }
            }
        }
    }
}
