namespace AutoBackup
{
    partial class StartupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbBackupDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lLastRunResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lLastBackupSuccess = new System.Windows.Forms.Label();
            this.bChangeBackupDir = new System.Windows.Forms.Button();
            this.fbdBackupDirSelect = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tbNumBackups = new System.Windows.Forms.TextBox();
            this.bChangeNumSaves = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbErrorMessage = new System.Windows.Forms.RichTextBox();
            this.bShowError = new System.Windows.Forms.Button();
            this.bRunBackup = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbBackupDirectory
            // 
            this.tbBackupDirectory.Location = new System.Drawing.Point(26, 102);
            this.tbBackupDirectory.Name = "tbBackupDirectory";
            this.tbBackupDirectory.Size = new System.Drawing.Size(184, 20);
            this.tbBackupDirectory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Last Run Result:";
            // 
            // lLastRunResult
            // 
            this.lLastRunResult.AutoSize = true;
            this.lLastRunResult.Location = new System.Drawing.Point(109, 18);
            this.lLastRunResult.Name = "lLastRunResult";
            this.lLastRunResult.Size = new System.Drawing.Size(33, 13);
            this.lLastRunResult.TabIndex = 2;
            this.lLastRunResult.Text = "[N/A]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Successful Backup:";
            // 
            // lLastBackupSuccess
            // 
            this.lLastBackupSuccess.AutoSize = true;
            this.lLastBackupSuccess.Location = new System.Drawing.Point(148, 40);
            this.lLastBackupSuccess.Name = "lLastBackupSuccess";
            this.lLastBackupSuccess.Size = new System.Drawing.Size(33, 13);
            this.lLastBackupSuccess.TabIndex = 4;
            this.lLastBackupSuccess.Text = "[N/A]";
            // 
            // bChangeBackupDir
            // 
            this.bChangeBackupDir.Location = new System.Drawing.Point(225, 102);
            this.bChangeBackupDir.Name = "bChangeBackupDir";
            this.bChangeBackupDir.Size = new System.Drawing.Size(101, 23);
            this.bChangeBackupDir.TabIndex = 5;
            this.bChangeBackupDir.Text = "Change Directory";
            this.bChangeBackupDir.UseVisualStyleBackColor = true;
            this.bChangeBackupDir.Click += new System.EventHandler(this.bChangeBackupDir_Click);
            // 
            // fbdBackupDirSelect
            // 
            this.fbdBackupDirSelect.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Change Backup Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbNumBackups
            // 
            this.tbNumBackups.Location = new System.Drawing.Point(390, 102);
            this.tbNumBackups.Name = "tbNumBackups";
            this.tbNumBackups.Size = new System.Drawing.Size(58, 20);
            this.tbNumBackups.TabIndex = 7;
            this.tbNumBackups.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bChangeNumSaves
            // 
            this.bChangeNumSaves.Location = new System.Drawing.Point(478, 102);
            this.bChangeNumSaves.Name = "bChangeNumSaves";
            this.bChangeNumSaves.Size = new System.Drawing.Size(75, 23);
            this.bChangeNumSaves.TabIndex = 9;
            this.bChangeNumSaves.Text = "Change";
            this.bChangeNumSaves.UseVisualStyleBackColor = true;
            this.bChangeNumSaves.Click += new System.EventHandler(this.bChangeNumSaves_Click);
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(478, 361);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 10;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rtbErrorMessage);
            this.panel1.Location = new System.Drawing.Point(263, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 337);
            this.panel1.TabIndex = 11;
            this.panel1.Visible = false;
            // 
            // rtbErrorMessage
            // 
            this.rtbErrorMessage.BackColor = System.Drawing.Color.White;
            this.rtbErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbErrorMessage.Location = new System.Drawing.Point(0, 0);
            this.rtbErrorMessage.Name = "rtbErrorMessage";
            this.rtbErrorMessage.ReadOnly = true;
            this.rtbErrorMessage.Size = new System.Drawing.Size(288, 335);
            this.rtbErrorMessage.TabIndex = 1;
            this.rtbErrorMessage.Text = "";
            // 
            // bShowError
            // 
            this.bShowError.Location = new System.Drawing.Point(180, 18);
            this.bShowError.Name = "bShowError";
            this.bShowError.Size = new System.Drawing.Size(75, 19);
            this.bShowError.TabIndex = 12;
            this.bShowError.Text = "Show Error";
            this.bShowError.UseVisualStyleBackColor = true;
            this.bShowError.Visible = false;
            this.bShowError.Click += new System.EventHandler(this.bShowError_Click);
            // 
            // bRunBackup
            // 
            this.bRunBackup.Location = new System.Drawing.Point(27, 208);
            this.bRunBackup.Name = "bRunBackup";
            this.bRunBackup.Size = new System.Drawing.Size(75, 23);
            this.bRunBackup.TabIndex = 13;
            this.bRunBackup.Text = "Run Backup";
            this.bRunBackup.UseVisualStyleBackColor = true;
            this.bRunBackup.Click += new System.EventHandler(this.bRunBackup_Click);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(565, 404);
            this.Controls.Add(this.bRunBackup);
            this.Controls.Add(this.bShowError);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bChangeNumSaves);
            this.Controls.Add(this.tbNumBackups);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bChangeBackupDir);
            this.Controls.Add(this.lLastBackupSuccess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lLastRunResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbBackupDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartupForm";
            this.Text = "AutoBackup";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBackupDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lLastRunResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lLastBackupSuccess;
        private System.Windows.Forms.Button bChangeBackupDir;
        private System.Windows.Forms.FolderBrowserDialog fbdBackupDirSelect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbNumBackups;
        private System.Windows.Forms.Button bChangeNumSaves;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bShowError;
        private System.Windows.Forms.RichTextBox rtbErrorMessage;
        private System.Windows.Forms.Button bRunBackup;
    }
}