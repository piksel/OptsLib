using OptsLib.Builders;
using System;
using OptsLib.StoreResolvers;
using OptsLib.Serialization.Json;
using System.Text.Json;

// ReSharper disable once CheckNamespace
namespace OptsLib
{
    public static class OptionsManagerBuilderJsonCoreExtensions
    {
        public static IOptionsManagerBuilder<TOptions> WithJsonSerializer<TOptions>(this ISettingsManagerBuilderProto<TOptions> _, Func<IStoreResolverBuilder, IStoreResolver> storeResolver, JsonSerializerOptions? options = null)
            where TOptions: class, IOptions, new()
            => new OptionsManagerBuilder<TOptions>(new JsonSettingsSerializer<TOptions>(options), storeResolver);

    }
}
