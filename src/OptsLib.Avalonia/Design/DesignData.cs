using System;
using JetBrains.Annotations;
using OptsLib.Editor;

namespace OptsLib.Avalonia.Design
{
    public class DesignMetaSetting : MetaSetting
    {
        private readonly Type _valueType;
        public override Type ValueType => _valueType;
        
        public DesignMetaSetting([NotNull] string key, [NotNull] string name, [NotNull] string section, [NotNull] string description, Type valueType) : base(key, name, section, description)
        {
            _valueType = valueType;
        }
    }
    
    public enum DesignEnum { Foo, Bar, Baz }
    
    public static class DesignData
    {
        public static readonly MetaSetting TextMetaSetting = new DesignMetaSetting(
            "textField",
            "Text Option",
            "designSection",
            "The description of the text field",
            typeof(string)
        );
        public static readonly EditorDesignData<string> TextData = new("Text Value", TextMetaSetting);

        public static readonly MetaSetting EnumMetaSetting = new DesignMetaSetting(
            "textField",
            "Text Option",
            "designSection",
            "The description of the enum field",
            typeof(DesignEnum)
        );
        public static readonly EditorDesignData<DesignEnum> EnumData = new(DesignEnum.Baz, EnumMetaSetting);
        
        public static readonly MetaSetting DecimalMetaSetting = new DesignMetaSetting(
            "decimalField",
            "Decimal Option",
            "designSection",
            "The description of the decimal field",
            typeof(decimal)
        );
        public static readonly EditorDesignData<decimal> DecimalData = new(25m, DecimalMetaSetting);
    }

    public struct EditorDesignData<TValue>
    {
        public EditorDesignData(TValue value, MetaSetting meta)
        {
            Value = value;
            Meta = meta;
        }

        public TValue Value { get; }
        public MetaSetting Meta { get; }
    }
}