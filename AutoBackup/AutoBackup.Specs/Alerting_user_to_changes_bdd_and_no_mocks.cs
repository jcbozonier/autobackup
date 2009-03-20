using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoBackup.Model;
using AutoBackup.Model.Interfaces;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;
using NUnit.Framework;
using SpecUnit;

namespace AutoBackup.Specs
{
    [TestFixture]
    public class When_a_file_is_renamed : running_backups_context
    {
        private RunBackup BackupRunner;
        private TestInteractionContext Gui;

        [Test]
        public void It_should_alert_the_user_that_a_file_was_renamed()
        {
            Gui.ChangeMade.ShouldEqual(ChangeType.Rename);
        }

        protected override void Because()
        {
            BackupRunner.OnAppliedChange(null, new MyAppliedChangeEventArgs() { ChangeType = ChangeType.Rename });
        }

        protected override void Context()
        {
            var fileSync = new FakeFileSync();
            Gui = new TestInteractionContext();

            BackupRunner = new RunBackup(fileSync, Gui, null, null);

            var appliedChangeEventArgs = new MyAppliedChangeEventArgs();

            BackupRunner.OnAppliedChange(null, appliedChangeEventArgs);
        }
    }

    [TestFixture]
    public class When_a_file_is_updated : running_backups_context
    {
        private RunBackup BackupRunner;
        private TestInteractionContext Gui;

        [Test]
        public void It_should_alert_the_user_that_a_file_was_updated()
        {
            Gui.ChangeMade.ShouldEqual(ChangeType.Update);
        }

        protected override void Because()
        {
            BackupRunner.OnAppliedChange(null, new MyAppliedChangeEventArgs() { ChangeType = ChangeType.Update });
        }

        protected override void Context()
        {
            var fileSync = new FakeFileSync();
            Gui = new TestInteractionContext();

            BackupRunner = new RunBackup(fileSync, Gui, null, null);

            var appliedChangeEventArgs = new MyAppliedChangeEventArgs();

            BackupRunner.OnAppliedChange(null, appliedChangeEventArgs);
        }
    }

    [TestFixture]
    public class When_a_file_is_deleted : running_backups_context
    {
        private RunBackup BackupRunner;
        private TestInteractionContext Gui;

        [Test]
        public void It_should_alert_the_user_that_a_file_was_created()
        {
            Gui.ChangeMade.ShouldEqual(ChangeType.Delete);
        }

        protected override void Because()
        {
            BackupRunner.OnAppliedChange(null, new MyAppliedChangeEventArgs() { ChangeType = ChangeType.Delete });
        }

        protected override void Context()
        {
            var fileSync = new FakeFileSync();
            Gui = new TestInteractionContext();

            BackupRunner = new RunBackup(fileSync, Gui, null, null);

            var appliedChangeEventArgs = new MyAppliedChangeEventArgs();

            BackupRunner.OnAppliedChange(null, appliedChangeEventArgs);
        }
    }

    [TestFixture]
    public class When_a_file_is_created : running_backups_context
    {
        private RunBackup BackupRunner;
        private TestInteractionContext Gui;

        [Test]
        public void It_should_alert_the_user_that_a_file_was_created()
        {
            Gui.ChangeMade.ShouldEqual(ChangeType.Create);
        }

        protected override void Because()
        {
            BackupRunner.OnAppliedChange(null, new MyAppliedChangeEventArgs() { ChangeType = ChangeType.Create });
        }

        protected override void Context()
        {
            var fileSync = new FakeFileSync();
            Gui = new TestInteractionContext();

            BackupRunner = new RunBackup(fileSync, Gui, null, null);

            var appliedChangeEventArgs = new MyAppliedChangeEventArgs();
            
            BackupRunner.OnAppliedChange(null, appliedChangeEventArgs);
        }
    }

    public class TestInteractionContext : IInteractionContext
    {
        public ChangeType ChangeMade;

        public void AlertRenamed(MyAppliedChangeEventArgs args)
        {
            ChangeMade = args.ChangeType;
        }

        public void AlertUpdated(MyAppliedChangeEventArgs args)
        {
            ChangeMade = args.ChangeType;
        }

        public void AlertDeleted(MyAppliedChangeEventArgs args)
        {
            ChangeMade = args.ChangeType;
        }

        public void AlertCreated(MyAppliedChangeEventArgs args)
        {
            ChangeMade = args.ChangeType;
        }

        public void AlertSkipped(string changeType, string path, Exception exception)
        {
            throw new System.NotImplementedException();
        }
    }

    public class FakeFileSync : IFileSync
    {
        public void DetectChangesOnFileSystemReplica(SyncId replicaId, string replicaRootPath, FileSyncScopeFilter filter, FileSyncOptions options)
        {
            throw new System.NotImplementedException();
        }

        public event EventHandler<MyAppliedChangeEventArgs> AppliedChange;
        public event EventHandler<MySkippedChangeEventArgs> SkippedChange;
        public void SyncFolders(string sourceFolder, string targetFolder)
        {
            throw new System.NotImplementedException();
        }

        public void SyncFileSystemReplicasOneWay(SyncId sourceReplicaId, SyncId destinationReplicaId, string sourceReplicaRootPath, string destinationReplicaRootPath, FileSyncScopeFilter filter, FileSyncOptions options)
        {
            throw new System.NotImplementedException();
        }
    }

    public abstract class running_backups_context
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            Context();
            Because();
        }

        protected abstract void Because();

        protected abstract void Context();
    }

    
}
