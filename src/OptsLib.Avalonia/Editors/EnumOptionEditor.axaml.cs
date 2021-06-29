using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using static Avalonia.Controls.Design;

namespace OptsLib.Avalonia.Editors
{
    public class EnumOptionEditor : OptionEditor
    {
        public static DirectProperty<EnumOptionEditor, Enum?> ValueProperty = 
            AvaloniaProperty.RegisterDirect<EnumOptionEditor, Enum?>(
                nameof(Value), e => e.Value, (e, v) => e.Value = v);

        Enum? _value;
        public Enum? Value
        {
            get => _value;
            set
            {
                Debug.WriteLine($"EnumValue => {value}");
                SetAndRaise(ValueProperty, ref _value, value);
            }
        }
        
        public EnumOptionEditor()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            // if (!IsDesignMode)
            // {
            //     DataContext = this;
            // }
        }
    }
}