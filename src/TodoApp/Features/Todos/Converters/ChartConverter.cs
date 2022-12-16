using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microcharts;
using SkiaSharp.Views.Maui;

namespace TodoApp
{
    public class ChartConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<int> entries)
            {
                return new LineChart
                {
                    Entries = entries.Select(x => new ChartEntry(x)
                    {
                        Color = Colors.Accent1.ToSKColor()
                    }),
                    BackgroundColor = SkiaSharp.SKColor.Empty,
                    LabelColor = Colors.Accent1.ToSKColor(),
                    LineAreaAlpha = 33,
                    LineMode = LineMode.Spline,
                    LineSize = 6,
                    PointMode = PointMode.None,
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
