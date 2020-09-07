using LibSettings.WinForms.Controls;
using SettingsEditor.Serializers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSettings.WinForms
{
    public class PointSettingEditor: SettingEditor
    {
        protected override string? WriteValue(object? value)
            => PointSerializer.WriteValue(value);

        protected override bool TryParse(string stringValue, out object? value, out string? reason)
        {
            var result = PointSerializer.TryParse(stringValue, out Point? pointValue, out reason);
            value = pointValue;
            return result;
        }

        readonly TextBoxEx textBox;

        public override string ValueText
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public PointSettingEditor(string settingKey): base(settingKey, nameof(PointSettingEditor))
        {
            textBox = new TextBoxEx();
            textBox.Dock = DockStyle.Fill;
            textBox.TextChanged += OnControlValueChanged;
            textBox.AllowText = false;
            textBox.AllowPunctuation = false;
            textBox.AllowSymbol = false;

            Controls.Add(textBox);
        }
    }
}
