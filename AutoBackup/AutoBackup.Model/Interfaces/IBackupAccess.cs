using System.Collections.Generic;

namespace AutoBackup.Model.Interfaces
{
    public interface IBackupAccess
    {
        IEnumerable<string> GetDirectoriesToBackup();
        string MakeNewDirectoryInBackupDirectory(string directory);
        void SetupBackupTarget();
    }
}