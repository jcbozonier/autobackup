using System;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;

namespace AutoBackup.Model.Interfaces
{
    public interface IFileSync
    {
        void DetectChangesOnFileSystemReplica(
            SyncId replicaId,
            string replicaRootPath,
            FileSyncScopeFilter filter,
            FileSyncOptions options);

        event EventHandler<MyAppliedChangeEventArgs> AppliedChange;
        event EventHandler<MySkippedChangeEventArgs> SkippedChange;

        void SyncFileSystemReplicasOneWay(
            SyncId sourceReplicaId,
            SyncId destinationReplicaId,
            string sourceReplicaRootPath,
            string destinationReplicaRootPath,
            FileSyncScopeFilter filter,
            FileSyncOptions options);

        void SyncFolders(string sourceFolder, string targetFolder);
    }
}