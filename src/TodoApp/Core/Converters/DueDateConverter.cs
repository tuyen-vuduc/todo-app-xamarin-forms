using System;
using System.Globalization;


namespace TodoApp
{
    public class DueDateConverter : IValueConverter
    {
        private readonly Func<DateTime> _todayFunc;
        
        public DueDateConverter() : this(() => DateTime.Today) { }
        
        /// <summary>
        /// For testing only
        /// </summary>
        /// <param name="todayFunc">
        /// A function to return Today date
        /// </param>
        public DueDateConverter(Func<DateTime> todayFunc)
        {
            if (todayFunc == null)
            {
                throw new ArgumentNullException(nameof(todayFunc));
            }
            
            _todayFunc = todayFunc;
        }
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dueDate)
            {
                return FormatDueDate(dueDate);
            }

            return value;
        }

        private string FormatDueDate(DateTime dueDate)
        {
            var today = _todayFunc();
            var diff = dueDate.Date - today;

            switch (diff.Days)
            {
                case 0:
                    return $"Today, {dueDate.Date:MMM dd}";
                case 1:
                    return $"Tomorrow, {dueDate.Date:MMM dd}";
                case -1:
                    return $"Yesterday, {dueDate.Date:MMM dd}";
            }

            if (diff.Days <= 30 && diff.Days >= -30)
            {
                return $"{dueDate.Date:dddd}, {dueDate.Date:MMM dd}";
            }

            return $"{dueDate.Date:MMM dd}, {dueDate.Date:yyyy}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}