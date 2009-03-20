using System;
using System.IO;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;
using IFileSync=AutoBackup.Model.Interfaces.IFileSync;

namespace AutoBackup.Model
{
    public class FileSync : IFileSync
    {
        public FileSync()
        {
            var test = 1;
        }

        public void DetectChangesOnFileSystemReplica(
            SyncId replicaId,
            string replicaRootPath,
            FileSyncScopeFilter filter,
            FileSyncOptions options)
        {
            using (var provider = createFileSyncProvider(replicaId.GetGuidId(), replicaRootPath, filter, options))
                provider.DetectChanges();
        }

        //This is our way of abstracting out this dependency since I'm sure it probably ties
        // us to the filesystem.
        private FileSyncProvider createFileSyncProvider(Guid replicaId, string replicaRootPath, FileSyncScopeFilter filter, FileSyncOptions options)
        {
            var provider = new FileSyncProvider(replicaId, replicaRootPath, filter, options);
            return provider;
        }

        public event EventHandler<MyAppliedChangeEventArgs> AppliedChange;
        public event EventHandler<MySkippedChangeEventArgs> SkippedChange;

        public void SyncFileSystemReplicasOneWay(
            SyncId sourceReplicaId,
            SyncId destinationReplicaId,
            string sourceReplicaRootPath,
            string destinationReplicaRootPath,
            FileSyncScopeFilter filter,
            FileSyncOptions options)
        {

            using (var sourceProvider = createFileSyncProvider(
                sourceReplicaId.GetGuidId(),
                sourceReplicaRootPath,
                filter,
                options))
            using (var destinationProvider = createFileSyncProvider(
                destinationReplicaId.GetGuidId(),
                destinationReplicaRootPath,
                filter,
                options))
            {
                destinationProvider.AppliedChange += destinationProvider_AppliedChange;
                destinationProvider.SkippedChange += destinationProvider_SkippedChange;

                sourceProvider.DetectChanges();
                destinationProvider.DetectChanges();

                synchronizeProviders(destinationProvider, sourceProvider);
            }
        }

        void destinationProvider_SkippedChange(object sender, SkippedChangeEventArgs e)
        {
            if (SkippedChange != null)
                SkippedChange(sender, new MySkippedChangeEventArgs()
                                          {
                                              ChangeType = e.ChangeType
                                          });
        }

        void destinationProvider_AppliedChange(object sender, AppliedChangeEventArgs e)
        {
            if (AppliedChange != null)
                AppliedChange(sender, new MyAppliedChangeEventArgs()
                                          {
                                              ChangeType = e.ChangeType,
                                              OldFilePath = e.OldFilePath,
                                              NewFilePath = e.NewFilePath
                                          });
        }

        private void synchronizeProviders(FileSyncProvider destinationProvider, FileSyncProvider sourceProvider)
        {
            var sync = new SyncOrchestrator
                           {
                               LocalProvider = sourceProvider,
                               RemoteProvider = destinationProvider,
                               Direction = SyncDirectionOrder.Upload
                           };

            sync.Synchronize();
        }

        public void SyncFolders(string sourceFolder, string targetFolder)
        {
            if (sourceFolder.Equals(""))
                return;

            const string idFileName = "filesync.id";

            var sourceId = getOrCreateReplicaId(Path.Combine(sourceFolder, idFileName));
            var targetId = getOrCreateReplicaId(Path.Combine(targetFolder, idFileName));

            // Set options for the sync operation
            var options = FileSyncOptions.ExplicitDetectChanges;

            var filter = new FileSyncScopeFilter();
            filter.FileNameExcludes.Add(idFileName); // Exclude the id file

            // Explicitly detect changes on both replicas upfront, to avoid two change
            // detection passes for the two-way sync
            DetectChangesOnFileSystemReplica(
                sourceId, sourceFolder, filter, options);
            DetectChangesOnFileSystemReplica(
                targetId, targetFolder, filter, options);

            // Sync
            SyncFileSystemReplicasOneWay(
                sourceId,
                targetId,
                sourceFolder,
                targetFolder,
                filter,
                options);
        }

        private SyncId getOrCreateReplicaId(string idFilePath)
        {
            var replicaId = createReplicaId(idFilePath);
            // return replicaId but if it's null create a new one first.
            return replicaId ?? createNewReplicaId(idFilePath);
        }

        private SyncId createNewReplicaId(string idFilePath)
        {
            SyncId replicaId;
            using (var idFile = File.Open(
                idFilePath,
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite))
            using (var sw = new StreamWriter(idFile))
            {
                replicaId = new SyncId(Guid.NewGuid());
                sw.WriteLine(replicaId.GetGuidId().ToString("D"));
            }
            return replicaId;
        }

        private SyncId createReplicaId(string idFilePath)
        {
            SyncId replicaId = null;

            if (File.Exists(idFilePath))
            {
                using (var sr = File.OpenText(idFilePath))
                {
                    var strGuid = sr.ReadLine();
                    if (!string.IsNullOrEmpty(strGuid))
                        replicaId = new SyncId(new Guid(strGuid));
                }
            }
            return replicaId;
        }
    }
}