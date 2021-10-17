using Xunit;

namespace TodoApp.Tests.Core.Navigation
{
    public class UriHelperTests
    {
        [Theory]
        [InlineData("sample-uri", "sample-uri")]
        [InlineData("sample-uri?existing-query=1", "sample-uri?existing-query=1")]
        public void BuildUri_ShouldReturnUriWithoutAnyAdditionalQueryParameter_WhenNoDataProvided(string input, string expected)
        {
            // Arrange

            // Act
            var result = UriHelper.EnsureUri(input);

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("..", 1, "..?__DATA__=1&__GOBACK__=true")]
        [InlineData("sample-uri?existing-query=1", "2", "sample-uri?existing-query=1&__DATA__=%222%22")]
        public void BuildUri_ShouldReturnUriAdditionalArgsQueryParameter_WhenDataProvided(string input, object args, string expected)
        {
            // Arrange

            // Act
            var result = UriHelper.EnsureUri(input, args);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
