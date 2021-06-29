using Microsoft.Extensions.Logging;
using System.Drawing;
using System.Windows.Forms;

namespace OptsLib.WinForms.Extensions
{
    public static class ControlExtensions
    {
        private static ILogger Log => OptionsLogger.GetLogger(nameof(ControlExtensions));

        public static Color GetActualBackColor(this Control c)
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

            return bgc;
        }

    }
}
