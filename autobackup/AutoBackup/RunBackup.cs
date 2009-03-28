using System;
using AutoBackup.Model;
using AutoBackup.Model.Interfaces;
using Microsoft.Synchronization.Files;

namespace AutoBackup
{
    public class RunBackup
    {
        private IFileSync _FileSystem;
        private IInteractionContext _Interactions;
        private ISettingsProvider _Settings;
        private IBackupAccess _BackupDirectory;

        /// <summary>
        /// Uses dependency injection and inversion of control. By using these
        /// techniques we make the object constructing this object provide all
        /// of the external dependencies. The code is less fragile, reuse is 
        /// encouraged, and there should be less bugs.
        /// Look at the DependencyLoader to see how we're telling the system to
        /// load the implementation classes for this class.
        /// </summary>
        /// <param name="fileSync"></param>
        /// <param name="userInteractions"></param>
        /// <param name="settings"></param>
        /// <param name="backupAccess"></param>
        public RunBackup(
            IFileSync fileSync, 
            IInteractionContext userInteractions, 
            ISettingsProvider settings, 
            IBackupAccess backupAccess)
        {
            _FileSystem = fileSync;
            _Interactions = userInteractions;
            _Settings = settings;
            _BackupDirectory = backupAccess;

            _FileSystem.AppliedChange += OnAppliedChange;
            _FileSystem.SkippedChange += OnSkippedChange;
        }

        public int ExecuteBackup(bool runSilent)
        {
            try
            {
                _BackupDirectory.SetupBackupTarget();

                var dirsToBackup = _BackupDirectory.GetDirectoriesToBackup();

                if (dirsToBackup != null)
                {
                    foreach(var directory in dirsToBackup)
                    {
                        var newDir = _BackupDirectory.MakeNewDirectoryInBackupDirectory(directory);
                        _FileSystem.SyncFolders(directory, newDir);
                    }
                }
            }
            catch (Exception e)
            {
                _Settings.Save("ErrorMessage", e.ToString());

                return (int)Enumeration.ReturnCodes.BackupRunError;
            }

            return (int)Enumeration.ReturnCodes.Success;
        }


        public void OnAppliedChange(object sender, MyAppliedChangeEventArgs args)
        {
            switch (args.ChangeType)
            {
                case ChangeType.Create:
                    _Interactions.AlertCreated(args);
                    break;
                case ChangeType.Delete:
                    _Interactions.AlertDeleted(args);
                    break;
                case ChangeType.Update:
                    _Interactions.AlertUpdated(args);
                    break;
                case ChangeType.Rename:
                    _Interactions.AlertRenamed(args);
                    break;
            }
        }

        public void OnSkippedChange(object sender, MySkippedChangeEventArgs args)
        {
            var changeType = args.ChangeType.ToString().ToUpper();
            var path = (!string.IsNullOrEmpty(args.CurrentFilePath)
                            ? args.CurrentFilePath
                            : args.NewFilePath);
            _Interactions.AlertSkipped(changeType, path, args.Exception);
        }    
    }
}
