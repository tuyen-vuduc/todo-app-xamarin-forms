using System;
using System.Globalization;


namespace TodoApp
{
    public class TaskCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int count)
            {
                switch (count)
                {
                    case 1:
                        return "1 task";
                    default:
                        return $"{count} tasks";
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
