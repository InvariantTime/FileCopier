using FileCopier.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace FileCopier.Converters
{
    public class CopyInfoConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is not string source)
                throw new ArgumentException("Unable to convert to string");

            if (values[1] is not string output)
                throw new ArgumentException("Unable to convert to string");

            return new FileCopyInfo()
            {
                Source = source,
                Path = output
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return Array.Empty<object>();
        }
    }
}
