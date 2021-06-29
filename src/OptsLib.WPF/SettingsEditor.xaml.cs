using OptsLib.Editor;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace OptsLib.WPF
{
    /// <summary>
    /// Interaction logic for SettingsEditor.xaml
    /// </summary>
    public partial class SettingsEditor : UserControl
    {
        private IOptionsManager optionsManager;
        private MetaSettings meta = MetaSettings.Empty;

        public event EventHandler? SettingsManagerChanged;
/*
        public event EventHandler<EditorValueChangedEventArgs>? SettingsValueChanged;
*/

        public string? SelectedSection { get; set; } 

        public static readonly DependencyProperty SettingsManagerProperty = DependencyProperty.Register(nameof(OptionsManager), typeof(IOptionsManager), typeof(SettingsEditor));
        public IOptionsManager OptionsManager
        {
            get => (IOptionsManager)GetValue(SettingsManagerProperty);
            set
            {
                SetValue(SettingsManagerProperty, value);
                if(optionsManager != value)
                {
                    optionsManager = value;
                    SettingsManagerOnChanged();
                    //OnPropertyChanged()
                }
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            
            base.OnPropertyChanged(e);
            if(e.Property == SettingsManagerProperty)
            {
                SettingsManagerOnChanged();
            }
        }

        private void SettingsManagerOnChanged()
        {
            meta = new MetaSettings(optionsManager.SettingsType);

            foreach(var section in meta.Sections)
            {
                var showSection = meta.Sections.Count == 1 || SelectedSection == section.Key;
                if (showSection)
                {
                    foreach(var ms in section.Value.Values)
                    {
                        Debug.WriteLine(ms.Key);
                    }
                    Options.ItemsSource = section.Value.Values;
                }
            }

            //UpdateSections();

            //UpdateVisible();
            SettingsManagerChanged?.Invoke(this, EventArgs.Empty);
        }

        public SettingsEditor()
        {
            optionsManager = OptsLib.OptionsManager.Empty;
            InitializeComponent();
        }

        //private void UpdateSections()
        //{
        //    tvSections.Nodes.Clear();
        //    settingEditors.Clear();

        //    foreach (var section in meta.Sections)
        //    {
        //        var showSection = meta.Sections.Count == 1 || SelectedSection == section.Key;

        //        if (!settingEditors.ContainsKey(section.Key))
        //        {
        //            settingEditors.Add(section.Key, new Dictionary<string, SettingEditor>(section.Value.Count));
        //            tvSections.Nodes.Add(section.Key);
        //        }

        //        tableLayoutPanel1.SuspendLayout();
        //        tableLayoutPanel1.Controls.Clear();
        //        tableLayoutPanel1.RowStyles.Clear();

        //        int row = 0;
        //        foreach (var setting in section.Value)
        //        {
        //            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

        //            var editor = GetEditorForSetting(setting.Value);
        //            //editor.Visible = showSection;
        //            //editor.Width = flpSettings.DisplayRectangle.Width - (flpSettings.Padding.Horizontal + flpSettings.AutoScrollMargin.Width + 24);
        //            //editor.Dock = DockStyle.Top;
        //            settingEditors[section.Key].Add(setting.Key, editor);


        //            if (!editor.IncludesLabel)
        //            {
        //                var label = new Label();
        //                label.Dock = DockStyle.Fill;
        //                label.Text = setting.Value.Name;
        //                label.TextAlign = ContentAlignment.MiddleLeft;
        //                label.AutoSize = true;
        //                tableLayoutPanel1.Controls.Add(label, 0, row);
        //                tableLayoutPanel1.Controls.Add(editor, 1, row);
        //            }
        //            else
        //            {
        //                tableLayoutPanel1.Controls.Add(editor, 0, row);
        //                tableLayoutPanel1.SetColumnSpan(editor, 2);

        //            }

        //            editor.Dock = DockStyle.Fill;


        //            var stat = new Label
        //            {
        //                Dock = DockStyle.Fill,
        //                TextAlign = ContentAlignment.MiddleCenter
        //            };
        //            tableLayoutPanel1.Controls.Add(stat, 2, row);

        //            UpdateEditorStatus(editor.EditorStatus, stat);
        //            editorStatuses.Add(editor, stat);

        //            editor.EditorStatusChanged += EditorStatusChanged;
        //            editor.ValueChanged += EditorValueChanged;


        //            var description = setting.Value.Description;

        //            if (!string.IsNullOrEmpty(description))
        //            {
        //                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        //                row++;

        //                var desc = new Label()
        //                {
        //                    Dock = DockStyle.Fill,
        //                    Text = description,
        //                };

        //                tableLayoutPanel1.Controls.Add(desc, editor.IncludesLabel ? 0 : 1, row);
        //                tableLayoutPanel1.SetColumnSpan(desc, editor.IncludesLabel ? 3 : 2);
        //            }

        //            row++;
        //        }

        //        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        //        tableLayoutPanel1.Controls.Add(new Panel()
        //        {
        //            AutoSize = true,
        //        }, 0, row + 1);
        //        tableLayoutPanel1.ResumeLayout(true);
        //    }

        //    scSettings.Panel1Collapsed = showSections.Resolve(() => meta.Sections.Any());
        //    if (meta.Sections.Count == 1)
        //    {
        //        SelectedSection = meta.Sections.Keys.First();
        //    }

        //}
    }
}