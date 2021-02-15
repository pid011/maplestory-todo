using System.Windows.Controls;
using MaplestoryTodo.ViewModels;

namespace MaplestoryTodo.Views
{
    /// <summary>
    /// Interaction logic for TodoControl.xaml
    /// </summary>
    public partial class Todo : UserControl
    {
        public Todo()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = DataContext as TodoViewModel;
            item.Todos.RemoveAt(item.SelectedTodoIndex);
        }
    }
}
