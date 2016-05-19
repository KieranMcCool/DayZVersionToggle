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
    public partial class frmLog : Form
    {
        public frmLog()
        {
            InitializeComponent();
        }

        public void addLogEntry(String text)
        {
            // Enters the window thread and adds to the list box.
            this.BeginInvoke(new MethodInvoker(() => {
                lbLog.Items.Add(String.Format("{0}: {1}", DateTime.Now.ToShortTimeString(), text));
            }));
        }

        private void completeInstall()
        {
            // The steps of installation.
            performCopy();
            performOppositeInstall();
            done();
        }

        private void performCopy()
        {
            // Warn user of copy operation.
            var message = String.Format("The program will now copy your current installation to \"{0} - {1}\" this can take a while. The program may appear unresponsive while this is happening.\nPress OK to start.",
                Properties.Settings.Default.Directory, Properties.Settings.Default.Version);
            addLogEntry(message);
            MessageBox.Show(message);
            addLogEntry("Copying files... This may take a while.");
            // Copy dayz directory to holder directory for inactive branch.
            try
            {
                Program.copyDirectory(Properties.Settings.Default.Directory, Properties.Settings.Default.Directory + " - " + Properties.Settings.Default.Version);
            }
            // If errors occur, display message for debugging.
            catch (Exception ex) { addLogEntry(String.Format("Error copying files: {0}", ex.Message)); this.DialogResult = DialogResult.Abort; this.Close();  }
            // Done.
            addLogEntry("Copy completed.");
        }

        private void performOppositeInstall()
        {
            // promt user to go install the opposite version
            var opposite = Program.oppositeVersion(Properties.Settings.Default.Version);
            addLogEntry(String.Format("Waiting on {0} installation", opposite));
            MessageBox.Show(String.Format("Now, you have to go to Steam and install {0} before clicking OK",
                opposite));

            // If user confirms successful installation then we're installed so save, set response and close.
            if (MessageBox.Show("Has " + opposite + " installed successfully?", "Install " + 
                opposite, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Properties.Settings.Default.Version = opposite;
                Properties.Settings.Default.Setup = true;
                addLogEntry("Done.");
                Properties.Settings.Default.Save();
            }
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            // Performs install in new thread so the window doesn't appear unresponsive during the copy operation.
            var t = new Task(() => completeInstall());
            t.Start();

        }

        private void done()
        {
            // Enters main thread and closes the window.
            this.BeginInvoke(new MethodInvoker(() =>
            {
                if(Properties.Settings.Default.Setup) DialogResult = DialogResult.OK;
                this.Close();
            }));
        }
    }
}
