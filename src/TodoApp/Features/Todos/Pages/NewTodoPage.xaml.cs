namespace TodoApp;

public partial class NewTodoPage
{
    public NewTodoPage(NewTodoPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }

    private void OnPickDueDateButtonTapped(object sender, EventArgs e)
    {
        DueDatePicker.Focus();
    }

    private void OnSelectCategoryButtonTapped(object sender, EventArgs e)
    {
        CategoryPicker.Focus();
    }
}
