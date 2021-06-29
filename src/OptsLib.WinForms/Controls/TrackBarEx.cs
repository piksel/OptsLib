using System.Windows.Forms;

namespace OptsLib.WinForms.Controls
{
    public class TrackBarEx: TrackBar
    {
        public TrackBarEx(): base()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
    }
}
