using System;
using System.Drawing;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using SettingsEditor.Serializers;

namespace OptsLib.Avalonia.Converters
{
    public class PointFormatException : Exception
    {
        public PointFormatException(string message): base(message){}

        public override string ToString() => Message;
    }
    
    public class PointConverter: MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
        
        public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return string.Empty;
            if (targetType != typeof(string))
                return new BindingNotification(new PointFormatException($"Convert: Invalid target type {targetType}"), BindingErrorType.Error);

            return PointSerializer.WriteValue(value);
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (typeof(Point).IsAssignableFrom(targetType))
                return new BindingNotification(new PointFormatException($"Invalid target type {targetType}"),
                    BindingErrorType.Error);

            if (value is not string stringValue) stringValue = string.Empty;
            
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return null;
            }

            if (PointSerializer.TryParse(value.ToString(), out var point, out var reason) && point is {})
                return point.Value;

            return new BindingNotification(new PointFormatException(reason ?? "Invalid format"),
                BindingErrorType.DataValidationError);
        }
    }
}