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
            this.BeginInvoke(new MethodInvoker(() => {
                lbLog.Items.Add(String.Format("{0}: {1}", DateTime.Now.ToShortTimeString(), text));
            }));
        }

        private void completeInstall()
        {
            performCopy();
            performOppositeInstall();
            done();
        }

        private void performCopy()
        {
            var message = String.Format("The program will now copy your current installation to \"{0} - {1}\" this can take a while. The program may appear unresponsive while this is happening.\nPress OK to start.",
                Properties.Settings.Default.Directory, Properties.Settings.Default.Version);
            this.addLogEntry(message);
            MessageBox.Show(message);
            this.addLogEntry("Copying files... This may take a while.");
            Program.copyDirectory(Properties.Settings.Default.Directory, Properties.Settings.Default.Directory + " - " + Properties.Settings.Default.Version);
            this.addLogEntry("Copy completed.");
        }

        private void performOppositeInstall()
        {
            var opposite = Program.oppositeVersion(Properties.Settings.Default.Version);
            this.addLogEntry(String.Format("Waiting on {0} installation", opposite));
            MessageBox.Show(String.Format("Now, you have to go to Steam and install {0} before clicking OK",
                opposite));

            if (MessageBox.Show("Has " + opposite + " installed successfully?", "Install " + opposite, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Properties.Settings.Default.Setup = true;
                this.addLogEntry("Done.");
                Properties.Settings.Default.Save();
            }
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            var t = new Task(() => completeInstall());
            t.Start();

        }

        private void done()
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }));
        }
    }
}
