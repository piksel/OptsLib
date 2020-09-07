using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibSettings.WinForms
{
    public class ToggleSettingEditor: SettingEditor
    {
        public override bool IncludesLabel => true;
        public override bool CanVerify => false;

        public override object? Value {
            get => base.Value;
            set
            {
                base.Value = value;
                updating = true;
                checkBox.CheckState = value switch
                {
                    true => CheckState.Checked,
                    false => CheckState.Unchecked,
                    _ => CheckState.Indeterminate
                };
                updating = false;
            }
        }

        protected override bool ReadValue(out object? newValue)
        {
            newValue = checkBox.CheckState switch
            {
                CheckState.Checked => true,
                CheckState.Unchecked => false,
                _ => null,
            };
            OnEditorStatusChanged(EditorStatus.Valid, null);
            return true;
        }

        readonly CheckBox checkBox;

        public ToggleSettingEditor(string settingKey, string label): base(settingKey, nameof(ToggleSettingEditor))
        {
            Padding = new Padding(3);
            checkBox = new CheckBox();
            checkBox.Location = new Point(3, 3);
            checkBox.AutoSize = true;
            checkBox.Text = label;
            checkBox.TextAlign = ContentAlignment.MiddleLeft;
            checkBox.CheckedChanged += OnControlValueChanged;
            Controls.Add(checkBox);
        }
    }
}
