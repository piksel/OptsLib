using LibSettings.StoreResolvers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibSettings.Builders
{
    public interface ISettingsManagerBuilder<TSettings> where TSettings : class, ISettings, new()
    {
        public SettingsManager<TSettings> Build();
        ISettingsManagerBuilder<TSettings> WithInitial(TSettings initialSettings);
    }

    public class SettingsManagerBuilder<TSettings> : ISettingsManagerBuilder<TSettings> 
        where TSettings : class, ISettings, new()
    {

        public ISettingsSerializer<TSettings> Serializer { get; }
        public IStoreResolver Store { get; }
        public TSettings? InitialSettings { get; private set; }

        public SettingsManagerBuilder(ISettingsSerializer<TSettings> serializer, Func<IStoreResolverBuilder, IStoreResolver> storeResolver)
        {
            Serializer = serializer;
            Store = storeResolver.Invoke(new StoreResolverBuilder(serializer));
        }


        public SettingsManager<TSettings> Build()
        {
            return new SettingsManager<TSettings>(Serializer, Store, InitialSettings);
        }

        public ISettingsManagerBuilder<TSettings> WithInitial(TSettings initialSettings)
        {
            InitialSettings = initialSettings;
            return this;
        }
    }
}
