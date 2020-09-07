using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSettings.WinForms.Controls
{
    public class TextBoxEx: TextBox
    {
        public bool AllowText { get; set; } = true;
        public bool AllowSeparator { get; set; } = true;
        public bool AllowSpace { get; set; } = true;
        public bool AllowNumber { get; set; } = true;
        public bool AllowSymbol { get; set; } = true;
        public bool AllowPunctuation { get; set; } = true;

        

        private bool invalid = false;
        public bool Invalid
        {
            get => invalid;
            set
            {
                invalid = value;
                BorderStyle = invalid ? BorderStyle.FixedSingle : BorderStyle.Fixed3D;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if(AllowNumber && char.IsDigit(e.KeyChar))
            {
                return;
            }
            else if(AllowText && char.IsLetter(e.KeyChar))
            {
                return;
            }
            else if(AllowSymbol && char.IsSymbol(e.KeyChar))
            {
                return;
            }
            else if (AllowPunctuation && char.IsPunctuation(e.KeyChar))
            {
                return;
            }
            else if(AllowSpace && char.IsWhiteSpace(e.KeyChar))
            {
                return;
            }
            else if(AllowSeparator && e.KeyChar == ',')
            {
                return;
            }
            else if (char.IsControl(e.KeyChar))
            {
                return;
            }
            else if(ModifierKeys.HasFlag(Keys.Control) || ModifierKeys.HasFlag(Keys.Alt))
            {
                return;
            }

            e.Handled = true;
            
        }
    }
}
