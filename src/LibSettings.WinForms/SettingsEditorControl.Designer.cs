namespace LibSettings.WinForms
{
    partial class SettingsEditorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.tvSections = new System.Windows.Forms.TreeView();
            this.scSettings = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scSettings)).BeginInit();
            this.scSettings.Panel1.SuspendLayout();
            this.scSettings.Panel2.SuspendLayout();
            this.scSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(4, 5);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(190, 20);
            this.tbSearch.TabIndex = 1;
            // 
            // bSearch
            // 
            this.bSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSearch.Location = new System.Drawing.Point(200, 3);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(29, 23);
            this.bSearch.TabIndex = 2;
            this.bSearch.Text = "Search";
            this.bSearch.UseVisualStyleBackColor = true;
            // 
            // tvSections
            // 
            this.tvSections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvSections.Location = new System.Drawing.Point(0, 31);
            this.tvSections.Name = "tvSections";
            this.tvSections.Size = new System.Drawing.Size(232, 365);
            this.tvSections.TabIndex = 0;
            this.tvSections.Visible = false;
            // 
            // scSettings
            // 
            this.scSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scSettings.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scSettings.Location = new System.Drawing.Point(3, 3);
            this.scSettings.Name = "scSettings";
            // 
            // scSettings.Panel1
            // 
            this.scSettings.Panel1.Controls.Add(this.tvSections);
            this.scSettings.Panel1.Controls.Add(this.tbSearch);
            this.scSettings.Panel1.Controls.Add(this.bSearch);
            // 
            // scSettings.Panel2
            // 
            this.scSettings.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.scSettings.Size = new System.Drawing.Size(698, 396);
            this.scSettings.SplitterDistance = 232;
            this.scSettings.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lDescription, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 396);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lName.Location = new System.Drawing.Point(3, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(38, 28);
            this.lName.TabIndex = 0;
            this.lName.Text = "Name:";
            this.lName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(47, 3);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(386, 20);
            this.textBox1.TabIndex = 1;
            // 
            // lDescription
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lDescription, 2);
            this.lDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lDescription.Location = new System.Drawing.Point(47, 28);
            this.lDescription.Name = "lDescription";
            this.lDescription.Size = new System.Drawing.Size(412, 340);
            this.lDescription.TabIndex = 3;
            this.lDescription.Text = "Description";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(439, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "✔";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scSettings);
            this.Name = "SettingsEditorControl";
            this.Size = new System.Drawing.Size(704, 402);
            this.scSettings.Panel1.ResumeLayout(false);
            this.scSettings.Panel1.PerformLayout();
            this.scSettings.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSettings)).EndInit();
            this.scSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.TreeView tvSections;
        private System.Windows.Forms.SplitContainer scSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lDescription;
        private System.Windows.Forms.Label label1;
    }
}
