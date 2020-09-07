namespace LibSettings.Builders
{
    public interface ISettingsManagerBuilderProto<TSettings> where TSettings: ISettings, new()
    {
    }

    public class SettingsManagerBuilderProto<TSettings> : ISettingsManagerBuilderProto<TSettings> where TSettings : ISettings, new()
    {
    }
}