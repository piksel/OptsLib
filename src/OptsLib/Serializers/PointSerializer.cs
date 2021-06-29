using System.Drawing;

namespace SettingsEditor.Serializers
{
    public static class PointSerializer
    {
        public static string? WriteValue(object? value)
            => value is Point p ? string.Join(", ", p.X, p.Y) : string.Empty;

        public static bool TryParse(string stringValue, out Point? value, out string? reason)
        {
            var parts = stringValue.Split(',', ';');

            if (parts.Length < 1)
            {
                value = null;
                reason = $"Input is empty";
                return false;
            }

            var firstNum = parts[0].Trim();

            if (!int.TryParse(firstNum, out int x))
            {
                value = null;
                reason = $"Invalid number format \"{firstNum}\"";
                return false;
            }
            
            if (parts.Length != 2)
            {
                value = null;
                reason = $"Invalid number count. Expected 2, got {parts.Length}";
                return false;
            }

            var secondNum = parts[1].Trim();
            
            if (!int.TryParse(secondNum, out int y))
            {
                value = null;
                reason = $"Invalid number format \"{secondNum}\"";
                return false;
            }

            reason = null;
            value = new Point(x, y);
            return true;
        }
    }
}
