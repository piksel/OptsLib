using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibSettings.Sync
{
    public static class SettingsSerializerSync
    {
        public static TSettings LoadSync<TSettings>(this ISettingsSerializer<TSettings> sm, Stream stream) 
            => sm.Load(stream).Result;

        public static void SaveSync<TSettings>(this ISettingsSerializer<TSettings> sm, Stream stream, TSettings settings)
            => sm.Save(stream, settings).Wait();
    }
}
