using OptsLib.Builders;
using OptsLib.StoreResolvers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace OptsLib
{
    public class OptionsManager<TOptions> : IOptionsManager where TOptions: class, IOptions, new()
    {
        private ISettingsSerializer<TOptions> Serializer { get; }
        public IStoreResolver Store { get; }

        public Task<TOptions> Options { get; }
        public async Task<IOptions> GetOptions() => await Options as IOptions;

        public Type SettingsType => typeof(TOptions);

        internal OptionsManager(ISettingsSerializer<TOptions> serializer, IStoreResolver store, TOptions? initialSettings = null)
        {
            Serializer = serializer;
            Store = store;
            Options = initialSettings == null ? LoadSettingsOrDefault() : Task.FromResult(initialSettings);
        }

        private async Task<TOptions> LoadSettingsOrDefault() 
            => (await Store.ItemExists() ? await LoadOrNull() : null) ?? GetDefaulTOptions();

        private TOptions GetDefaulTOptions()
        {
            var settings = new TOptions();

            foreach (var prop in typeof(TOptions).GetProperties())
            {
                if (prop.GetCustomAttribute<OptionValueAttribute>() is { } sva)
                {
                    var dv = sva.DefaultValue;
                    var assignable = prop.PropertyType.IsAssignableFrom(dv?.GetType());
                    if (!assignable)
                    {
                        Debug.WriteLine("{0}: Cannot assign {1} to target {2}", prop.Name, dv?.GetType().FullName, prop.PropertyType.FullName);
                        if (prop.PropertyType.IsGenericType)
                        {
                            var genType = prop.PropertyType.GenericTypeArguments.FirstOrDefault();
                            Debug.WriteLine("Generic type {0}, Assignable? {1}", genType?.FullName, genType?.IsAssignableFrom(dv?.GetType()));
                        }
                    }
                    if (assignable)
                    {
                        prop.SetValue(settings, dv);
                    }
                    Debug.WriteLine("Key: {0} => {1} (Assignable? {2})", prop.Name, dv, assignable);
                }
            }

            return settings;
        }

        public async Task Save(CancellationToken cancellationToken = default)
        {
            using var stream = await Store.OpenWriteStream();
            await Serializer.Save(stream, await Options, cancellationToken);
            //stream.Flush();
        }

        public async Task<TOptions> Load(CancellationToken cancellationToken = default)
            => await LoadOrNull(cancellationToken) ?? GetDefaulTOptions();

        private async Task<TOptions?> LoadOrNull(CancellationToken cancellationToken = default)
        {
            using var stream = await Store.OpenReadStream();
            return await Serializer.Load(stream, cancellationToken);
        }
    }

    public class OptionsManager: IOptionsManager
    {
        internal class EmptyOptions : IOptions { }

        public static ISettingsManagerBuilderProto<TOptions> From<TOptions>() where TOptions: IOptions, new()
            => new OptionsManagerBuilderProto<TOptions>();

        public static IOptionsManager Empty => new OptionsManager();

        private OptionsManager() { }

        public Task<IOptions> GetOptions() => Task.FromResult<IOptions>(new EmptyOptions());

        public Type SettingsType => typeof(IOptions);
    }
}
