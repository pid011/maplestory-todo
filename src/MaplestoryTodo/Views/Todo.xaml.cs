using System.Diagnostics;
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

        private void TodoItem_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Debug.WriteLine(TodoListBox.SelectedItem.GetType().ToString());
            (TodoListBox.SelectedItem as TodoItemViewModel).Name = "Test";
        }
    }
}
