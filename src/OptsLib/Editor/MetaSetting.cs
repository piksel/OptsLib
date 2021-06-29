using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OptsLib.Editor
{
    public class MetaSetting
    {
        public string Key { get; }
        public string Name { get; }
        public string Section { get; }
        public string Description { get; }
        public bool HasDescription => !string.IsNullOrEmpty(Description);

        public OptionValueType OptionValueType => settingAttributeBase.OptionValueType;

        public ValueRange? ValueRange => valueAttribute.ValueRange;
        public int ValuePrecision => settingAttributeBase.OptionValueType == OptionValueType.Integer ? 0
            : valueAttribute.Precision ?? 2;

        public string ValueStringFormat => $"{{0:f{ValuePrecision}}}";
        
        public virtual Type ValueType => valueAttribute.Type;

        private readonly OptionAttributeBase settingAttributeBase;
        private readonly OptionValueAttribute valueAttribute;
        

        private readonly PropertyInfo property;

        public MetaSetting(PropertyInfo property)
        {
            this.property = property;
            settingAttributeBase = property.GetCustomAttribute<OptionAttributeBase>();
            valueAttribute = property.GetCustomAttribute<OptionValueAttribute>();
            Description = property.GetCustomAttribute<OptionDescriptionAttribute>()?.Description ?? "";
            Section = (property.GetCustomAttribute<OptionSectionAttribute>() ?? OptionSectionAttribute.DefaultSection).Section;
            Name = settingAttributeBase.Name ?? property.Name;
            Key = settingAttributeBase.key ?? property.Name;
        }
        
        public MetaSetting(string key, string name, string section, string description)
        {
            Key = key;
            Name = name;
            Section = section;
            Description = description;
        }

        internal static MetaSetting? FromProperty(PropertyInfo property)
        {
            //=> p.CustomAttributes.Any(ca => ca.AttributeType.IsAssignableFrom(typeof(SettingAttribute))) ? new MetaSetting(p) : null;
            if(!property.CustomAttributes.Any(ca => typeof(OptionAttributeBase).IsAssignableFrom(ca.AttributeType))) return null;
            var oab = property.GetCustomAttribute<OptionAttributeBase>();
            return oab.OptionValueType switch
            {
                OptionValueType.Text => new TextOption(property),
                OptionValueType.Integer => new IntegerOption(property),
                OptionValueType.Decimal => new DecimalOption(property),
                OptionValueType.Point => new PointOption(property),
                OptionValueType.Toggle => new ToggleOption(property),
                OptionValueType.Option => new OptionOption(property),
                OptionValueType.Path => new PathOption(property),
                OptionValueType.Color => new ColorOption(property),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public object GetValue(IOptions settings)
            => property.GetValue(settings);

        public void SetValue(IOptions settings, object? value)
            => property.SetValue(settings, value);

        public TOptions SettingOptions<TOptions>() where TOptions : new()
            => (TOptions)(settingAttributeBase?.Options ?? new TOptions());
    }
    
    public class TextOption: MetaSetting { public TextOption(PropertyInfo pi): base(pi) {} }
    public class IntegerOption: MetaSetting { public IntegerOption(PropertyInfo pi): base(pi) {} }
    public class DecimalOption: MetaSetting { public DecimalOption(PropertyInfo pi): base(pi) {} }
    public class PointOption: MetaSetting { public PointOption(PropertyInfo pi): base(pi) {} }
    public class ToggleOption: MetaSetting { public ToggleOption(PropertyInfo pi): base(pi) {} }

    public class OptionOption : MetaSetting
    {
        public IEnumerable<string> PossibleValues { get; }

        public OptionOption(PropertyInfo pi) : base(pi)
        {
            PossibleValues = Enum.GetNames(ValueType);
        }
    }
    public class PathOption: MetaSetting { public PathOption(PropertyInfo pi): base(pi) {} }
    public class ColorOption: MetaSetting { public ColorOption(PropertyInfo pi): base(pi) {} }
}
