namespace TodoApp;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class TodosPageViewModel : NavigationAwareBaseViewModel
{
    private readonly TodosService _todosService;

    public TodosPageViewModel(
        TodosService todosService,
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        _todosService = todosService;

        CurrentUser = new UserModel
        {
            FirstName = "Andrew",
            LastName = "Wu",
        };

        MenuItems = GetMenuItems();
    }

    [ObservableProperty]
    UserModel currentUser;

    [ObservableProperty]
    ObservableCollection<MenuItemModel> menuItems;

    [ObservableProperty]
    ObservableCollection<TodoModel> items;

    [ObservableProperty]
    ObservableCollection<TaskStatisticModel> taskStatistics;

    [ObservableProperty]
    ObservableCollection<int> taskCountByDays;

    [ObservableProperty]
    bool sidebarMenuVisible;

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        if (TaskStatistics == null)
        {
            categories = await _todosService.GetCategoriesAsync();

            var taskStatistics = categories.Select(x => new TaskStatisticModel
            {
                Category = x,
                DoneTaskCount = 0,
                TotalTaskCount = 0,
            });
            TaskStatistics = new ObservableCollection<TaskStatisticModel>(taskStatistics);
        }

        var items = await _todosService.GetTodayTasksAsync();

        Items = new ObservableCollection<TodoModel>(items);

        RefreshStatistics();
        await RefreshChart();
    }

    private async Task RefreshChart()
    {
        var items = await _todosService.GetTaskCountsByDay();

        TaskCountByDays = new ObservableCollection<int>(items);
    }

    private void RefreshStatistics()
    {
        var tempItems = categories.Select(x => new TodoModel
        {
            Category = x
        });
        var groupedByCategory = Items.Union(tempItems).GroupBy(x => x.Category)
            .Select(x => new TaskStatisticModel
            {
                Category = x.Key,
                DoneTaskCount = x.Count(y => y.IsDone && y.Id != Guid.Empty),
                TotalTaskCount = x.Count(y => y.Id != Guid.Empty)
            });

        TaskStatistics = new ObservableCollection<TaskStatisticModel>(groupedByCategory);
    }

    private static ObservableCollection<MenuItemModel> GetMenuItems()
    {
        return new ObservableCollection<MenuItemModel>(new[] {
            new MenuItemModel
            {
                Icon = Mdi.Bookmark,
                Text = "Templates",
            },
            new MenuItemModel
            {
                Icon = Mdi.FolderMultiple,
                Text = "Categories",
            },
            new MenuItemModel
            {
                Icon = Mdi.ChartArc,
                Text = "Analytics",
            },
            new MenuItemModel
            {
                Icon = Mdi.Cog,
                Text = "Settings",
            },
        });
    }

    public ICommand CreateCommand => _CreateCommand ??= new Command(ExecuteCreateCommand);
    ICommand _CreateCommand;
    void ExecuteCreateCommand()
    {
        AppNavigator.NavigateAsync("new-todo");
    }

    public ICommand ToggleDoneCommand => _ToggleDoneCommand ??= new Command<TodoModel>(ExecuteToggleDoneCommand);
    ICommand _ToggleDoneCommand;
    async void ExecuteToggleDoneCommand(TodoModel model)
    {
        var marked = await _todosService.ToggleDoneAsync(model);

        if (!marked) return;

        model.IsDone = !model.IsDone;
        RefreshStatistics();
    }

    public ICommand DeleteCommand => _DeleteCommand ??= new Command<TodoModel>(ExecuteDeleteCommand);
    ICommand _DeleteCommand;
    private IEnumerable<string> categories;

    async void ExecuteDeleteCommand(TodoModel model)
    {
        var confirmed = await Application.Current.MainPage.DisplayAlert(
            "Warning!",
            "Are you sure to delete this todo item?",
            "Yes",
            "Cancel"
            );

        if (!confirmed) return;

        var deleted = await _todosService.DeleteAsync(model);

        if (!deleted) return;

        Items.Remove(model);
        RefreshStatistics();
    }
}
