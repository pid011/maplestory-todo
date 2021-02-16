using System.Windows;
using Prism.Commands;
using Prism.Mvvm;

namespace MaplestoryTodo.ViewModels
{
    public class TodoItemViewModel : BindableBase
    {
        private static readonly Style s_defaultNameStyle =
            Application.Current.FindResource("TextBlockDefault") as Style;

        private static readonly Style s_checkedNameStyle =
            Application.Current.FindResource("TextBlockDefaultThiLight") as Style;

        private bool _isCompleted = true;
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                NameStyle = value ? s_checkedNameStyle : s_defaultNameStyle;
                SetProperty(ref _isCompleted, value);
            }
        }

        private string _name = "test";
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

        private DelegateCommand _todoCheckCommand;
        public DelegateCommand TodoCheckCommand => _todoCheckCommand ??= new DelegateCommand(CheckTodo);



        private void CheckTodo() => IsCompleted = !IsCompleted;
    }
}
