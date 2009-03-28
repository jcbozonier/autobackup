using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoBackup
{
    public partial class SetBackup : Form
    {
        FolderData _backupSet;
        public SetBackup()
        {
            InitializeComponent();
            _backupSet = new FolderData();
            int loadResult = PopulateListBox();
            if(!(loadResult == (int)Enumeration.ReturnCodes.Success))
            {
                ShowErrorMessage(loadResult);
            }
        }

        private int PopulateListBox()
        {
            try
            {
                ArrayList myList = _backupSet.retrieveArrayList();
                for (int i = 0; i < myList.Count; i++)
                {
                    lbDirectoryList.Items.Add(myList[i]);
                }

                return (int)Enumeration.ReturnCodes.Success;
            }
            catch (Exception e)
            {
                return (int)Enumeration.ReturnCodes.LoadBackupSetError;
            }
        }

        private void bSelectDir_Click(object sender, EventArgs e)
        {
            fbdDirtoBackup.ShowDialog();
            tbCurrentDir.Text = fbdDirtoBackup.SelectedPath;
        }

        private void bAddFolder_Click(object sender, EventArgs e)
        {
            lErrorMessage.Visible = false;
            bSaveDirs.Enabled = true;

            string listBoxValue;
            int result = _backupSet.addFolder(tbCurrentDir.Text, out listBoxValue);
            if (result == (int)Enumeration.ReturnCodes.Success)
            {
                AddToListBox(listBoxValue);
            }
            else ShowErrorMessage(result);
        }

        private void AddToListBox(string toAdd)
        {
            lbDirectoryList.Items.Add(toAdd);
        }

        private void ShowErrorMessage(int ErrorCode)
        {
            switch (ErrorCode)
            {
                case (int)Enumeration.ReturnCodes.AddFolderError:
                    lErrorMessage.Text = "There was an error adding the folder.";
                    lErrorMessage.Visible = true;
                    break;
                case (int)Enumeration.ReturnCodes.AlreadyInListError:
                    lErrorMessage.Text = "Directory is already in the list.";
                    lErrorMessage.Visible = true;
                    break;
                case (int)Enumeration.ReturnCodes.InvalidDirectoryError:
                    lErrorMessage.Text = "Directory does not exist.";
                    lErrorMessage.Visible = true;
                    break;
                case (int)Enumeration.ReturnCodes.FileSaveError:
                    lErrorMessage.Text = "Error saving the backup set.";
                    lErrorMessage.Visible = true;
                    break;
                case (int)Enumeration.ReturnCodes.LoadBackupSetError:
                    lErrorMessage.Text = "Error loading previous backup set.";
                    lErrorMessage.Visible = true;
                    break;
                case (int)Enumeration.ReturnCodes.Success:
                    lErrorMessage.Visible = false;
                    break;
            }
        }

        private void tbCurrentDir_TextChanged(object sender, EventArgs e)
        {
            if (tbCurrentDir.Text.Length > 0)
                bAddFolder.Enabled = true;
            else bAddFolder.Enabled = false;
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            if (lbDirectoryList.SelectedItems.Count == 0)
                return;
            else
            {
                ArrayList selectedItems = GetSelectedItemsStringArray();
                if (_backupSet.removeFolders(selectedItems) == (int)Enumeration.ReturnCodes.Success)
                {
                    RemoveFromListBox(selectedItems);
                }
            }
        }

        private void RemoveFromListBox(ArrayList selected)
        {
            for (int i = 0; i < selected.Count; i++)
            {
                lbDirectoryList.Items.Remove(selected[i]);
            }
            if (lbDirectoryList.Items.Count == 0)
            {
                bSaveDirs.Enabled = false;
            }
        }

        private ArrayList GetSelectedItemsStringArray()
        {
            ArrayList toReturn = new ArrayList();

            for (int i = 0; i < lbDirectoryList.SelectedItems.Count; i++)
            {
                toReturn.Add(lbDirectoryList.SelectedItems[i]);
            }

            return toReturn;
        }

        private void bSaveDirs_Click(object sender, EventArgs e)
        {
            int result = (int)_backupSet.saveFolders();

            if (result == (int)Enumeration.ReturnCodes.Success)
            {
                this.Close();
            }
            else ShowErrorMessage(result);
        }

        private void bCancelChgDirs_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
