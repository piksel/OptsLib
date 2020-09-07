using Microsoft.Extensions.Logging;
using LibSettings.WinForms.Controls;
using LibSettings.WinForms.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSettings.WinForms
{
    public class NumberSettingEditor: SettingEditor
    {
        public ValueRange? ValueRange { get; }
        public int Precision { get; }
        public decimal Significand { get; }

        TrackBarEx? trackBar;
        TextBox textBox;

        public NumberSettingEditor(string settingKey, ValueRange? valueRange, int precision): base(settingKey, nameof(NumberSettingEditor))
        {
            ValueRange = valueRange;
            Precision = precision;
            Significand = (decimal)Math.Pow(10, -precision);

            log.LogInformation("Initialized with range {Min}-{Max}, precision {Precision} ({Significand})", valueRange?.Min, valueRange?.Max, precision, Significand);

            textBox = new TextBox();
            textBox.TextChanged += OnControlValueChanged;

            if (valueRange is ValueRange vr)
            {
                

                trackBar = new TrackBarEx();
                trackBar.BackColor = BackColor;
                trackBar.Maximum = ToCoef(vr.Max);
                trackBar.Minimum = ToCoef(vr.Min);

                trackBar.ValueChanged += OnControlValueChanged;

                log.LogInformation("Trackbar range: {Min} - {Max}", trackBar.Minimum, trackBar.Maximum);

                trackBar.Dock = DockStyle.Fill;
                Controls.Add(trackBar);
                var bgc = this.GetActualBackColor();
                
                BackColorChanged += (_, e) =>
                {
                    trackBar.BackColor = BackColor;
                    bgc = this.GetActualBackColor();

                    log.LogInformation("Changed BackColor to #{Color:x8}", BackColor.ToArgb());
                    log.LogInformation("Real BackColor => #{Color:x8}", bgc.ToArgb());
                    log.LogInformation("Real BackColor => #{Color:x8}", trackBar.BackColor.ToArgb());

                    

                };

                textBox.Dock = DockStyle.Right;
            } 
            else
            {
                textBox.Dock = DockStyle.Fill;
            }

            Controls.Add(textBox);

        }

        public override object? Value
        {
            get => base.Value;
            set
            {
                base.Value = value;
                updating = true;
                if (value is decimal d)
                {
                    
                    textBox.Text = WriteValue(d);
                    if (trackBar != null)
                    {
                        trackBar.Value = ToCoef(d);
                    }
                }
                updating = false;
            }
        }

        protected override bool TryParse(string stringValue, out object? value, out string? reason)
        {
            if(decimal.TryParse(stringValue, out decimal result))
            {
                reason = default;
                value = result;
                return true;
            }

            reason = "Invalid number format";
            value = null;
            return false;
        }

        protected override bool ReadValue(out object? newValue)
        {
            if (changeSource == trackBar && trackBar != null)
            {
                newValue = ToDec(trackBar.Value);
            }
            else
            {
                if (!TryParse(textBox.Text, out newValue, out string? reason))
                {
                    OnEditorStatusChanged(EditorStatus.Invalid, reason);
                    log.LogWarning("Parsing value failed: {Reason}", reason);
                    return false;
                }
                else if (!ValidateRange(newValue))
                {
                    OnEditorStatusChanged(EditorStatus.Invalid, reason);
                    log.LogWarning("Parsing value failed: {Reason}", reason);
                    return false;
                }
            }

            return true;
        }

        private bool ValidateRange(object? value)
            => value is decimal d && (ValueRange?.Includes(d) ?? true);
        

        private int ToCoef(decimal val) => (int)(val / Significand);
        private decimal ToDec(int val) => val * Significand;
    }
}
