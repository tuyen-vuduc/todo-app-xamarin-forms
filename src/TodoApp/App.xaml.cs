using DryIoc;

namespace TodoApp;

public partial class App : Application
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
            DependencyService.RegisterSingleton<DryIoc.IContainer>(container);

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

        void RegisterTypes(DryIoc.IContainer container)
        {
            container.Register<IAppNavigator, AppNavigator>(Reuse.Singleton);
            container.Register(typeof(IRepository<>), typeof(Repository<>), Reuse.Singleton);
            container.RegisterInstance<TodosDbContext>(new TodosDbContext());
        }
}
