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
            // returns the opposite version from the input, if not valid, returns empty string.
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
            // Deletes all subdirectories/files in a directory and then deletes the directory
                // Used in removing the program during uninstallation.
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
            var swap = new Action<string, string, string>((target, destination, extension) => {
                if (Directory.Exists(target))
                {
                    Directory.Move(destination, string.Format("{0} - {1}", destination, extension));
                    Directory.Move(target, destination);
                }
                else if (File.Exists(target))
                {
                    File.Move(destination, string.Format("{0} - {1}", destination, extension));
                    File.Move(target, destination);
                }
                else throw new Exception(string.Format("Target directory: {0} does not exist on the filesystem.",
                    target));
            });

            try
            {
                string req = String.Format("{0} - {1}", Properties.Settings.Default.Directory, desiredVersion);
                string dest = Properties.Settings.Default.Directory;
                swap(req, dest, oppositeVersion(desiredVersion));

                dest = new DirectoryInfo(dest).Parent.Parent.FullName + @"\appmanifest_221100.acf";
                req = string.Format("{0} - {1}", dest, desiredVersion);
                swap(req, dest, oppositeVersion(desiredVersion));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error moving files. Submit log file for support.");
                var sw = new StreamWriter(string.Format("log {0}.txt", DateTime.Now.Ticks), false);
                sw.Write(string.Format("Message:\n{0}\nStack Trace:\n{1}", ex.Message, ex.StackTrace)); sw.Close(); sw.Dispose();
            }

            // Updating property for (semi) permanent replace then do so and save.
            if (updateProperty)
            {
                Properties.Settings.Default.Version = desiredVersion;
                Properties.Settings.Default.Save();
            }
        }

        public static void runGame()
        {
            // Start DayZ
            var p = Process.Start(Properties.Settings.Default.Directory + @"\DayZ_BE.exe");
            // Wait for DayZ to start
            while (!processIsRunning("DayZ_BE")) System.Threading.Thread.Sleep(1000);
            // Wait for DayZ to end.
            while (processIsRunning("DayZ_BE")) System.Threading.Thread.Sleep(1000);
        }

        public static bool processIsRunning(string process)
        {
            // Determines if a process with a given name is running.
            return (System.Diagnostics.Process.GetProcessesByName(process).Length != 0);
        }
    }
}
