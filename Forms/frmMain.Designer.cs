namespace DayZVersionToggle
{
    partial class frmMain
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
            this.btnExperimental = new System.Windows.Forms.Button();
            this.btnStable = new System.Windows.Forms.Button();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.gbActive = new System.Windows.Forms.GroupBox();
            this.cbActive = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.gbActive.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExperimental
            // 
            this.btnExperimental.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExperimental.Location = new System.Drawing.Point(12, 41);
            this.btnExperimental.Name = "btnExperimental";
            this.btnExperimental.Size = new System.Drawing.Size(270, 23);
            this.btnExperimental.TabIndex = 0;
            this.btnExperimental.Text = "Run Experimental";
            this.btnExperimental.UseVisualStyleBackColor = true;
            this.btnExperimental.Click += new System.EventHandler(this.btnExperimental_Click);
            // 
            // btnStable
            // 
            this.btnStable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStable.Location = new System.Drawing.Point(12, 12);
            this.btnStable.Name = "btnStable";
            this.btnStable.Size = new System.Drawing.Size(270, 23);
            this.btnStable.TabIndex = 1;
            this.btnStable.Text = "Run Stable";
            this.btnStable.UseVisualStyleBackColor = true;
            this.btnStable.Click += new System.EventHandler(this.btnStable_Click);
            // 
            // btnUninstall
            // 
            this.btnUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUninstall.Location = new System.Drawing.Point(12, 151);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(270, 23);
            this.btnUninstall.TabIndex = 2;
            this.btnUninstall.Text = "Restore and Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // gbActive
            // 
            this.gbActive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbActive.Controls.Add(this.btnApply);
            this.gbActive.Controls.Add(this.cbActive);
            this.gbActive.Location = new System.Drawing.Point(13, 71);
            this.gbActive.Name = "gbActive";
            this.gbActive.Size = new System.Drawing.Size(269, 75);
            this.gbActive.TabIndex = 3;
            this.gbActive.TabStop = false;
            this.gbActive.Text = "Active Installation (Match to Steam Settings):";
            // 
            // cbActive
            // 
            this.cbActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActive.FormattingEnabled = true;
            this.cbActive.Items.AddRange(new object[] {
            "Stable",
            "Experimental"});
            this.cbActive.Location = new System.Drawing.Point(6, 19);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(257, 21);
            this.cbActive.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(188, 46);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 186);
            this.Controls.Add(this.gbActive);
            this.Controls.Add(this.btnStable);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.btnExperimental);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(310, 100);
            this.Name = "frmMain";
            this.Text = "DayZ Version Switcher";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbActive.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExperimental;
        private System.Windows.Forms.Button btnStable;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.GroupBox gbActive;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cbActive;
    }
}

