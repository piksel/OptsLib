using LibSettings.Builders;
using LibSettings.StoreResolvers;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace LibSettings
{
    public class SettingsManager<TSettings> : ISettingsManager where TSettings: class, ISettings, new()
    {
        private ISettingsSerializer<TSettings> Serializer { get; }
        public IStoreResolver Store { get; }

        // private ISettings settings;

        public Task<TSettings> Settings { get; private set; }
        public async Task<ISettings> GetSettings() => await Settings as ISettings;

        public Type SettingsType => typeof(TSettings);

        internal SettingsManager(ISettingsSerializer<TSettings> serializer, IStoreResolver store, TSettings? initialSettings = null)
        {
            Serializer = serializer;
            Store = store;
            Settings = initialSettings == null ? LoadSettingsOrDefault() : Task.FromResult(initialSettings);
        }

        private async Task<TSettings> LoadSettingsOrDefault()
        {
            if (await Store.ItemExists())
            {
                return await Load();
            }
            else
            {
                var settings = new TSettings();

                foreach(var prop in typeof(TSettings).GetProperties())
                {
                    if(prop.GetCustomAttribute<SettingValueAttribute>() is SettingValueAttribute sva)
                    {
                        var dv = sva.DefaultValue;
                        if(prop.PropertyType.IsAssignableFrom(dv?.GetType()))
                        {
                            prop.SetValue(settings, dv);
                        }
                    }
                }

                return settings;
            }
        }

        public async Task Save(CancellationToken cancellationToken = default)
        {
            using var stream = await Store.OpenWriteStream();
            await Serializer.Save(stream, await Settings, cancellationToken);
            //stream.Flush();
        }

        public async Task<TSettings> Load(CancellationToken cancellationToken = default)
            => await (Settings = load(cancellationToken));

        private async Task<TSettings> load(CancellationToken cancellationToken = default)
        {
            using var stream = await Store.OpenReadStream();
            return await Serializer.Load(stream, cancellationToken);
        }
    }

    public class SettingsManager: ISettingsManager
    {
        internal class EmptySettings : ISettings { }

        public static ISettingsManagerBuilderProto<TSettings> From<TSettings>() where TSettings: ISettings, new()
            => new SettingsManagerBuilderProto<TSettings>();

        public static ISettingsManager Empty => new SettingsManager();

        private SettingsManager() { }

        public Task<ISettings> GetSettings() => Task.FromResult<ISettings>(new EmptySettings());

        public Type SettingsType => typeof(ISettings);
    }
}
