using AutoBackup.Misc;
using AutoBackup.Model;
using AutoBackup.Model.Interfaces;
using StructureMap;

namespace AutoBackup
{
    /// <summary>
    /// This is currently initialized in the Program.cs file in the 
    /// Main method. This is called an IoC Container (Inversion of Control container). 
    /// Here's a good source on reasoning for using this pattern:
    /// http://www.objectmentor.com/resources/articles/dip.pdf
    /// </summary>
    public static class DependencyLoader
    {
        public static void BootstrapStructureMap()
        {
            // Since this object doesn't hold any state it's fine to give
            // every object the same instance of this.
            var settings = new SettingsProvider(Properties.Settings.Default);

            // Initialize the static ObjectFactory container
            ObjectFactory.Initialize(x =>
            {
                // Here I've set it up so that you can choose how you want the application
                // to communicate to the user. Either with message boxes or via shell messages.
                // Just swap which line you comment to have the system use the other implmentation
                // of interacting.

                // x.ForRequestedType<IInteractionContext>().TheDefaultIsConcreteType<MessageBoxContext>();
                x.ForRequestedType<IInteractionContext>().TheDefaultIsConcreteType<CommandLineContext>();

                x.ForRequestedType<IFileSync>().TheDefaultIsConcreteType<FileSync>();
                x.ForRequestedType<ISettingsProvider>().TheDefault.IsThis(settings);
                x.ForRequestedType<IBackupAccess>().TheDefaultIsConcreteType<BackupDirectories>();
                x.ForRequestedType<IDirectoryAdapter>().TheDefaultIsConcreteType<DirectoryAdapter>();
            });
        }
    }
}
