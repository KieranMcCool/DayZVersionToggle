using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayZVersionToggle
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        public static String oppositeVersion(String current)
        {
            if (current == "Stable") return "Experimental";
            else if (current == "Experimental") return "Stable";
            return "";
        }

        public static void copyDirectory(string SourcePath, string DestinationPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
        }

        public static void deleteDirectory(string SourcePath)
        {
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*")) {
                deleteDirectory(dirPath);
                foreach (string file in Directory.GetFiles(dirPath, "*"))
                    File.Delete(file);
                Directory.Delete(dirPath);
            }
            Directory.Delete(SourcePath);
        }

        public static void switchInstallation(string desiredVersion) { switchInstallation(desiredVersion, false); }

        public static void switchInstallation(string desiredVersion, bool updateProperty)
        {
            string org = Properties.Settings.Default.Directory + " - " + desiredVersion;
            string opposite = Properties.Settings.Default.Directory + " - " + oppositeVersion(desiredVersion);
            string dest = Properties.Settings.Default.Directory;
            if (Directory.Exists(opposite)) return;
            Directory.Move(dest, opposite);
            Directory.Move(org, dest);
            if (updateProperty)
            {
                Properties.Settings.Default.Version = desiredVersion;
                Properties.Settings.Default.Save();
            }
        }

        public static void runGame()
        {
            var p = Process.Start(Properties.Settings.Default.Directory + @"\DayZ_BE.exe");
            while (!processIsRunning("DayZ_BE")) System.Threading.Thread.Sleep(1000);
            while (processIsRunning("DayZ_BE")) System.Threading.Thread.Sleep(1000);
        }

        public static bool processIsRunning(string process)
        {
            return (System.Diagnostics.Process.GetProcessesByName(process).Length != 0);
        }
    }
}
