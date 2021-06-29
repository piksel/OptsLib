using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;

namespace OptsLib.Avalonia.Converters
{
    public class EnumValuesConverter: MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is Type typeValue ? Enum.GetValues(typeValue) : null;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            BindingNotification.Null;
    }
}