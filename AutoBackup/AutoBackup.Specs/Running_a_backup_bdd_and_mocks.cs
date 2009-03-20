using System;
using AutoBackup.Model.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using SpecUnit;


namespace AutoBackup.Specs
{
    [TestFixture]
    public class When_running_a_backup_that_errors_out : backup_context
    {
        [Test]
        public void It_should_report_an_error()
        {
            BackupResult.ShouldEqual((int)Enumeration.ReturnCodes.BackupRunError);
        }

        [Test]
        public void It_should_save_the_error_to_settings_file()
        {
            // All the lambda notation really just makes things
            // look worse. It's a way to access the methods of
            // the object. I could say more but it probably 
            // wouldn't make any sense.
            // Nevermind the nulls being passed into the methods
            // those are just there as place holders so the compiler
            // won't complain.

            Settings.AssertWasCalled(
                settingsObject=>settingsObject.Save(null, null),
                // You need as many constraint parameters as your method has
                // parameters.
                x=>x.Constraints(Is.Anything(), Is.Anything())
            ); 
        }

        protected override void Because()
        {
            BackupResult = BackupRunner.ExecuteBackup(false);
        }

        protected override void Context()
        {
            // If there aren't directories we won't enter into the back up logic.
            BackupAccess.Stub(
                x => x.GetDirectoriesToBackup())
                .Return(new []{"directories"});

            // Notice how this stub doesn't need to be called for
            // explicitly since the mocking framework will auto
            // stub it out for us (it can since there's no return value)
            // BackupAccess.Stub(x => x.SetupBackupTarget());
            
            Settings.Stub(x => x.Save(null, null));

            // Make this method throw an error when it's called.
            BackupAccess.Stub(
                x => x.MakeNewDirectoryInBackupDirectory(null))
                .Constraints(Is.Anything())
                .Throw(new Exception());
        }
    }

    [TestFixture]
    public class When_running_a_backup_with_no_directories_to_backup : backup_context
    {

        /// <summary>
        /// Observation after the because...
        /// </summary>
        [Test]
        public void It_should_not_create_a_backup_folder()
        {
            BackupAccess
                .AssertWasNotCalled(
                    x=>x.MakeNewDirectoryInBackupDirectory("path"), 
                    x=>x.Constraints(Is.Anything()));
            FileSync
                .AssertWasNotCalled(
                    x => x.SyncFolders(null,null),
                    x => x.Constraints(Is.Anything(), Is.Anything()));
        }

        /// <summary>
        /// Observation after the because...
        /// </summary>
        [Test]
        public void It_should_report_successful_backup()
        {
            BackupResult.ShouldEqual((int)Enumeration.ReturnCodes.Success);
        }

        /// <summary>
        /// We initiate the changes to the state.
        /// </summary>
        protected override void Because()
        {
            BackupResult = BackupRunner.ExecuteBackup(false);
        }

        /// <summary>
        /// Context specific set up.
        /// </summary>
        protected override void Context()
        {
            // I have to stub this method explicitly because I need it to
            // return a certain value.
            BackupAccess.Stub(x => x.GetDirectoriesToBackup()).Return(null);
        }
    }

    public abstract class backup_context
    {
        protected IInteractionContext Interactions;
        protected IFileSync FileSync;
        protected IBackupAccess BackupAccess;
        protected RunBackup BackupRunner;
        protected int BackupResult;
        protected ISettingsProvider Settings;

        [TestFixtureSetUp]
        public void Setup()
        {
            //Here we're doing all of the set up for this clump of tests.

            // Mocks basically allow us to pretend like we have a class
            // when we really don't just so the program runs. This really
            // comes in handy when you have a large interface and don't want to 
            // create a huge real class that has to have a bunch of empty methods
            // that never get called.
            Interactions = MockRepository.GenerateStub<IInteractionContext>();
            FileSync = MockRepository.GenerateStub<IFileSync>();
            BackupAccess = MockRepository.GenerateStub<IBackupAccess>();
            Settings = MockRepository.GenerateStub<ISettingsProvider>();
            BackupRunner = new RunBackup(FileSync, Interactions, Settings, BackupAccess);

            Context();
            Because();
        }

        /// <summary>
        /// The context is where we set up the specific logic for each When_blah_blah test class.
        /// </summary>
        protected abstract void Context();
        /// <summary>
        /// The because is where we execute the method that will change the state of the
        /// object under test. Immediately after this executes we begin to test our
        /// observations.
        /// </summary>
        protected abstract void Because();
    }
}
