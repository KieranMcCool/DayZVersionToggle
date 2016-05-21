using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayZVersionToggle
{
    class Installer
    {
        public delegate void NotificationDelegate(string notification);
        public event NotificationDelegate ReceivedNotification;

        public delegate void CompleteDelegate();
        public event CompleteDelegate InstallComplete;

        public void completeInstall()
        {
            // The steps of installation.
            performCopy();
            performOppositeInstall();
            InstallComplete();
        }

        private void performCopy()
        {
            // Warn user of copy operation.
            var message = String.Format("The program will now copy your current installation to \"{0} - {1}\"This can take a while.\nPlease be patient.",
                Properties.Settings.Default.Directory, Properties.Settings.Default.Version);
            ReceivedNotification(message);
            // Copy dayz directory to holder directory for inactive branch.
            try
            {
                Program.copyDirectory(Properties.Settings.Default.Directory, Properties.Settings.Default.Directory + " - " + Properties.Settings.Default.Version);
                var s = new DirectoryInfo(Properties.Settings.Default.Directory).Parent.Parent.FullName + @"\appmanifest_221100.acf";
                File.Copy(s, string.Format("{0} - {1}", s, Properties.Settings.Default.Version));
            }
            // If errors occur, display message for debugging.
            catch (Exception ex) { ReceivedNotification(String.Format("Error copying files: {0}", ex.Message)); }
            // Done.
            ReceivedNotification("Copy completed.");
        }

        private void performOppositeInstall()
        {
            // promt user to go install the opposite version
            var opposite = Program.oppositeVersion(Properties.Settings.Default.Version);
            ReceivedNotification(String.Format("Waiting on {0} installation", opposite));
            MessageBox.Show(String.Format("Now, you have to go to Steam and install {0} before clicking OK",
                opposite));

            // If user confirms successful installation then we're installed so save, set response and close.
            if (MessageBox.Show("Has " + opposite + " installed successfully?", "Install " +
                opposite, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Properties.Settings.Default.Version = opposite;
                Properties.Settings.Default.Setup = true;
                ReceivedNotification("Done.");
                Properties.Settings.Default.Save();
            }
        }
    }
}
