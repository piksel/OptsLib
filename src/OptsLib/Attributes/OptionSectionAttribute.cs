using System;

namespace OptsLib
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class OptionSectionAttribute: Attribute
    {
        public static OptionSectionAttribute DefaultSection = new OptionSectionAttribute("General");

        public string Section { get; }

        public OptionSectionAttribute(string section)
        {
            Section = section;
        }
    }
}
