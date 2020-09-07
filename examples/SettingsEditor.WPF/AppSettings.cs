using System.Drawing;
using static System.Environment;

namespace LibSettings.Examples.SettingsEditor.WPF
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public class AppSettings: ISettings
    {
        [Setting("Window Title")]
        [SettingValue("Settings Editor WinForms Example", 1)]

        public string Title { get; set; }

        [Setting(SettingType.Point, "Window Position")]
        [SettingDescription("The position of the window")]
        public Point? Position { get; set; }

        [Setting(SettingType.Point, "Window Size")]
        [SettingDescription("The size of the window")]
        public Point? Size { get; set; }

        [Setting(SettingType.Decimal, "Percent")]
        [SettingValue(typeof(decimal), defaultValue: 40, minValue: 0, maxValue: 100, precision: 2)]
        public decimal? Percent { get; set; }

        [PathSetting("File Path")]
        public string FilePath { get; set; }

        [PathSetting("Directory Path", PathType.Directory)]
        public string DirPath { get; set; }

        [PathSetting("Textfile Path", fileFilter = "Text files (*.txt)|*.txt")]
        public string TextPath { get; set; }

        [Setting(SettingType.Toggle, "Enable the Foo feature")]
        [SettingValue(defaultValue: false)]
        public bool Foo { get; set; }

        [Setting(SettingType.Toggle, "Use the Bar method")]
        [SettingDescription("Everyone loves the bar method")]
        [SettingValue(defaultValue: true)]
        public bool Bar { get; set; }

        [Setting(SettingType.Toggle), SettingValue(typeof(bool))]
        public bool? Baz { get; set; }

        [Setting(SettingType.Option)]
        [SettingValue(HttpMethod.POST)]
        public HttpMethod Method { get; set; }
    }

#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

    public enum HttpMethod
    {
        POST,
        GET,
        PUT,
        HEAD,
    }
}
