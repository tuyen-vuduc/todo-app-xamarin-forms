namespace TodoApp
{
    public partial class TodoItemView
    {
        public TodoItemView()
        {
            InitializeComponent();
        }

        public static BindableProperty ToggleDoneCommandProperty = BindableProperty.Create(
            nameof(ToggleDoneCommand),
            typeof(ICommand),
            typeof(TodoItemView),
            null
            );
        public ICommand ToggleDoneCommand
        {
            get => GetValue(ToggleDoneCommandProperty) as ICommand;
            set => SetValue(ToggleDoneCommandProperty, value);
        }

        public static BindableProperty DeleteCommandProperty = BindableProperty.Create(
            nameof(DeleteCommand),
            typeof(ICommand),
            typeof(TodoItemView),
            null
            );
        public ICommand DeleteCommand
        {
            get => GetValue(DeleteCommandProperty) as ICommand;
            set => SetValue(DeleteCommandProperty, value);
        }

    }
}
