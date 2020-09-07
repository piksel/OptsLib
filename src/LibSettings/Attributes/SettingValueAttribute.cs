using System;
using System.Drawing;

namespace LibSettings
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingValueAttribute: Attribute
    {
        public Type Type { get; }
        public object? DefaultValue { get; }
        private decimal? MinValue { get; }
        private decimal? MaxValue { get; }
        private decimal? MinValueY { get; }
        private decimal? MaxValueY { get; }
        public int? Precision { get; }

        public ValueRange? ValueRange 
            => MinValue == null && MaxValue == null ? (ValueRange?)null 
            : new ValueRange(MinValue ?? decimal.MinValue, MaxValue ?? decimal.MaxValue);


        private SettingValueAttribute(int? precision, dynamic defaultValue, decimal? minValue, decimal? maxValue, Type type)
        {
            DefaultValue = defaultValue;
            MinValue = minValue;
            MaxValue = maxValue;
            Precision = precision;
            Type = type;
        }

        public SettingValueAttribute(int defaultValue, int minValue = int.MinValue, int maxValue = int.MaxValue)
            : this(null, defaultValue, minValue, maxValue, typeof(int)) {}

        public SettingValueAttribute(Type type, int defaultValue, int minValue = int.MinValue, int maxValue = int.MaxValue, int precision = int.MaxValue)
    :       this(precision, defaultValue, minValue, maxValue, type) { }

        public SettingValueAttribute(Point defaultValue, Point? minValues = null, Point? maxValues = null) 
            : this(null, defaultValue, minValues?.X, maxValues?.X, typeof(Point)) 
        {
            MinValueY = minValues?.Y;
            MaxValueY = maxValues?.Y;
        }

        public SettingValueAttribute(PointF defaultValue, PointF? minValues = null, PointF? maxValues = null, int precision = int.MaxValue) 
            : this(precision, defaultValue, (decimal?)minValues?.X, (decimal?)maxValues?.X, typeof(PointF)) 
        {
            MinValueY = (decimal?)minValues?.Y;
            MaxValueY = (decimal?)maxValues?.Y;
        }

        public SettingValueAttribute(Type type, float defaultValue, float minValue = float.MinValue, float maxValue = float.MaxValue, int precision = int.MaxValue) 
            : this(precision, defaultValue, (decimal?)minValue, (decimal?)maxValue, type) {}

        public SettingValueAttribute(string defaultValue, int minLength = 0, int maxLength = int.MaxValue) 
            : this(null, defaultValue, minLength, maxLength, typeof(string)) {}

        public SettingValueAttribute(Color defaultValue)
        {
            Type = typeof(Color);
            DefaultValue = defaultValue;
        }

        public SettingValueAttribute(bool defaultValue)
        {
            Type = typeof(bool);
            DefaultValue = defaultValue;
        }

        public SettingValueAttribute(object defaultValue)
        {
            Type = defaultValue.GetType();
            DefaultValue = defaultValue;
        }

        public SettingValueAttribute(Type type)
        {
            Type = type;
        }

    }

}
