using System;
using AutoBackup.Model;
using AutoBackup.Model.Interfaces;
using Microsoft.Synchronization.Files;

namespace AutoBackup.Misc
{
    public class CommandLineContext : IInteractionContext
    {
        public void AlertRenamed(MyAppliedChangeEventArgs args)
        {
            Console.WriteLine("-- Applied RENAME for file " + args.OldFilePath +
                              " as " + args.NewFilePath);
        }

        public void AlertUpdated(MyAppliedChangeEventArgs args)
        {
            Console.WriteLine("-- Applied UPDATE for file " + args.OldFilePath);
        }

        public void AlertDeleted(MyAppliedChangeEventArgs args)
        {
            Console.WriteLine("-- Applied DELETE for file " + args.OldFilePath);
        }

        public void AlertCreated(MyAppliedChangeEventArgs args)
        {
            Console.WriteLine("-- Applied CREATE for file " + args.NewFilePath);
        }

        public void AlertSkipped(string changeType, string path, Exception exception)
        {
            var message = String.Format("-- Skipped applying {0} for {1} due to error.", changeType, path);
            Console.WriteLine(message);

            if (exception != null)
                Console.WriteLine("   [" + exception.Message + "]");
        }
    }
}
