using OptsLib.Editor;
using System.Windows;
using System.Windows.Controls;

namespace OptsLib.WPF.Editors
{
    public class SettingEditorTemplateSelector: DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            /*
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is Task)
            {
                Task taskitem = item as Task;

                if (taskitem.Priority == 1)
                    return
                        element.FindResource("importantTaskTemplate") as DataTemplate;
                else
                    return
                        element.FindResource("myTaskTemplate") as DataTemplate;
            }
             */
            if (container is FrameworkElement element && item is MetaSetting ms)
            {

                var dataTemplate = ms.OptionValueType switch
                {
                    OptionValueType.Point => element.FindResource("textSettingTemplate") as DataTemplate,
                    OptionValueType.Path => element.FindResource("pathSettingTemplate") as DataTemplate,
                    //editor = new PathSettingEditor(ms.Key, ms.SettingOptions<PathSettingOptions>());


                    OptionValueType.Toggle => element.FindResource("toggleSettingTemplate") as DataTemplate,
                    //editor = new ToggleSettingEditor(ms.Key, ms.Name);


                    OptionValueType.Option => element.FindResource("textSettingTemplate") as DataTemplate,
                    //editor = new OptionSettingEditor(ms.Key, ms.ValueType);

                    OptionValueType.Integer => element.FindResource("rangeSettingTemplate") as DataTemplate,
                    OptionValueType.Decimal => element.FindResource("rangeSettingTemplate") as DataTemplate,
                    //editor = new NumberSettingEditor(ms.Key, ms.ValueRange, ms.ValuePrecision);

                    _ => element.FindResource("textSettingTemplate") as DataTemplate,
                };

                if (dataTemplate != null)
                    return dataTemplate;

            }

            return base.SelectTemplate(item, container);
        }
    }
}
