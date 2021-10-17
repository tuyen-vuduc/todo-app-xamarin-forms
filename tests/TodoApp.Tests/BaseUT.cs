using Moq.AutoMock;

namespace TodoApp.Tests
{
    public abstract class BaseUT<T> where T : class
    {
        protected T Sut { get; private set; }
        protected AutoMocker Mocker { get; private set; }

        protected BaseUT()
        {
            Mocker = new AutoMocker();

            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterInstances();

            Sut = Mocker.CreateInstance<T>();
        }

        protected virtual void RegisterInstances()
        {
            Mocker.Use(Mocker.CreateInstance<TodosService>());
        }
    }
}