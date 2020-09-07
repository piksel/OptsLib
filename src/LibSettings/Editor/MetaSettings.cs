using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LibSettings.Editor
{
    public class MetaSettings
    {
        public static MetaSettings Empty => new MetaSettings();

        public Dictionary<string, Dictionary<string, MetaSetting>> Sections { get; }

        private MetaSettings()
        {
            Sections = new Dictionary<string, Dictionary<string, MetaSetting>>();
        }

        public MetaSettings(Type settingsType)
        {

            var settings = settingsType.GetProperties()
                .Select(p => MetaSetting.FromProperty(p));
                //.Select(p => (Property: p, Attribute: p.CustomAttributes.OfType<SettingAttribute>().FirstOrDefault()))
                //.OfType<MetaSetting>();

            Debug.WriteLine("Settings: {0}", settingsType);

            foreach (var s in settings)
            {
                if (s == null)
                {
                    Debug.WriteLine("- NULL");
                }
                else
                {
                    Debug.WriteLine("- {0}: {1}", s.Key, s.SettingType);

                }
            }

            Sections = settings
                .OfType<MetaSetting>()
                .GroupBy(ms => ms.Section)
                .ToDictionary(gms => gms.Key, gms => gms.ToDictionary(ms => ms.Key));

                //.ToDictionary(pa => pa.Attribute.key ?? pa.Property.Name, pa => MetaSetting.FromProperty(pa.Property));
        }

        public static MetaSettings FromSettings(ISettings settings)
        {
            return new MetaSettings(settings.GetType());
        }
    }
}
