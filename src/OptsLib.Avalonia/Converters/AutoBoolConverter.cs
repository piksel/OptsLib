using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;

namespace OptsLib.Avalonia.Converters
{
    public class AutoBoolConverter: MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value switch
            {
                AutoBool.True => true,
                AutoBool.False => false,
                bool b => b,
                _ => null,
            };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            value switch
            {
                bool b => b ? AutoBool.True : AutoBool.False,
                _ => AutoBool.Auto,
            };
    }
}