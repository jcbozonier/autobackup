using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StructureMap;

namespace AutoBackup
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            // Here we gather all of the implementations of all of the 
            // needed interfaces so that we can instantiate when we're
            // ready to.
            DependencyLoader.BootstrapStructureMap();

            if (args.Length == 2 && args[1].Equals("-silent"))
            {
                RunBackup executor = ObjectFactory.GetInstance<RunBackup>();

                int backupResult = executor.ExecuteBackup(true);
                StoreRunResults(backupResult);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new StartupForm());
            }
        }

        public static void StoreRunResults(int result)
        {
            if (result == (int)Enumeration.ReturnCodes.Success)
            {
                Properties.Settings.Default["LastResult"] = true;
                Properties.Settings.Default["LastSuccessfulBackup"] = DateTime.Now;
            }
            else Properties.Settings.Default["LastResult"] = false;

            Properties.Settings.Default.Save();
        }
    }
}
