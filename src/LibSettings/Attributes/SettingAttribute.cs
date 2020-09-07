using System;
using System.Collections.Generic;
using System.Text;

namespace LibSettings
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SettingAttribute: Attribute
    {
        public virtual object? Options => null;

        public string? key;
        public SettingType SettingType { get; }
        public string? Name { get; }

        public SettingAttribute(SettingType settingType, string? name)
        {
            SettingType = settingType;
            Name = name;
        }

        public SettingAttribute(SettingType settingType = SettingType.Text) : this(settingType, null) { }
        public SettingAttribute(string? name) : this(SettingType.Text, name) { }
    }
}
