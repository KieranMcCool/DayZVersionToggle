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
            log.ShowDialog();
        }

        
    }
}
