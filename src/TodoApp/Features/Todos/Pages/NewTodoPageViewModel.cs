using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TodoApp
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class NewTodoPageViewModel : BaseViewModel
    {
        private readonly TodosService todosService;

        public NewTodoPageViewModel(
            TodosService todosService,
            IAppNavigator appNavigator)
            : base(appNavigator)
        {
            this.todosService = todosService;
        }

        public string Title { get; set; }
        public string Category { get; set; }
        public bool IsFlagged { get; set; }
        public DateTime DueDate { get; set; }

        public string[] Categories { get; set; }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();

            if (string.IsNullOrWhiteSpace(Category))
            {
                var categories = await todosService.GetCategoriesAsync();
                Categories = categories.ToArray();

                DueDate = DateTime.Today;
                Category = Categories[0];
            }
        }

        public ICommand SaveCommand => _SaveCommand ??= new Command(ExecuteSaveCommand);
        ICommand _SaveCommand;
        async void ExecuteSaveCommand()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                // TODO show error
                return;
            }

            await todosService.InsertAsync(new TodoEditingModel
            {
                Title = Title,
                Category = Category,
                IsFlagged = IsFlagged,
                DueDate = DueDate,
                CreatedAt = DateTime.Now,
                LastModified = DateTime.Now,
            });

            await AppNavigator.GoBackAsync();
        }

        public ICommand CloseCommand => _CloseCommand ??= new Command(ExecuteCloseCommand);
        ICommand _CloseCommand;
        void ExecuteCloseCommand()
        {
            AppNavigator.GoBackAsync();
        }

        public ICommand ToggleFlaggedCommand => _ToggleFlaggedCommand ??= new Command(ExecuteToggleFlaggedCommand);
        ICommand _ToggleFlaggedCommand;
        void ExecuteToggleFlaggedCommand()
        {
            IsFlagged = !IsFlagged;
        }
    }
}
