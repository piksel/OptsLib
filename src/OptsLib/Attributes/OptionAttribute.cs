using System;

namespace OptsLib
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class OptionAttributeBase: Attribute
    {
        public virtual object? Options => null;

        public string? key;
        public OptionValueType OptionValueType { get; }
        public string? Name { get; }

        protected OptionAttributeBase(OptionValueType optionValueType, string? name)
        {
            OptionValueType = optionValueType;
            Name = name;
        }

        protected OptionAttributeBase(OptionValueType optionValueType = OptionValueType.Text) : this(optionValueType, null) { }
        protected OptionAttributeBase(string? name) : this(OptionValueType.Text, name) { }
    }

    public sealed class OptionAttribute : OptionAttributeBase
    {
        public OptionAttribute(OptionValueType optionValueType, string? name) : base(optionValueType, name) { }
        public OptionAttribute(OptionValueType optionValueType = OptionValueType.Text) : base(optionValueType) { }
        public OptionAttribute(string? name) : base(name) { }
    }

}
