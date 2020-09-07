using LibSettings.Builders;
using System;
using LibSettings.StoreResolvers;
using LibSettings.Serialization.Json.Core;
using System.Text.Json;

namespace LibSettings
{
    public static class SettingsManagerBuilderJsonCoreExtensions
    {
        public static ISettingsManagerBuilder<TSettings> WithJsonSerializer<TSettings>(this ISettingsManagerBuilderProto<TSettings> _, Func<IStoreResolverBuilder, IStoreResolver> storeResolver, JsonSerializerOptions? options = null)
            where TSettings: class, ISettings, new()
            => new SettingsManagerBuilder<TSettings>(new JsonSettingsSerializer<TSettings>(options), storeResolver);

    }
}
