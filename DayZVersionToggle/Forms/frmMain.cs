﻿using System;
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
            // Run setup if not already done
            if (!Properties.Settings.Default.Setup) runSetup();
            // Init the cbActive box
            cbActive.SelectedItem = Properties.Settings.Default.Version;
        }

        private void runSetup()
        {
            // Creates setup form and handles errors.
            var s = new frmSetup();
            if (s.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Setup was not completed. Exiting.");
                Application.Exit();
            }
        }

        private void btnExperimental_Click(object sender, EventArgs e)
        {
            switchAndRun("Experimental");
        }

        private void btnStable_Click(object sender, EventArgs e)
        {
            switchAndRun("Stable");
        }

        private void switchAndRun(string version)
        {
            // Switch to desired installation
            Program.switchInstallation(version);
            // Launches game
            Program.runGame();
            // Switches back to what steam reckons is installed.
            Program.switchInstallation(Properties.Settings.Default.Version);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Switch to desired version
            Program.switchInstallation(cbActive.Items[cbActive.SelectedIndex].ToString(), true);
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            // Removes the version that steam doesn't know about and resets the program's settings.
            var unwanted = String.Format("{0} - {1}", Properties.Settings.Default.Directory, 
                Program.oppositeVersion(Properties.Settings.Default.Version));
            if (Directory.Exists(unwanted)) Program.deleteDirectory(unwanted);

            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            // Closes the program.
            Application.Exit();
        }
    }
}
