using System.Collections.ObjectModel;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;

namespace MaplestoryTodo.ViewModels
{
    public class TodoItem : BindableBase
    {
        private static readonly Style s_defaultNameStyle =
            Application.Current.FindResource("TextBlockDefault") as Style;

        private static readonly Style s_checkedNameStyle =
            Application.Current.FindResource("TextBlockDefaultThiLight") as Style;

        private bool _isCompleted;
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                NameStyle = value ? s_checkedNameStyle : s_defaultNameStyle;

                SetProperty(ref _isCompleted, value);
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private Style _nameStyle;
        public Style NameStyle
        {
            get => _nameStyle;
            set => SetProperty(ref _nameStyle, value);
        }

        private int _index;
        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }
    }

    public class TodoViewModel : BindableBase
    {
        private string _newTodo;
        public string NewTodo
        {
            get => _newTodo;
            set => SetProperty(ref _newTodo, value);
        }

        private readonly ObservableCollection<TodoItem> _todos = new ObservableCollection<TodoItem>();
        public ObservableCollection<TodoItem> Todos => _todos;

        private int _selectedTodoIndex;
        public int SelectedTodoIndex
        {
            get => _selectedTodoIndex;
            set => SetProperty(ref _selectedTodoIndex, value);
        }

        private TodoItem _selectedTodoItem;
        public TodoItem SelectedTodoItem
        {
            get => _selectedTodoItem;
            set => SetProperty(ref _selectedTodoItem, value);
        }

        private DelegateCommand _addTodoItemCommand = null;
        public DelegateCommand AddTodoItemCommand
        {
            get
            {
                if (_addTodoItemCommand is null)
                {
                    _addTodoItemCommand = new DelegateCommand(AddTodo);
                }
                return _addTodoItemCommand;
            }
        }

        private DelegateCommand _deleteTodoItemCommand = null;
        public DelegateCommand DeleteTodoItemCommand
        {
            get
            {
                if (_deleteTodoItemCommand is null)
                {
                    _deleteTodoItemCommand = new DelegateCommand(DeleteTodo);
                }
                return _deleteTodoItemCommand;
            }
        }

        public TodoViewModel()
        {
            _selectedTodoIndex = -1;
        }

        private void AddTodo()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_newTodo))
                {
                    return;
                }

                Todos.Add(new TodoItem { IsCompleted = false, Name = _newTodo });
            }
            finally
            {
                NewTodo = string.Empty;
            }
        }

        private void DeleteTodo()
        {
            if (_selectedTodoIndex == -1)
            {
                return;
            }

            Todos.RemoveAt(_selectedTodoIndex);
        }
    }
}
