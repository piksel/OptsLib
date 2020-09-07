using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using LibSettings.Editor;

namespace LibSettings.WinForms
{
    public partial class SettingEditor : UserControl
    {
        protected ILogger log = NullLogger.Instance;

        public virtual bool IncludesLabel => false;
        public virtual bool CanVerify => true;

        public string SettingKey { get; }

        private object? _value;

        protected bool updating;

        protected object? changeSource;

        public virtual object? Value {
            get
            {


                return _value;

            }
            set {
                updating = true;
                _value = Value;
                ValueText = WriteValue(value) ?? string.Empty;
                updating = false;
            }
        }

        public virtual string ValueText { get; set; } = string.Empty;

        public string? ValidationError { get; protected set; }

        public EditorStatus EditorStatus { get; protected set; } = EditorStatus.Unchanged;

        public event EventHandler<EditorStatus>? EditorStatusChanged;

        public event EventHandler<EditorValueChangedEventArgs>? ValueChanged;

        protected void OnEditorStatusChanged(EditorStatus editorStatus, string? validationError)
        {
            ValidationError = validationError;
            EditorStatus = editorStatus;
            EditorStatusChanged?.Invoke(this, editorStatus);
        }

        

        protected SettingEditor(string settingKey, string category)
        {
            Padding = new Padding(1);
            SettingKey = settingKey;
            log = SettingsLogger.GetLogger(category);
        }

        protected void OnValueChanged(object? sender, EventArgs e)
        {
            if (ReadValue(out object? value))
            {
                if (value != _value)
                {
                    Value = value;
                    ValueChanged?.Invoke(this, new EditorValueChangedEventArgs(value, SettingKey));
                }
            }
            updating = false;
            changeSource = null;
        }

        protected void OnControlValueChanged(object? sender, EventArgs e)
        {
            if (updating) return;

            updating = true;
            changeSource = sender;
            OnValueChanged(sender, e);
        }

        protected virtual string? WriteValue(object? value)
        {
            return value?.ToString();
        }

        protected virtual bool ReadValue(out object? newValue)
        {
            if(TryParse(ValueText, out object? value, out string? reason))
            {
                OnEditorStatusChanged(EditorStatus.Valid, null);
                newValue = value;
                return true;
            }
            else
            {
                newValue = default;
                OnEditorStatusChanged(EditorStatus.Invalid, reason);
                log.LogWarning("Parsing value failed: {Reason}", reason);
            }

            return false;
        }

        protected virtual bool TryParse(string stringValue, out object? value, out string? reason)
        {
            value = stringValue;
            reason = null;
            return true;
        }
    }
}
