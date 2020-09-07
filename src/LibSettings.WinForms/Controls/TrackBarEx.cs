using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSettings.WinForms.Controls
{
    public class TrackBarEx: TrackBar
    {
        public TrackBarEx(): base()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
    }
}
