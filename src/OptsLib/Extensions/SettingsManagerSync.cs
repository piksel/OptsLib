using System.IO;

namespace OptsLib.Sync
{
    public static class SettingsSerializerSync
    {
        public static TOptions? LoadSync<TOptions>(this ISettingsSerializer<TOptions> sm, Stream stream) where TOptions : class
            => sm.Load(stream).Result;

        public static void SaveSync<TOptions>(this ISettingsSerializer<TOptions> sm, Stream stream, TOptions settings) where TOptions : class
            => sm.Save(stream, settings).Wait();
    }
}
