using System;
using Xunit;

namespace TodoApp.Tests.Core.Converters
{
    public class DueDateConverterTests
    {
        [Theory]
        [InlineData("2018-09-01", "Today, Sep 01")]
        [InlineData("2018-09-01T11:11:11", "Today, Sep 01")]
        public void Convert_ShouldReturnTodayString(string dueDateString, string expected)
        {
            var dueDate = DateTime.Parse(dueDateString);
            var sut = new DueDateConverter(() => dueDate.Date);

            var result = sut.Convert(dueDate, null, null, null);
            
            Assert.True(result is string);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("2018-09-01", "Tomorrow, Sep 01")]
        [InlineData("2018-09-01T11:11:11", "Tomorrow, Sep 01")]
        public void Convert_ShouldReturnTomorrowString(string dueDateString, string expected)
        {
            var dueDate = DateTime.Parse(dueDateString);
            var sut = new DueDateConverter(() => dueDate.Date.AddDays(-1));

            var result = sut.Convert(dueDate, null, null, null);
            
            Assert.True(result is string);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("2018-09-01", "Yesterday, Sep 01")]
        [InlineData("2018-09-01T11:11:11", "Yesterday, Sep 01")]
        public void Convert_ShouldReturnYesterdayString(string dueDateString, string expected)
        {
            var dueDate = DateTime.Parse(dueDateString);
            var sut = new DueDateConverter(() => dueDate.Date.AddDays(1));

            var result = sut.Convert(dueDate, null, null, null);
            
            Assert.True(result is string);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("2018-09-01", "Saturday, Sep 01", true)]
        [InlineData("2018-09-01T11:11:11", "Saturday, Sep 01", true)]
        [InlineData("2018-09-01", "Saturday, Sep 01", false)]
        [InlineData("2018-09-01T11:11:11", "Saturday, Sep 01", false)]
        public void Convert_ShouldReturnDayOfMonthAndWeekDayString_WhenDueDateIsWithin30DayRange(string dueDateString, string expected, bool inThePast)
        {
            var random = new Random();
            var days = random.Next(2, 31);
            var dueDate = DateTime.Parse(dueDateString);
            var sut = new DueDateConverter(() => dueDate.Date.AddDays(
                (inThePast ? -1 : 1) * days
            ));

            var result = sut.Convert(dueDate, null, null, null);
            
            Assert.True(result is string);
            Assert.Equal(expected, result);
        }
        
        
        [Theory]
        [InlineData("2018-09-01", "Sep 01, 2018", true)]
        [InlineData("2018-09-01T11:11:11", "Sep 01, 2018", true)]
        [InlineData("2018-09-01", "Sep 01, 2018", false)]
        [InlineData("2018-09-01T11:11:11", "Sep 01, 2018", false)]
        public void Convert_ShouldReturnLongDateString_WhenDueDateIsWithin30DayRange(string dueDateString, string expected, bool inThePast)
        {
            var random = new Random();
            var days = random.Next(31, 100);
            var dueDate = DateTime.Parse(dueDateString);
            var sut = new DueDateConverter(() => dueDate.Date.AddDays(
                (inThePast ? -1 : 1) * days
            ));

            var result = sut.Convert(dueDate, null, null, null);
            
            Assert.True(result is string);
            Assert.Equal(expected, result);
        }
    }
}