using System;
using System.Collections.Generic;

namespace AutoBackup.Model.Interfaces
{
    public interface IDirectoryAdapter
    {
        void MoveDirectory(string targetDir, string newName);
        void MakeDirectory(string newPath);
        string[] GetDriveList();
        IList<string> GetDirectories(string path);
        DateTime GetDirectoryLastWriteTime(string directory);
    }
}