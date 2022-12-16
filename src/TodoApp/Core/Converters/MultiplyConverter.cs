using System;
using System.Globalization;


namespace TodoApp
{
    public class MultiplyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var result = 1.0;

            for (int i = 0; i < values.Length; i++)
            {
                if (double.TryParse(values[i  ]?.ToString(), out var value))
                {
                    result *= Math.Max(0, value);
                }
            }

            if (double.TryParse(parameter?.ToString(), out var max))
            {
                return Math.Min(result, max);
            }
            
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}