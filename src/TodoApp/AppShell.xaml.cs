namespace TodoApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("new-todo", typeof(NewTodoPage));
	}

	private async void OnMenuItemClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//LoginPage");
	}
}
