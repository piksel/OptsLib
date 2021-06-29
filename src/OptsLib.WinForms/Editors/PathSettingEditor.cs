using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace OptsLib.WinForms
{
    public partial class PathSettingEditor : SettingEditor
    {


        private readonly TextBox textBox;
        private readonly Button btn;
        private FileDialog FileDialog => (FileDialog)dialog;
        private FolderBrowserDialog FolderDialog => (FolderBrowserDialog)dialog;
        private readonly CommonDialog dialog;

        public override string ValueText
        {
            get => textBox.Text;
            set {
                textBox.Text = value;
                if(dialog is FileDialog fd)
                {
                    fd.FileName = textBox.Text;
                    fd.InitialDirectory = Path.GetDirectoryName(value);
                }
            }
        }

        public PathSettingEditor(string settingKey, PathSettingOptions options): base(settingKey, nameof(PathSettingEditor))
        {
            Padding = Padding.Empty;

            textBox = new TextBox();

            btn = new Button {Text = "Browse...", Margin = new Padding(10, 0, 0, 0), Height = 25, Width = 100};
            //btn.Dock = DockStyle.Right;

            btn.Location = new Point(Width - btn.Width, 0);
            btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn.Click += ButtonClicked;

            Controls.Add(btn);

            textBox.Location = new Point(1, 1);
            textBox.Width = Width - btn.Width - 4;
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox.TextChanged += OnControlValueChanged;

            Controls.Add(textBox);

            if(options.PathType == PathType.Directory)
            {
                var fbd = new FolderBrowserDialog {ShowNewFolderButton = true, RootFolder = options.RootFolder};
                dialog = fbd;
            }
            else
            {
                var fd = new OpenFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(options.RootFolder), Multiselect = false
                };
                if (!string.IsNullOrEmpty(options.FileFilter)) {
                    fd.Filter = options.FileFilter;
                }
                dialog = fd;
            }
        }

        private void ButtonClicked(object? sender, EventArgs e)
        {
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = dialog switch
                {
                    FileDialog fd => fd.FileName,
                    FolderBrowserDialog fdd => fdd.SelectedPath,
                    _ => textBox.Text
                };
            }
        }
    }
}
