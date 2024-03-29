﻿namespace OptsLib.Builders
{
    public interface IStoreResolverBuilder
    {
        ISettingsSerializer Serializer { get; }
    }

    public class StoreResolverBuilder: IStoreResolverBuilder
    {
        public ISettingsSerializer Serializer { get; }

        public StoreResolverBuilder(ISettingsSerializer serializer)
        {
            Serializer = serializer;
        }
    }
}
