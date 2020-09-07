using System;

namespace LibSettings.Editor
{
    public class EditorValueChangedEventArgs: EventArgs
    {
        public EditorValueChangedEventArgs(object? value, string key)
        {
            Value = value;
            SettingKey = key;
        }

        public object? Value { get; }
        public string SettingKey { get; }
    }
}