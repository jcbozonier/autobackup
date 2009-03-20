using System;
using System.Collections.Generic;
using AutoBackup.Model.Interfaces;
using IBackupAccess=AutoBackup.Model.Interfaces.IBackupAccess;
using ISettingsProvider=AutoBackup.Model.Interfaces.ISettingsProvider;

namespace AutoBackup.Model
{
    public class BackupDirectories : IBackupAccess
    {
        private ISettingsProvider _Settings;
        private IDirectoryAdapter _Directory;
        private char[] _Delimiter;

        public BackupDirectories(ISettingsProvider settings, IDirectoryAdapter directory)
        {
            _Settings = settings;
            _Directory = directory;
            _Delimiter = new[] { '|' };
        }

        private IList<string> getDirectoriesInBackupDirectory()
        {
            return _Directory.GetDirectories((string)_Settings.Get("BackupDirectory"));
        }

        public IEnumerable<string> GetDirectoriesToBackup()
        {
            var unparsedList = (string)_Settings.Get("DirectoriesToBackup");

            if (String.IsNullOrEmpty(unparsedList)) return null;

            var folders = unparsedList.Split(_Delimiter);
            return folders;
        }

        public string MakeNewDirectoryInBackupDirectory(string directory)
        {
            if(String.IsNullOrEmpty(backupPath))
                throw new NullReferenceException("SetupBackupTarget should have been ran first.");

            var newDir = backupPath + parseRoot(directory);
            _Directory.MakeDirectory(newDir);

            return newDir;
        }

        private string parseRoot(string toParse)
        {
            var driveList = _Directory.GetDriveList();

            for (int i = 0; i < driveList.Length; i++)
            {
                if (toParse.StartsWith(driveList[i]))
                {
                    return "\\" + driveList[i].Substring(0, 1) + "\\" + toParse.Substring(3, toParse.Length - 3);
                }
            }
            return toParse;
        }

        private string backupPath;

        public void SetupBackupTarget()
        {
            var backupDirectory = _Settings.Get("BackupDirectory");

            var newName = String.Format("{0}\\Backup_{1}_{2}_{3}_{4}",
                                        backupDirectory,
                                        DateTime.Now.Month,
                                        DateTime.Now.Day,
                                        DateTime.Now.Year,
                                        DateTime.Now.TimeOfDay.TotalMilliseconds);

            var overwriteDirectory = getDirectoryToOverwrite();
            if (overwriteDirectory == null)
                _Directory.MakeDirectory(newName);
            else
                _Directory.MoveDirectory(overwriteDirectory, newName);

            backupPath = newName;
        }

        private string getDirectoryToOverwrite()
        {
            string toReturn = null;
            try
            {
                var backupDirs = getDirectoriesInBackupDirectory();
                var oldestDate = DateTime.MaxValue;

                if (!(backupDirs.Count < (int)_Settings.Get("NumBackups")))
                {
                    foreach (var currentDirectory in backupDirs)
                    {
                        var directoryLastWriteTime = _Directory.GetDirectoryLastWriteTime(currentDirectory);

                        if (directoryLastWriteTime.IsSameAgeOrNewerThan(oldestDate)) continue;

                        oldestDate = directoryLastWriteTime;
                        toReturn = currentDirectory;
                    }

                    return toReturn;
                }//end if statement
                return null;
            }//end try
            catch (Exception e)
            {
                return null;
            }//end catch
        }
    }
}