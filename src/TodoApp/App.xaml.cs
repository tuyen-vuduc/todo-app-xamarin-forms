using Xamarin.Forms;
using DryIoc;
using Acr.UserDialogs;

namespace TodoApp
{
    public partial class App
    {

        public App()
        {
            InitializeComponent();

            var container = new Container(rules => rules
                            .WithAutoConcreteTypeResolution()
                            .WithDefaultReuse(Reuse.Singleton));
            RegisterTypes(container);
    
            // We need to register a IContainer instance to DependencyService
            // so we could activate an VM instance in BindingContext extension.
            DependencyService.RegisterSingleton<IContainer>(container);

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        void RegisterTypes(IContainer container)
        {
            container.Register<IAppNavigator, AppNavigator>(Reuse.Singleton);
            container.Register<IRepository<TodoEntity>, TodoRepository>(Reuse.Singleton);
            container.RegisterInstance<TodosDbContext>(new TodosDbContext());
            container.RegisterInstance<IUserDialogs>(UserDialogs.Instance);
        }

    }
}
