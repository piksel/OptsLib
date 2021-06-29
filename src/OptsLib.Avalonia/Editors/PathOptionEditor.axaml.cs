using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OptsLib.Avalonia.Editors
{
    public class PathOptionEditor : OptionEditor
    {
        public static DirectProperty<PathOptionEditor, string> ValueProperty = 
            AvaloniaProperty.RegisterDirect<PathOptionEditor, string>(
                nameof(Value), e => e.Value, (e, v) => e.Value = v);

        string _value;
        public string Value
        {
            get => _value;
            set
            {
                SetAndRaise(ValueProperty, ref _value, value);
            }
        }
        
        public PathOptionEditor()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}