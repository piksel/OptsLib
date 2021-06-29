using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OptsLib.Editor;

namespace OptsLib.Avalonia.Editors
{
    public class TextOptionEditor : OptionEditor
    {

        public static DirectProperty<TextOptionEditor, string> ValueProperty = 
            AvaloniaProperty.RegisterDirect<TextOptionEditor, string>(
                nameof(Value), e => e.Value, (e, v) => e.Value = v);

        string _value;
        public string Value
        {
            get => _value;
            set
            {
                Debug.WriteLine($"Value => {value}");
                SetAndRaise(ValueProperty, ref _value, value);
            }
        }

        public TextOptionEditor()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}