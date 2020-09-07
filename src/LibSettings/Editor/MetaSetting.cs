using System;
using System.Linq;
using System.Reflection;

namespace LibSettings.Editor
{
    public class MetaSetting
    {
        public string Key { get; }
        public string Name { get; }
        public string Section { get; }
        public string Description { get; }
        public bool HasDescription => !string.IsNullOrEmpty(Description);

        public SettingType SettingType => settingAttribute.SettingType;

        public ValueRange? ValueRange => valueAttribute.ValueRange;
        public int ValuePrecision => settingAttribute.SettingType == SettingType.Integer ? 0
            : valueAttribute.Precision ?? 2;
        public Type ValueType => valueAttribute.Type;

        private SettingAttribute settingAttribute;
        private SettingValueAttribute valueAttribute;
        

        private PropertyInfo property;

        public MetaSetting(PropertyInfo property)
        {
            this.property = property;
            settingAttribute = property.GetCustomAttribute<SettingAttribute>();
            valueAttribute = property.GetCustomAttribute<SettingValueAttribute>();
            Description = property.GetCustomAttribute<SettingDescriptionAttribute>()?.Description ?? "";
            Section = (property.GetCustomAttribute<SettingSectionAttribute>() ?? SettingSectionAttribute.DefaultSection).Section;
            Name = settingAttribute.Name ?? property.Name;
            Key = settingAttribute.key ?? property.Name;
        }

        internal static MetaSetting? FromProperty(PropertyInfo p)
            //=> p.CustomAttributes.Any(ca => ca.AttributeType.IsAssignableFrom(typeof(SettingAttribute))) ? new MetaSetting(p) : null;
            => p.CustomAttributes.Any(ca => typeof(SettingAttribute).IsAssignableFrom(ca.AttributeType)) ? new MetaSetting(p) : null;

        public object GetValue(ISettings settings)
            => property.GetValue(settings);

        public void SetValue(ISettings settings, object? value)
            => property.SetValue(settings, value);

        public TOptions SettingOptions<TOptions>() where TOptions : new()
            => (TOptions)(settingAttribute?.Options ?? new TOptions());
    }
}
