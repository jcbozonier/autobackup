using System;
using System.Windows.Forms;
using AutoBackup.Model.Interfaces;
using StructureMap;

namespace AutoBackup
{
    public partial class StartupForm : Form
    {
        private RunBackup runBackup;

        public StartupForm()
        {
            InitializeComponent();
            LoadStoredInfo();
        }

        private void LoadStoredInfo()
        {
            tbBackupDirectory.Text = (string)Properties.Settings.Default["BackupDirectory"];
            tbNumBackups.Text = Properties.Settings.Default["NumBackups"].ToString();
            lLastBackupSuccess.Text = Properties.Settings.Default["LastSuccessfulBackup"].ToString();
            if (!(bool)Properties.Settings.Default["LastResult"])
            {
                lLastRunResult.Text = "Failed";
                bShowError.Visible = true;
                rtbErrorMessage.Text = (string)Properties.Settings.Default["ErrorMessage"];
            }
            else
            {
                lLastRunResult.Text = "Success"; bShowError.Visible = false;
            }
        }

        private void bChangeBackupDir_Click(object sender, EventArgs e)
        {
            fbdBackupDirSelect.ShowDialog();
            if (!fbdBackupDirSelect.SelectedPath.Equals(""))
            {
                tbBackupDirectory.Text = fbdBackupDirSelect.SelectedPath;
                Properties.Settings.Default["BackupDirectory"] = fbdBackupDirSelect.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var setup = new SetBackup();
            setup.ShowDialog();
        }

        private void bChangeNumSaves_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["NumBackups"] = Int32.Parse(tbNumBackups.Text);
            Properties.Settings.Default.Save();
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bShowError_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
                bShowError.Text = "Show Error";
            }
            else
            {
                panel1.Visible = true;
                bShowError.Text = "Hide Message";
            }
        }

        private void bRunBackup_Click(object sender, EventArgs e)
        {
            var executor = ObjectFactory.GetInstance<RunBackup>();

            var backupResult = executor.ExecuteBackup(true);
            Program.StoreRunResults(backupResult);
            LoadStoredInfo();
        }
    }
}
