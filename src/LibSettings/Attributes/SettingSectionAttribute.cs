using System;
using System.Collections.Generic;
using System.Text;

namespace LibSettings
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingSectionAttribute: Attribute
    {
        public static SettingSectionAttribute DefaultSection = new SettingSectionAttribute("General");

        public string Section { get; }

        public SettingSectionAttribute(string section)
        {
            Section = section;
        }
    }
}
