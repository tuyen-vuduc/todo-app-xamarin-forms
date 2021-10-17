using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace TodoApp.Tests.Features.Todos.ViewModels
{
    public class TodosViewModelTests : BaseUT<TodosPageViewModel>
    {
        [Fact]
        public async Task ViewIsAppearing_ShouldLoadLatestTodosFromDb()
        {
            var todoRepositoryMock = Mocker.GetMock<IRepository<TodoEntity>>();

            var items = TodosFactory.Instance.GetTodos();
            todoRepositoryMock.Setup(
                    x => x.GetAllAsync(
                        It.IsAny<Expression<Func<TodoEntity, bool>>>()
                    )
                )
                // ReSharper disable once PossibleMultipleEnumeration
                .ReturnsAsync(items);

            await Sut.OnAppearingAsync();

            // ReSharper disable once PossibleMultipleEnumeration
            Assert.Equal(items.Count(), Sut.Items.Count);
        }
        
        [Fact]
        public void CreateCommand_ShouldInvokeAppNavigatorNavigate()
        {
            // Arrange
            var appNavigatorMock = Mocker.GetMock<IAppNavigator>();
            
            // Act
            Sut.CreateCommand.Execute(null);

            // Act
            appNavigatorMock.Verify(
                x => x.NavigateAsync("new-todo", It.IsAny<object>()),
                Times.Once);
        }

    }
}