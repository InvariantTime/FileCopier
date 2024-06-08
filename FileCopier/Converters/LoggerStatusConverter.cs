using FileCopier.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace FileCopier.Converters
{
    public class LoggerStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not StatusCodes code)
                throw new Exception("Unable to convert value to code");

            return code switch
            {
                StatusCodes.Success => new SolidColorBrush(Colors.LightGreen),
                StatusCodes.Info => new SolidColorBrush(Colors.White),
                StatusCodes.Error => new SolidColorBrush(Colors.Red),
                _ => throw new NotSupportedException()
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
