using System.Drawing;

namespace OptsLib.Examples.SettingsEditor.WinForms
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public class AppSettings: IOptions
    {
        [Option("Window Title")]
        [OptionValue("Options Editor WinForms Example", 1)]

        public string Title { get; set; }

        [Option(OptionValueType.Point, "Window Position")]
        [OptionDescription("The position of the window")]
        public Point? Position { get; set; }

        [Option(OptionValueType.Point, "Window Size")]
        [OptionDescription("The size of the window")]
        public Point? Size { get; set; }

        [Option(OptionValueType.Decimal, "Percent")]
        [OptionValue(typeof(decimal), defaultValue: 40, minValue: 0, maxValue: 100, precision: 2)]
        public decimal? Percent { get; set; }

        [PathOption("File Path")]
        public string FilePath { get; set; }

        [PathOption("Directory Path", PathType.Directory)]
        public string DirPath { get; set; }

        [PathOption("Textfile Path", FileFilter = "Text files (*.txt)|*.txt")]
        public string TextPath { get; set; }

        [Option(OptionValueType.Toggle, "Enable the Foo feature")]
        [OptionValue(defaultValue: false)]
        public bool Foo { get; set; }

        [Option(OptionValueType.Toggle, "Use the Bar method")]
        [OptionDescription("Everyone loves the bar method")]
        [OptionValue(defaultValue: true)]
        public bool Bar { get; set; }

        [Option(OptionValueType.Toggle), OptionValue(typeof(bool))]
        public bool? Baz { get; set; }

        [Option(OptionValueType.Option)]
        [OptionValue(HttpMethod.POST)]
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
