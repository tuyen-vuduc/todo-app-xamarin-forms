using System;
using Xunit;

namespace TodoApp.Tests.Core.Converters
{
    public class TaskCountConverterTests : BaseUT<TaskCountConverter>
    {
        [Theory]
        [InlineData(0, "0 tasks")]
        [InlineData(1, "1 task")]
        [InlineData(2, "2 tasks")]
        public void Convert_ShouldReturnFormattedString(int taskCount, string expected)
        {
            var result = Sut.Convert(taskCount, null, null, null);

            Assert.Equal(expected, result);
        }
    }
}
