namespace OptsLib.Builders
{
    public interface ISettingsManagerBuilderProto<TOptions> where TOptions: IOptions, new()
    {
    }

    public class OptionsManagerBuilderProto<TOptions> : ISettingsManagerBuilderProto<TOptions> where TOptions : IOptions, new()
    {
    }
}