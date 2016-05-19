namespace DayZVersionToggle
{
    partial class frmSetup
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
            this.lblCurrent = new System.Windows.Forms.Label();
            this.cbCurrent = new System.Windows.Forms.ComboBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.tbDir = new System.Windows.Forms.TextBox();
            this.btnDirChange = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(2, 34);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(82, 13);
            this.lblCurrent.TabIndex = 0;
            this.lblCurrent.Text = "Current Version:";
            // 
            // cbCurrent
            // 
            this.cbCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrent.FormattingEnabled = true;
            this.cbCurrent.Items.AddRange(new object[] {
            "Stable",
            "Experimental"});
            this.cbCurrent.Location = new System.Drawing.Point(90, 31);
            this.cbCurrent.Name = "cbCurrent";
            this.cbCurrent.Size = new System.Drawing.Size(192, 21);
            this.cbCurrent.TabIndex = 1;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(2, 8);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(81, 13);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "DayZ Directory:";
            // 
            // tbDir
            // 
            this.tbDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDir.Location = new System.Drawing.Point(90, 5);
            this.tbDir.Name = "tbDir";
            this.tbDir.ReadOnly = true;
            this.tbDir.Size = new System.Drawing.Size(176, 20);
            this.tbDir.TabIndex = 3;
            // 
            // btnDirChange
            // 
            this.btnDirChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirChange.Location = new System.Drawing.Point(261, 4);
            this.btnDirChange.Name = "btnDirChange";
            this.btnDirChange.Size = new System.Drawing.Size(21, 22);
            this.btnDirChange.TabIndex = 4;
            this.btnDirChange.UseVisualStyleBackColor = true;
            this.btnDirChange.Click += new System.EventHandler(this.btnDirChange_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(207, 58);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // frmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 88);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnDirChange);
            this.Controls.Add(this.tbDir);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.cbCurrent);
            this.Controls.Add(this.lblCurrent);
            this.MinimumSize = new System.Drawing.Size(303, 127);
            this.Name = "frmSetup";
            this.Text = "Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.ComboBox cbCurrent;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox tbDir;
        private System.Windows.Forms.Button btnDirChange;
        private System.Windows.Forms.Button btnNext;
    }
}