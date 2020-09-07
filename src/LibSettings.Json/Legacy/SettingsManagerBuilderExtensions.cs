using LibSettings.Builders;
using System;
using LibSettings.StoreResolvers;
using LibSettings.Serialization.Json.Legacy;

namespace LibSettings
{
    public static class SettingsManagerBuilderJsonLegacyExtensions
    {
        public static ISettingsManagerBuilder<TSettings> WithJsonSerializer<TSettings>(this ISettingsManagerBuilderProto<TSettings> _, Func<IStoreResolverBuilder, IStoreResolver> storeResolver) 
            where TSettings: class, ISettings, new()
            => new SettingsManagerBuilder<TSettings>(new JsonSettingsSerializer<TSettings>(), storeResolver);
    }
}
