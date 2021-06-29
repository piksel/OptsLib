using System;

namespace OptsLib
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class OptionDescriptionAttribute: Attribute
    {
        public string Description { get; }
        public OptionDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
