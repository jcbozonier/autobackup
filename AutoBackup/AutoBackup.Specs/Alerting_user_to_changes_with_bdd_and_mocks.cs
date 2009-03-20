using System;
using AutoBackup.Model;
using AutoBackup.Model.Interfaces;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using SpecUnit;

namespace AutoBackup.MockedSpecs
{
    [TestFixture]
    public class When_a_file_is_renamed : running_backups_context
    {
        private RunBackup BackupRunner;

        [Test]
        public void It_should_alert_the_user_that_a_file_was_renamed()
        {
            Interactions.AssertWasCalled(
                x => x.AlertRenamed(null),
                x => x.Constraints(Is.Anything()));
        }

        protected override void Because()
        {
            BackupRunner.OnAppliedChange(
                null,
                new MyAppliedChangeEventArgs() { ChangeType = ChangeType.Rename });
        }

        protected override void Context()
        {
            Interactions.Stub(x => x.AlertRenamed(null)).Constraints(Is.Anything());
            BackupRunner = new RunBackup(FileSync, Interactions, null, null);
        }
    }

    [TestFixture]
    public class When_a_file_is_updated : running_backups_context
    {
        private RunBackup BackupRunner;

        [Test]
        public void It_should_alert_the_user_that_a_file_was_updated()
        {
            Interactions.AssertWasCalled(
                x => x.AlertUpdated(null),
                x => x.Constraints(Is.Anything()));
        }

        protected override void Because()
        {
            BackupRunner.OnAppliedChange(
                null,
                new MyAppliedChangeEventArgs() { ChangeType = ChangeType.Update });
        }

        protected override void Context()
        {
            Interactions.Stub(x => x.AlertUpdated(null)).Constraints(Is.Anything());
            BackupRunner = new RunBackup(FileSync, Interactions, null, null);
        }
    }

    [TestFixture]
    public class When_a_file_is_deleted : running_backups_context
    {
        private RunBackup BackupRunner;

        [Test]
        public void It_should_alert_the_user_that_a_file_was_deleted()
        {
            Interactions.AssertWasCalled(
                x => x.AlertDeleted(null),
                x => x.Constraints(Is.Anything()));
        }

        protected override void Because()
        {
            BackupRunner.OnAppliedChange(
                null,
                new MyAppliedChangeEventArgs() { ChangeType = ChangeType.Delete });
        }

        protected override void Context()
        {
            Interactions.Stub(x => x.AlertDeleted(null)).Constraints(Is.Anything());
            BackupRunner = new RunBackup(FileSync, Interactions, null, null);
        }
    }

    [TestFixture]
    public class When_a_file_is_created : running_backups_context
    {
        private RunBackup BackupRunner;

        [Test]
        public void It_should_alert_the_user_that_a_file_was_created()
        {
            Interactions.AssertWasCalled(
                x=>x.AlertCreated(null), 
                x=>x.Constraints(Is.Anything()));
        }

        protected override void Because()
        {
            BackupRunner.OnAppliedChange(
                null, 
                new MyAppliedChangeEventArgs(){ChangeType = ChangeType.Create});
        }

        protected override void Context()
        {
            Interactions.Stub(x => x.AlertCreated(null)).Constraints(Is.Anything());
            BackupRunner = new RunBackup(FileSync, Interactions, null, null);
        }
    }

    public abstract class running_backups_context
    {
        protected IInteractionContext Interactions;
        protected IFileSync FileSync;

        [TestFixtureSetUp]
        public void Setup()
        {
            Interactions = MockRepository.GenerateStub<IInteractionContext>();
            FileSync = MockRepository.GenerateStub<IFileSync>();

            Context();
            Because();
        }

        protected abstract void Because();

        protected abstract void Context();
    }
}
