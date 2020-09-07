using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSettings.WinForms.Extensions
{
    public static class ControlExtensions
    {
        private static ILogger Log => SettingsLogger.GetLogger(nameof(ControlExtensions));

        private static Color getActualBackColor(Control c)
        {
            var bgc = c.BackColor;
            var cc = c;
            var path = "";

            while (bgc == Color.Transparent)
            {
                if (cc.Parent == null)
                {
                    Log.LogError("Real background color not found, end path: {Path}", path);
                    return Color.Magenta;
                }
                
                path += $"<{cc.GetType().Name}>{cc.Name}.";
                cc = cc.Parent;

                if(cc is TabPage pc && pc.UseVisualStyleBackColor)
                {
                    //pc.UseVisualStyleBackColor
                }
                bgc = cc.BackColor;
            }

            Log.LogError("Real background color found: #{Color:x8}, end path: {Path}", bgc.ToArgb(), path);
            return bgc;
        }

        public static Color GetActualBackColor(this Control c)
            => getActualBackColor(c);

    }
}
