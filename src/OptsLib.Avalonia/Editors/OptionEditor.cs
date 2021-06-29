using Avalonia;
using Avalonia.Controls;
using OptsLib.Editor;

namespace OptsLib.Avalonia.Editors
{
    public abstract class OptionEditor: UserControl
    {

        public static DirectProperty<OptionEditor, MetaSetting?> MetaProperty = 
            AvaloniaProperty.RegisterDirect<OptionEditor, MetaSetting?>(
                nameof(Meta), e => e.Meta, (e, v) => e.Meta = v);

        public MetaSetting? Meta
        {
            get => meta;
            set => SetAndRaise(MetaProperty, ref meta, value);
        }
        
        private MetaSetting? meta;
        
        public static DirectProperty<OptionEditor, bool> ValueHasErrorProperty = 
            AvaloniaProperty.RegisterDirect<OptionEditor, bool>(
                nameof(ValueHasError), e => e.ValueHasError, (e, v) => e.ValueHasError = v);
        
        private bool valueHasError;
        public bool ValueHasError
        {
            get => valueHasError;
            set => SetAndRaise(ValueHasErrorProperty, ref valueHasError, value);
        }
        
        public static DirectProperty<OptionEditor, bool> ValueModifiedProperty = 
            AvaloniaProperty.RegisterDirect<OptionEditor, bool>(
                nameof(ValueModified), e => e.ValueModified, (e, v) => e.ValueModified = v);
        
        private bool valueModified;
        public bool ValueModified
        {
            get => valueModified;
            set => SetAndRaise(ValueModifiedProperty, ref valueModified, value);
        }
    }
}