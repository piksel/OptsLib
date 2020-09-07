namespace LibSettings.Examples.SettingsEditor.WinForms
{
    partial class ExampleMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bSave = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.wbFile = new System.Windows.Forms.WebBrowser();
            this.pFile = new System.Windows.Forms.Panel();
            this.scSettingsLog = new System.Windows.Forms.SplitContainer();
            this.scRoot = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.scSettingsLog)).BeginInit();
            this.scSettingsLog.Panel1.SuspendLayout();
            this.scSettingsLog.Panel2.SuspendLayout();
            this.scSettingsLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scRoot)).BeginInit();
            this.scRoot.Panel1.SuspendLayout();
            this.scRoot.Panel2.SuspendLayout();
            this.scRoot.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.Location = new System.Drawing.Point(330, 22);
            this.bSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(117, 40);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bLoad
            // 
            this.bLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bLoad.Location = new System.Drawing.Point(212, 22);
            this.bLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(117, 40);
            this.bLoad.TabIndex = 3;
            this.bLoad.Text = "Load";
            this.bLoad.UseVisualStyleBackColor = true;
            // 
            // tbConsole
            // 
            this.tbConsole.BackColor = System.Drawing.SystemColors.Window;
            this.tbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConsole.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbConsole.Location = new System.Drawing.Point(0, 0);
            this.tbConsole.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.Size = new System.Drawing.Size(822, 90);
            this.tbConsole.TabIndex = 0;
            this.tbConsole.WordWrap = false;
            // 
            // wbFile
            // 
            this.wbFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbFile.Location = new System.Drawing.Point(0, 0);
            this.wbFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.wbFile.Name = "wbFile";
            this.wbFile.Size = new System.Drawing.Size(347, 500);
            this.wbFile.TabIndex = 0;
            // 
            // pFile
            // 
            this.pFile.BackColor = System.Drawing.SystemColors.Window;
            this.pFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFile.Location = new System.Drawing.Point(0, 0);
            this.pFile.Name = "pFile";
            this.pFile.Size = new System.Drawing.Size(368, 533);
            this.pFile.TabIndex = 0;
            // 
            // scSettingsLog
            // 
            this.scSettingsLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSettingsLog.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scSettingsLog.Location = new System.Drawing.Point(0, 0);
            this.scSettingsLog.Name = "scSettingsLog";
            // 
            // scSettingsLog.Panel1
            // 
            this.scSettingsLog.Panel1.Controls.Add(this.groupBox1);
            // 
            // scSettingsLog.Panel2
            // 
            this.scSettingsLog.Panel2.Controls.Add(this.pFile);
            this.scSettingsLog.Size = new System.Drawing.Size(822, 533);
            this.scSettingsLog.SplitterDistance = 450;
            this.scSettingsLog.TabIndex = 5;
            // 
            // scRoot
            // 
            this.scRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scRoot.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scRoot.Location = new System.Drawing.Point(5, 6);
            this.scRoot.Margin = new System.Windows.Forms.Padding(0);
            this.scRoot.Name = "scRoot";
            this.scRoot.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scRoot.Panel1
            // 
            this.scRoot.Panel1.Controls.Add(this.scSettingsLog);
            // 
            // scRoot.Panel2
            // 
            this.scRoot.Panel2.Controls.Add(this.tbConsole);
            this.scRoot.Size = new System.Drawing.Size(822, 627);
            this.scRoot.SplitterDistance = 533;
            this.scRoot.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.bLoad);
            this.groupBox1.Controls.Add(this.bSave);
            this.groupBox1.Location = new System.Drawing.Point(-2, 467);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 74);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // ExampleMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 638);
            this.Controls.Add(this.scRoot);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ExampleMainForm";
            this.Text = "Settings Editor WinForms Example";
            this.Load += new System.EventHandler(this.ExampleMainForm_Load);
            this.scSettingsLog.Panel1.ResumeLayout(false);
            this.scSettingsLog.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSettingsLog)).EndInit();
            this.scSettingsLog.ResumeLayout(false);
            this.scRoot.Panel1.ResumeLayout(false);
            this.scRoot.Panel2.ResumeLayout(false);
            this.scRoot.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scRoot)).EndInit();
            this.scRoot.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bLoad;
        private LibSettings.WinForms.SettingsEditorControl settingsEditorControl;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.Panel pFile;
        private System.Windows.Forms.WebBrowser wbFile;
        private System.Windows.Forms.SplitContainer scSettingsLog;
        private System.Windows.Forms.SplitContainer scRoot;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

