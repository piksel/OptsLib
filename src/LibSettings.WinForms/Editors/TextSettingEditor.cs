using LibSettings.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSettings.WinForms
{
    public class TextSettingEditor: SettingEditor
    {
        TextBoxEx textBox;

        public override string ValueText 
        { 
            get => textBox.Text; 
            set => textBox.Text = value; 
        }

        public TextSettingEditor(string settingKey): base(settingKey, nameof(TextSettingEditor))
        {
            textBox = new TextBoxEx();
            textBox.Dock = DockStyle.Fill;
            textBox.TextChanged += OnControlValueChanged;
            Controls.Add(textBox);
        }
    }
}
