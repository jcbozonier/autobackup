using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace AutoBackup
{
    class FolderData
    {
        ArrayList _backupSet;
        char[] delimiter;

        public FolderData()
        {
            _backupSet = new ArrayList();
            delimiter = new char[]{'|'};
            LoadBackupSetFromSettings();
        }

        public ArrayList retrieveArrayList()
        {
            return new ArrayList(_backupSet);
        }

        private int LoadBackupSetFromSettings()
        {
            try
            {
                string[] folders = null;
                string unparsedList = (string)Properties.Settings.Default["DirectoriesToBackup"];
                if (!unparsedList.Equals(""))
                {
                    folders = unparsedList.Split(delimiter);
                }
                CopyToClassVar(folders);
                return (int)Enumeration.ReturnCodes.Success;
            }
            catch (Exception e)
            {
                return (int)Enumeration.ReturnCodes.LoadBackupSetError;
            }
        }

        private void CopyToClassVar(string[] folders)
        {
            for (int i = 0; i < folders.Length; i++)
            {
                _backupSet.Add(folders[i]);
            }
        }

        public int addFolder(string toAdd, out string inListbox)
        {
            toAdd = appendToString(toAdd);

            if (IsValidDirectory(toAdd))
            {
                if (IsNotInList(toAdd))
                {
                    try
                    {
                        _backupSet.Add(toAdd);
                        inListbox = toAdd;
                        return (int)Enumeration.ReturnCodes.Success;
                    }
                    catch (Exception error)
                    {
                        inListbox = "";
                        return (int)Enumeration.ReturnCodes.AddFolderError;
                    }
                }
                else
                {
                    inListbox = "";
                    return (int)Enumeration.ReturnCodes.AlreadyInListError;
                }
            }
            else
            {
                inListbox = "";
                return (int)Enumeration.ReturnCodes.InvalidDirectoryError;
            }
        }

        public int removeFolders(ArrayList toRemove)
        {
            try
            {
                for (int i = 0; i < toRemove.Count; i++)
                {
                    _backupSet.Remove(toRemove[i]);
                }
                return (int)Enumeration.ReturnCodes.Success;
            }
            catch (Exception e)
            {
                return (int)Enumeration.ReturnCodes.RemoveFolderError;
            }
        }

        public int saveFolders()
        {
            try
            {
                string folderList = "";

                for (int i = 0; i < _backupSet.Count; i++)
                {
                    if (i == 0)
                    {
                        folderList += ((string)_backupSet[i]);
                    }
                    else folderList += delimiter[0].ToString() + ((string)_backupSet[i]);
                }

                Properties.Settings.Default["DirectoriesToBackup"] = folderList;
                Properties.Settings.Default.Save();

                return (int)Enumeration.ReturnCodes.Success;
            }
            catch (Exception e)
            {
                return (int)Enumeration.ReturnCodes.FileSaveError;
            }
        }

        private bool IsValidDirectory(string path)
        {
            if (Directory.Exists(path))
                return true;
            else return false;
        }

        private bool IsNotInList(string path)
        {
            if (_backupSet.Contains(path))
                return false;
            else return true;
        }

        private string appendToString(string toEdit)
        {
            if (!toEdit.EndsWith("\\"))
            {
                return toEdit + "\\";
            }
            else return toEdit;
        }
    }
}
