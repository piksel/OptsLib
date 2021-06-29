using System;
using System.Linq;
using System.Windows.Forms;

namespace OptsLib.WinForms
{
    public class OptionSettingEditor: SettingEditor
    {
        readonly ComboBox comboBox;

        Type EnumType { get; }

        public override object? Value { 
            get => base.Value; 
            set {
                base.Value = Value;
                updating = true;
                comboBox.SelectedItem = value;
                updating = false;
            }
        }

        protected override bool ReadValue(out object newValue)
        {
            newValue = comboBox.SelectedItem;
            OnEditorStatusChanged(EditorStatus.Valid, null);            
            return true;
        }

        public OptionSettingEditor(string settingKey, Type enumType): base(settingKey, nameof(OptionSettingEditor))
        {
            comboBox = new ComboBox();
            EnumType = enumType;

            comboBox.Items.AddRange(enumType.GetEnumValues().Cast<Enum>().ToArray());
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Dock = DockStyle.Fill;
            comboBox.SelectedIndexChanged += OnControlValueChanged;
            Controls.Add(comboBox);
        }
    }
}
