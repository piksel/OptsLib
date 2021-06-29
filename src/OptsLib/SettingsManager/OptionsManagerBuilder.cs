using OptsLib.StoreResolvers;
using System;

namespace OptsLib.Builders
{
    public interface IOptionsManagerBuilder<TOptions> where TOptions : class, IOptions, new()
    {
        public OptionsManager<TOptions> Build();
        IOptionsManagerBuilder<TOptions> WithInitial(TOptions initialSettings);
    }

    public class OptionsManagerBuilder<TOptions> : IOptionsManagerBuilder<TOptions> 
        where TOptions : class, IOptions, new()
    {

        public ISettingsSerializer<TOptions> Serializer { get; }
        public IStoreResolver Store { get; }
        public TOptions? InitialSettings { get; private set; }

        public OptionsManagerBuilder(ISettingsSerializer<TOptions> serializer, Func<IStoreResolverBuilder, IStoreResolver> storeResolver)
        {
            Serializer = serializer;
            Store = storeResolver.Invoke(new StoreResolverBuilder(serializer));
        }


        public OptionsManager<TOptions> Build()
        {
            return new OptionsManager<TOptions>(Serializer, Store, InitialSettings);
        }

        public IOptionsManagerBuilder<TOptions> WithInitial(TOptions initialSettings)
        {
            InitialSettings = initialSettings;
            return this;
        }
    }
}
