using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OptsLib.Avalonia.Editors
{
    public class ToggleOptionEditor : OptionEditor
    {
        public static DirectProperty<ToggleOptionEditor, bool?> ValueProperty = 
            AvaloniaProperty.RegisterDirect<ToggleOptionEditor, bool?>(
                nameof(Value), e => e.Value, (e, v) => e.Value = v);

        bool? _value;
        public bool? Value
        {
            get => _value;
            set => SetAndRaise(ValueProperty, ref _value, value);
        }
        
        public ToggleOptionEditor()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}