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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private string getDayZFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                bool valid = File.Exists(fbd.SelectedPath + @"\DayZ.exe");
                if (valid) return fbd.SelectedPath; 
                MessageBox.Show("Directory doesn't contain a DayZ Executable");
            }
            return "";
        }

        private string getAppManifest()
        {

        }
    }
}
