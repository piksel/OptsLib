using OptsLib.Builders;
using System;
using OptsLib.StoreResolvers;
using OptsLib.Serialization.Json;

namespace OptsLib
{
    public static class OptionsManagerBuilderJsonJsonNewtonsoftExtensions
    {
        public static IOptionsManagerBuilder<TOptions> WithJsonSerializer<TOptions>(this ISettingsManagerBuilderProto<TOptions> _, Func<IStoreResolverBuilder, IStoreResolver> storeResolver) 
            where TOptions: class, IOptions, new()
            => new OptionsManagerBuilder<TOptions>(new JsonSettingsSerializer<TOptions>(), storeResolver);
    }
}
