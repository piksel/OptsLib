using OptsLib.WinForms.Controls;
using System.Windows.Forms;

namespace OptsLib.WinForms
{
    public class TextSettingEditor: SettingEditor
    {
        readonly TextBoxEx textBox;

        public override string ValueText 
        { 
            get => textBox.Text; 
            set => textBox.Text = value; 
        }

        public TextSettingEditor(string settingKey): base(settingKey, nameof(TextSettingEditor))
        {
            textBox = new TextBoxEx {Dock = DockStyle.Fill};
            textBox.TextChanged += OnControlValueChanged;
            Controls.Add(textBox);
        }
    }
}
