namespace AutoBackup
{
    partial class SetBackup
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
            this.tbCurrentDir = new System.Windows.Forms.TextBox();
            this.fbdDirtoBackup = new System.Windows.Forms.FolderBrowserDialog();
            this.lErrorMessage = new System.Windows.Forms.Label();
            this.bSelectDir = new System.Windows.Forms.Button();
            this.bAddFolder = new System.Windows.Forms.Button();
            this.lbDirectoryList = new System.Windows.Forms.ListBox();
            this.bRemove = new System.Windows.Forms.Button();
            this.bSaveDirs = new System.Windows.Forms.Button();
            this.bCancelChgDirs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbCurrentDir
            // 
            this.tbCurrentDir.Location = new System.Drawing.Point(12, 31);
            this.tbCurrentDir.Name = "tbCurrentDir";
            this.tbCurrentDir.Size = new System.Drawing.Size(251, 20);
            this.tbCurrentDir.TabIndex = 0;
            this.tbCurrentDir.TextChanged += new System.EventHandler(this.tbCurrentDir_TextChanged);
            // 
            // lErrorMessage
            // 
            this.lErrorMessage.AutoSize = true;
            this.lErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lErrorMessage.Location = new System.Drawing.Point(282, 31);
            this.lErrorMessage.Name = "lErrorMessage";
            this.lErrorMessage.Size = new System.Drawing.Size(35, 13);
            this.lErrorMessage.TabIndex = 1;
            this.lErrorMessage.Text = "[Error]";
            this.lErrorMessage.Visible = false;
            // 
            // bSelectDir
            // 
            this.bSelectDir.Location = new System.Drawing.Point(13, 58);
            this.bSelectDir.Name = "bSelectDir";
            this.bSelectDir.Size = new System.Drawing.Size(113, 23);
            this.bSelectDir.TabIndex = 2;
            this.bSelectDir.Text = "Select Directory";
            this.bSelectDir.UseVisualStyleBackColor = true;
            this.bSelectDir.Click += new System.EventHandler(this.bSelectDir_Click);
            // 
            // bAddFolder
            // 
            this.bAddFolder.Enabled = false;
            this.bAddFolder.Location = new System.Drawing.Point(156, 58);
            this.bAddFolder.Name = "bAddFolder";
            this.bAddFolder.Size = new System.Drawing.Size(107, 23);
            this.bAddFolder.TabIndex = 3;
            this.bAddFolder.Text = "Add Directory";
            this.bAddFolder.UseVisualStyleBackColor = true;
            this.bAddFolder.Click += new System.EventHandler(this.bAddFolder_Click);
            // 
            // lbDirectoryList
            // 
            this.lbDirectoryList.FormattingEnabled = true;
            this.lbDirectoryList.Location = new System.Drawing.Point(13, 102);
            this.lbDirectoryList.Name = "lbDirectoryList";
            this.lbDirectoryList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbDirectoryList.Size = new System.Drawing.Size(794, 381);
            this.lbDirectoryList.TabIndex = 4;
            // 
            // bRemove
            // 
            this.bRemove.Location = new System.Drawing.Point(13, 490);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(140, 23);
            this.bRemove.TabIndex = 5;
            this.bRemove.Text = "Remove Selected";
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // bSaveDirs
            // 
            this.bSaveDirs.Enabled = false;
            this.bSaveDirs.Location = new System.Drawing.Point(595, 490);
            this.bSaveDirs.Name = "bSaveDirs";
            this.bSaveDirs.Size = new System.Drawing.Size(75, 23);
            this.bSaveDirs.TabIndex = 6;
            this.bSaveDirs.Text = "Save";
            this.bSaveDirs.UseVisualStyleBackColor = true;
            this.bSaveDirs.Click += new System.EventHandler(this.bSaveDirs_Click);
            // 
            // bCancelChgDirs
            // 
            this.bCancelChgDirs.Location = new System.Drawing.Point(689, 490);
            this.bCancelChgDirs.Name = "bCancelChgDirs";
            this.bCancelChgDirs.Size = new System.Drawing.Size(75, 23);
            this.bCancelChgDirs.TabIndex = 7;
            this.bCancelChgDirs.Text = "Cancel";
            this.bCancelChgDirs.UseVisualStyleBackColor = true;
            this.bCancelChgDirs.Click += new System.EventHandler(this.bCancelChgDirs_Click);
            // 
            // SetBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 540);
            this.Controls.Add(this.bCancelChgDirs);
            this.Controls.Add(this.bSaveDirs);
            this.Controls.Add(this.bRemove);
            this.Controls.Add(this.lbDirectoryList);
            this.Controls.Add(this.bAddFolder);
            this.Controls.Add(this.bSelectDir);
            this.Controls.Add(this.lErrorMessage);
            this.Controls.Add(this.tbCurrentDir);
            this.Name = "SetBackup";
            this.Text = "Choose Your Backup Set";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCurrentDir;
        private System.Windows.Forms.FolderBrowserDialog fbdDirtoBackup;
        private System.Windows.Forms.Label lErrorMessage;
        private System.Windows.Forms.Button bSelectDir;
        private System.Windows.Forms.Button bAddFolder;
        private System.Windows.Forms.ListBox lbDirectoryList;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.Button bSaveDirs;
        private System.Windows.Forms.Button bCancelChgDirs;
    }
}