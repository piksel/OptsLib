# OptsLib

Simple application configuration and UI library.

[![](https://img.shields.io/nuget/v/OptsLib?label=OptsLib)](https://www.nuget.org/packages/OptsLib/)
[![](https://img.shields.io/nuget/v/OptsLib.Avalonia?label=OptsLib.Avalonia)](https://www.nuget.org/packages/OptsLib.Avalonia/)
[![](https://img.shields.io/nuget/v/OptsLib.WinForms?label=OptsLib.WinForms)](https://www.nuget.org/packages/OptsLib.WinForms/)

## Examples

Application configuration class with OptsLib Attributes:
```cs
public class AppSettings: IOptions
{
    [Option("Window Title")]
    [OptionValue("Options Editor Avalonia Example", 1)]
    public string Title { get; set; }

    [Option(OptionValueType.Point, "Window Position")]
    [OptionDescription("The position of the window")]
    [OptionValue(defaultValueX: 10, defaultValueY: 40)]
    public Point? Position { get; set; }
    
    [Option(OptionValueType.Option)]
    [OptionValue(HttpMethod.POST)]
    public HttpMethod Method { get; set; }
}
    
public enum HttpMethod
{
    POST,
    GET,
    PUT,
    HEAD,
}
```

### Avalonia
Source: [examples/AvaloniaOptsEditor](https://github.com/piksel/OptsLib/tree/main/examples/AvaloniaOptsEditor)

![Avalonia Example](https://github.com/piksel/OptsLib/raw/main/docs/avalonia-screenshot1.png)

### WinForms
![WinForms Example](https://github.com/piksel/OptsLib/raw/main/docs/winforms-screenshot1.png)
