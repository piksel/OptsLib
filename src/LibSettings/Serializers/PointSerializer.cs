using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SettingsEditor.Serializers
{
    public static class PointSerializer
    {
        public static string? WriteValue(object? value)
            => value is Point p ? string.Join(", ", p.X, p.Y) : string.Empty;

        public static bool TryParse(string stringValue, out Point? value, out string? reason)
        {
            var parts = stringValue.Split(',', ';');
            if (parts.Length != 2)
            {
                value = null;
                reason = $"Invalid number count. Expected 2, got {parts.Length}";
                return false;
            }

            if (!int.TryParse(parts[0], out int x))
            {
                value = null;
                reason = $"Invalid number format. Got \"{parts[0]}\"";
                return false;
            }

            if (!int.TryParse(parts[1], out int y))
            {
                value = null;
                reason = $"Invalid number format. Got \"{parts[1]}\"";
                return false;
            }

            reason = null;
            value = new Point(x, y);
            return true;
        }
    }
}
