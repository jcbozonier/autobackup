using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoBackup
{
    public static class Enumeration
    {
        public enum ReturnCodes
        {
            Success = 0,
            AddFolderError = 1,
            FileSaveError = 2,
            InvalidDirectoryError = 3,
            AlreadyInListError = 4,
            RemoveFolderError = 5,
            LoadBackupSetError = 6,
            BackupRunError = 7
        }
    }
}
