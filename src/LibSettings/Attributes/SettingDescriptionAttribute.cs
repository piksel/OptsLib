using System;
using System.Collections.Generic;
using System.Text;

namespace LibSettings
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingDescriptionAttribute: Attribute
    {
        public string Description { get; }
        public SettingDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
