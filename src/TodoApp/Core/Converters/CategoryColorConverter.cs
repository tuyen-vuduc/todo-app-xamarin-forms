using System;
using System.Globalization;


namespace TodoApp
{
    public class CategoryColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string category && string.Equals(category, "Business", StringComparison.OrdinalIgnoreCase))
            {
                return Colors.Accent;
            }

            return Colors.Accent2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
