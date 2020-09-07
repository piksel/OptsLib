using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSettings.WinForms
{
    public class OptionSettingEditor: SettingEditor
    {
        ComboBox comboBox;

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
