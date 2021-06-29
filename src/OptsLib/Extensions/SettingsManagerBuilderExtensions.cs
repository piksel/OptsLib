using OptsLib.StoreResolvers;

namespace OptsLib.Builders
{
    public static class SettingsManagerBuilderExtensions
    {
        public static IOptionsManagerBuilder<TOptions> WithoutPersistance<TOptions>(this OptionsManagerBuilderProto<TOptions> _) 
            where TOptions : class, IOptions, new()
            => new OptionsManagerBuilder<TOptions>(new DummySerializer<TOptions>(), _ => new DummyStore());
    }
}