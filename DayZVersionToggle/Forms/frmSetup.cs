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
            Properties.Settings.Default.Version = cbCurrent.Text;
            Properties.Settings.Default.Directory = tbDir.Text;
            if (log.ShowDialog() == DialogResult.OK) this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDirChange_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fbd.SelectedPath + @"\DayZ.exe"))
                    tbDir.Text = fbd.SelectedPath;
                else MessageBox.Show("Directory doesn't contain a DayZ Executable");
            }
        }
    }
}
