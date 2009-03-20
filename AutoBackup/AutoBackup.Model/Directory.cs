using System;
using System.Collections.Generic;
using System.IO;
using IDirectoryAdapter=AutoBackup.Model.Interfaces.IDirectoryAdapter;

namespace AutoBackup.Model
{
    public class DirectoryAdapter : IDirectoryAdapter
    {
        public DirectoryAdapter()
        {
            var test = 1;
        }

        public void MoveDirectory(string targetDir, string newName)
        {
            Directory.Move(targetDir, newName);
            Directory.SetLastWriteTime(newName, DateTime.Now);
        }

        public void MakeDirectory(string newPath)
        {
            Directory.CreateDirectory(newPath);
        }

        public string[] GetDriveList()
        {
            return Directory.GetLogicalDrives();
        }

        public IList<string> GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }

        public DateTime GetDirectoryLastWriteTime(string directory)
        {
            return Directory.GetLastWriteTime(directory);
        }
    }
}