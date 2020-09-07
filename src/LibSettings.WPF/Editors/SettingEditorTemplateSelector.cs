using LibSettings.Editor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace LibSettings.WPF.Editors
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

                var dataTemplate = ms.SettingType switch
                {
                    SettingType.Point => element.FindResource("textSettingTemplate") as DataTemplate,
                    SettingType.Path => element.FindResource("pathSettingTemplate") as DataTemplate,
                    //editor = new PathSettingEditor(ms.Key, ms.SettingOptions<PathSettingOptions>());


                    SettingType.Toggle => element.FindResource("toggleSettingTemplate") as DataTemplate,
                    //editor = new ToggleSettingEditor(ms.Key, ms.Name);


                    SettingType.Option => element.FindResource("textSettingTemplate") as DataTemplate,
                    //editor = new OptionSettingEditor(ms.Key, ms.ValueType);

                    SettingType.Integer => element.FindResource("rangeSettingTemplate") as DataTemplate,
                    SettingType.Decimal => element.FindResource("rangeSettingTemplate") as DataTemplate,
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
