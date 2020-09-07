using LibSettings.StoreResolvers;

namespace LibSettings.Builders
{
    public static class SettingsManagerBuilderExtensions
    {
        public static ISettingsManagerBuilder<TSettings> WithoutPersistance<TSettings>(this SettingsManagerBuilderProto<TSettings> _) 
            where TSettings : class, ISettings, new()
            => new SettingsManagerBuilder<TSettings>(new DummySerializer<TSettings>(), _ => new DummyStore());
    }
}