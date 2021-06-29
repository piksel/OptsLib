using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using OptsLib.Editor;

namespace OptsLib.Avalonia.Editors
{
    public class DecimalOptionEditor : OptionEditor
    {
        public static DirectProperty<DecimalOptionEditor, decimal?> ValueProperty = 
            AvaloniaProperty.RegisterDirect<DecimalOptionEditor, decimal?>(
                nameof(Value), e => e.Value, (e, v) => e.Value = v);

        decimal? _value;
        public decimal? Value
        {
            get => _value;
            set
            {
                var oldStrVal = StringValue;
                SetAndRaise(ValueProperty, ref _value, value);
                var newStrVal = StringValue;
                
                RaisePropertyChanged(StringValueProperty, oldStrVal, newStrVal);
            }
        }

        public static DirectProperty<DecimalOptionEditor, string> StringValueProperty = 
            AvaloniaProperty.RegisterDirect<DecimalOptionEditor, string>(
                nameof(StringValue), e => e.StringValue, (e, v) => e.StringValue = v);
        
        public string StringValue
        {
            get
            {
                if (Meta is null) return "";
                var strVal = string.Format(Meta.ValueStringFormat, _value);
                
                return strVal;
            }
            set
            {
                if (decimal.TryParse(value, out var newValue))
                {
                    ValueHasError = false;
                    Value = newValue;
                }
                else
                {
                    ValueHasError = true;
                }
            }
        }


        public DecimalOptionEditor()
        {
            InitializeComponent();
            
            // PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            // if (e.Property != StringValueProperty) return;
            // Debug.WriteLine($"Decimal StringValue Changed: {e.OldValue} => {e.NewValue}");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}