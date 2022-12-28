using System;
using System.Globalization;


namespace TodoApp
{
    public class MenuIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string iconName)
            {
                return new FontImageSource
                {
                    Color = Colors.TextSecondary,
                    Size = 24,
                    FontFamily = Fonts.Mdi,
                    Glyph = iconName,
                };
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
