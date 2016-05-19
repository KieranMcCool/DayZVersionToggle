using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayZVersionToggle
{
    public partial class frmSetup : Form
    {
        public frmSetup()
        {
            InitializeComponent();
            cbCurrent.SelectedIndex = 0;
        }

        frmLog log = new frmLog();

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tbDir.Text != "")
            {
                // Update settings for next stage of install
                Properties.Settings.Default.Version = cbCurrent.Text;
                Properties.Settings.Default.Directory = tbDir.Text;
                if (log.ShowDialog() == DialogResult.OK) this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void btnDirChange_Click(object sender, EventArgs e)
        {
            // Get folder from user, validate it's DayZ and update.
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                bool valid = File.Exists(fbd.SelectedPath + @"\DayZ.exe");
                btnNext.Enabled = valid;
                if (valid) tbDir.Text = fbd.SelectedPath;
                else
                {
                    MessageBox.Show("Directory doesn't contain a DayZ Executable");
                    tbDir.Text = "";
                }
            }
        }
    }
}
