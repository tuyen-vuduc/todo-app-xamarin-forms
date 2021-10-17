using System;
using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace TodoApp.Tests.Features.Todos.ViewModels
{
    public class NewTodoViewModelTests : BaseUT<NewTodoPageViewModel>
    {
        [Fact]
        public async Task ViewAppearing_ShouldSetDefaultValues()
        {
            await Sut.OnAppearingAsync();

            Assert.Equal("Business", Sut.Category);
            Assert.Equal(DateTime.Today.Date, Sut.DueDate.Date);
        }
        
        [Fact]
        public async Task ViewAppearing_ShouldNotResetCategory_WhenCategoryIsAlreadySet()
        {
            // Arrange
            var expectedCategory = "new category";
            var expectedDueDate = DateTime.Now.AddDays(10).Date;
            Sut.Category = expectedCategory;
            Sut.DueDate = expectedDueDate;
            
            // Act
            await Sut.OnAppearingAsync();
            
            Assert.Equal(expectedCategory, Sut.Category);
            Assert.Equal(expectedDueDate, Sut.DueDate.Date);
        }

        [Fact]
        public void CloseCommand_ShouldInvokeAppNavigatorGoBack()
        {
            // Arrange
            var appNavigatorMock = Mocker.GetMock<IAppNavigator>();
            
            // Act
            Sut.CloseCommand.Execute(null);

            // Act
            appNavigatorMock.Verify(
                x => x.GoBackAsync(It.IsAny<object>()),
                Times.Once);
        }
        
        [Fact]
        public async Task SaveCommand_ShouldSaveNewTodoAndInvokeAppNavigatorGoBack_WhenTitleIsValid()
        {
            // Arrange
            var appNavigatorMock = Mocker.GetMock<IAppNavigator>();
            var todoRepositoryMock = Mocker.GetMock<IRepository<TodoEntity>>();

            await Sut.OnAppearingAsync();
            Sut.Title = "A task on test";
            
            // Act
            Sut.SaveCommand.Execute(null);

            // Act
            todoRepositoryMock.Verify(
                x => x.InsertAsync(It.IsAny<TodoEntity>()),
                Times.Once);
            appNavigatorMock.Verify(
                x => x.GoBackAsync(It.IsAny<object>()),
                Times.Once);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task SaveCommand_ShouldNotSaveNewTodoAndNotInvokeAppNavigatorGoBack_WhenTitleIsNotValid(string title)
        {
            // Arrange
            var appNavigatorMock = Mocker.GetMock<IAppNavigator>();
            var todoRepositoryMock = Mocker.GetMock<IRepository<TodoEntity>>();

            await Sut.OnAppearingAsync();
            Sut.Title = title;
            
            // Act
            Sut.SaveCommand.Execute(null);

            // Act
            todoRepositoryMock.Verify(
                x => x.InsertAsync(It.IsAny<TodoEntity>()),
                Times.Never);
            appNavigatorMock.Verify(
                x => x.GoBackAsync(It.IsAny<object>()),
                Times.Never);
        }
        
        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        public void ToggleCommand_ShouldToggleIsFlaggedValue(bool beforeToggled, bool expected)
        {
            // Arrange
            Sut.IsFlagged = beforeToggled;
            
            // Act
            Sut.ToggleFlaggedCommand.Execute(null);

            // Act
            Assert.Equal(expected, Sut.IsFlagged);
        }
    }
}

