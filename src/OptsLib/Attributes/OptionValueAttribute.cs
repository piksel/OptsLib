using System;
using System.Drawing;

namespace OptsLib
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class OptionValueAttribute: Attribute
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


        private OptionValueAttribute(int? precision, dynamic defaultValue, decimal? minValue, decimal? maxValue, Type type)
        {
            DefaultValue = defaultValue;
            MinValue = minValue;
            MaxValue = maxValue;
            Precision = precision;
            Type = type;
        }

        public OptionValueAttribute(int defaultValue, int minValue = int.MinValue, int maxValue = int.MaxValue)
            : this(null, defaultValue, minValue, maxValue, typeof(int)) {}

        public OptionValueAttribute(Type type, int defaultValue, int minValue = int.MinValue, int maxValue = int.MaxValue, int precision = int.MaxValue)
    :       this(precision, defaultValue, minValue, maxValue, type) { }

        public OptionValueAttribute(int defaultValueX, int defaultValueY, 
            int minValueX = 0, int minValueY = int.MaxValue,
            int maxValueX = 0, int maxValueY= int.MaxValue
        ) 
            : this(null, new Point(defaultValueX, defaultValueY), minValueX, minValueY, typeof(Point))
        {
            MinValueY = minValueY;
            MaxValueY = maxValueY;
        }

        public OptionValueAttribute(PointF defaultValue, PointF? minValues = null, PointF? maxValues = null, int precision = int.MaxValue) 
            : this(precision, defaultValue, (decimal?)minValues?.X, (decimal?)maxValues?.X, typeof(PointF)) 
        {
            MinValueY = (decimal?)minValues?.Y;
            MaxValueY = (decimal?)maxValues?.Y;
        }

        public OptionValueAttribute(Type type, float defaultValue, float minValue = float.MinValue, float maxValue = float.MaxValue, int precision = int.MaxValue) 
            : this(precision, (decimal)defaultValue, (decimal?)minValue, (decimal?)maxValue, type) {}

        public OptionValueAttribute(string defaultValue, int minLength = 0, int maxLength = int.MaxValue) 
            : this(null, defaultValue, minLength, maxLength, typeof(string)) {}

        public OptionValueAttribute(Color defaultValue)
        {
            Type = typeof(Color);
            DefaultValue = defaultValue;
        }

        public OptionValueAttribute(bool defaultValue)
        {
            Type = typeof(bool);
            DefaultValue = defaultValue;
        }

        public OptionValueAttribute(object defaultValue)
        {
            Type = defaultValue.GetType();
            DefaultValue = defaultValue;
        }

        public OptionValueAttribute(Type type)
        {
            Type = type;
        }

    }

}
