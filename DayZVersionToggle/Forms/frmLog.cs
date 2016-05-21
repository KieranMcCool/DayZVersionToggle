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

        private void frmLog_Load(object sender, EventArgs e)
        {
            var i = new Installer();
            i.ReceivedNotification += addLogEntry;
            i.InstallComplete += done;
            // Performs install in new thread so the window doesn't appear unresponsive during the copy operation.
            var t = new Task(() => i.completeInstall());
            t.Start();

        }

        private void done()
        {
            if(Properties.Settings.Default.Setup) DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
