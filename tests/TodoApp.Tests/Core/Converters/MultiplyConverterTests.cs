using System;
using Xunit;

namespace TodoApp.Tests.Core.Converters
{
    public class MultiplyConverterTests : BaseUT<MultiplyConverter>
    {
        [Theory]
        [InlineData(new object[] { 1, 2, 3 }, 6)]
        [InlineData(new object[] { 1, "2", 3 }, 6)]
        public void Convert_ShouldReturnThenMultipliedResult(object[] values, double expected)
        {
            var result = Sut.Convert(values, null, null, null);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new object[] { 1, "2a", 3 }, 3)]
        [InlineData(new object[] { true, "2a", 3 }, 3)]
        public void Convert_ShouldReturnThenMultipliedResultAndSkipInvalidValue(object[] values, double expected)
        {
            var result = Sut.Convert(values, null, null, null);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new object[] { 1, "2a", 8 }, 3)]
        [InlineData(new object[] { true, "2a", 8 }, 3)]
        public void Convert_ShouldReturnMaxValue_WhenTheResultIsHigherThanGivenMaxValue(object[] values, double expected)
        {
            var sut = new MultiplyConverter();

            var result = sut.Convert(values, null, expected, null);

            Assert.Equal(expected, result);
        }
    }
}

