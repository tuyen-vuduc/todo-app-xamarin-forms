using Xunit;

namespace TodoApp.Tests.Core.Converters
{
    public class CategoryColorConverterTests  : BaseUT<CategoryColorConverter>
    {
        [Theory]
        [InlineData("Business")]
        [InlineData("business")]
        public void Convert_ShouldReturnAccentColor_WhenCategoryIsBusiness(string category)
        {
            var actual = Sut.Convert(category, null, null, null);

            Assert.Equal(Colors.Accent, actual);
        }

        [Theory]
        [InlineData("Personal")]
        [InlineData("non-business")]
        public void Convert_ShouldReturnAccent2Color_WhenCategoryIsNotBusiness(string category)
        {
            var actual = Sut.Convert(category, null, null, null);

            Assert.Equal(Colors.Accent2, actual);
        }
    }
}
