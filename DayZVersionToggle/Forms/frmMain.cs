using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace DayZVersionToggle
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.Setup) runSetup();
            cbActive.SelectedItem = Properties.Settings.Default.Version;
        }

        private void runSetup()
        {
            var s = new frmSetup();
            if (s.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Setup was not completed. Exiting.");
                Application.Exit();
            }
        }

        private void btnExperimental_Click(object sender, EventArgs e)
        {
            Program.switchInstallation("Experimental");
            Program.runGame();
            Program.switchInstallation(Properties.Settings.Default.Version);
        }

        private void btnStable_Click(object sender, EventArgs e)
        {
            Program.switchInstallation("Stable");
            Program.runGame();
            Program.switchInstallation(Properties.Settings.Default.Version);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Program.switchInstallation(cbActive.Items[cbActive.SelectedIndex].ToString(), true);
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            var unwanted = Properties.Settings.Default.Directory + " - Stable";
            if (Directory.Exists(unwanted)) Program.deleteDirectory(unwanted);
            unwanted = Properties.Settings.Default.Directory + " - Stable";
            if (Directory.Exists(unwanted)) Program.deleteDirectory(unwanted);
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            Application.Exit();
        }
    }
}
