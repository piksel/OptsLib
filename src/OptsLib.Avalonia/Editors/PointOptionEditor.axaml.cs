using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using OptsLib.Editor;
using Point = System.Drawing.Point;

namespace OptsLib.Avalonia.Editors
{
    public class PointOptionEditor : OptionEditor
    {
        public static DirectProperty<PointOptionEditor, Point?> ValueProperty = 
            AvaloniaProperty.RegisterDirect<PointOptionEditor, Point?>(
                nameof(Value), e => e.Value, (e, v) => e.Value = v);

        Point? _value;
        public Point? Value
        {
            get => _value;
            set
            {
                Debug.WriteLine($"PointValue => {value}");
                SetAndRaise(ValueProperty, ref _value, value);
            }
        }

        string lastInvalid = "";
        private readonly TextBlock descriptionText;

        public PointOptionEditor()
        {
            InitializeComponent();

            descriptionText = this.FindControl<TextBlock>("DescriptionText");

            if (this.FindControl<TextBox>("TextBox") is { } textBox)
            {
                textBox.PropertyChanged += (_, ea)
                    =>
                {
                    if (ea.Property == DataValidationErrors.ErrorsProperty)
                    {
                        lastInvalid = textBox.Text;
                        descriptionText.IsVisible = !DataValidationErrors.GetHasErrors(textBox);
                    }

                    if (ea.Property == TextBox.TextProperty)
                    {
                        if (ea.NewValue is string newVal && lastInvalid != newVal)
                        {
                            DataValidationErrors.ClearErrors(textBox);
                        }
                    }
                };
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}