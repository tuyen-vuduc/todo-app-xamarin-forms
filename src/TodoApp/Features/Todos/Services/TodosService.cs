namespace TodoApp;

// ReSharper disable once ClassNeverInstantiated.Global
public class TodosService
{
    private readonly IRepository<TodoEntity> todoRepository;
    private readonly  Random random = new Random();

    static readonly string[] Categories = {
        "Business",
        "Personal"
    };

    public TodosService(IRepository<TodoEntity> todoRepository)
    {
        this.todoRepository = todoRepository;
    }

    public async Task InsertAsync(TodoEditingModel model)
    {
        await todoRepository.InsertAsync(new TodoEntity
        {
            Title = model.Title,
            Category = model.Category,
            DueDate = model.DueDate,
            IsFlagged = model.IsFlagged,
        });
    }

    public async Task<IEnumerable<TodoModel>> GetTodayTasksAsync()
    {
        var entities = await todoRepository.GetAllAsync(x => !x.IsDeleted && x.DueDate.Date == DateTime.Today);

        return entities.Select(x => new TodoModel
        {
            Id = x.Id,
            Title = x.Title,
            IsDone = x.IsDone,
            Category = x.Category,
        });
    }

    public Task<IEnumerable<string>> GetCategoriesAsync()
    {
        return Task.FromResult((IEnumerable<string>)Categories);
    }

    public async Task<bool> DeleteAsync(TodoModel model)
    {
        if (model == null) return false;

        var result = await todoRepository.DeleteAsync(model.Id);

        return result;
    }

    public async Task<bool> ToggleDoneAsync(TodoModel model)
    {
        var entity = await todoRepository.GetAsync(model.Id);

        if (entity == null) return false;

        entity.IsDone = !entity.IsDone;
        entity.LastModified = DateTime.Now;

        var result = await todoRepository.UpdateAsync(entity);

        return result;
    }

    public Task<int[]> GetTaskCountsByDay()
    {
        var taskCounts = new List<int>();
        
        for (int i = 0; i < 20; i++)
        {
            taskCounts.Add(random.Next(10));
        }

        return Task.FromResult(taskCounts.ToArray());
    }
}

