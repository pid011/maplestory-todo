using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;

namespace MaplestoryTodo.ViewModels
{
    public class TodoViewModel : BindableBase
    {
        private string _newTodo;
        public string NewTodo
        {
            get => _newTodo;
            set => SetProperty(ref _newTodo, value);
        }

        private readonly ObservableCollection<TodoItemViewModel> _todos = new ObservableCollection<TodoItemViewModel>();
        public ObservableCollection<TodoItemViewModel> Todos => _todos;

        private int _selectedTodoIndex;
        public int SelectedTodoIndex
        {
            get => _selectedTodoIndex;
            set => SetProperty(ref _selectedTodoIndex, value);
        }

        private TodoItemViewModel _selectedTodoItem;
        public TodoItemViewModel SelectedTodoItem
        {
            get => _selectedTodoItem;
            set => SetProperty(ref _selectedTodoItem, value);
        }

        private DelegateCommand _todoItemAddCommand;
        public DelegateCommand TodoItemAddCommand => _todoItemAddCommand ??= new DelegateCommand(AddTodo);

        private DelegateCommand _todoItemDeleteCommand;
        public DelegateCommand TodoItemDeleteCommand => _todoItemDeleteCommand ??= new DelegateCommand(DeleteTodo);

        private void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(_newTodo))
            {
                Todos.Add(new TodoItemViewModel());
            }
            NewTodo = string.Empty;
        }

        private void DeleteTodo()
        {
            if (_selectedTodoIndex >= 0)
            {
                Todos.RemoveAt(_selectedTodoIndex);
            }
        }
    }
}
