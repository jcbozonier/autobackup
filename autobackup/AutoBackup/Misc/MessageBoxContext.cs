using System;
using System.Windows.Forms;
using AutoBackup.Model;
using AutoBackup.Model.Interfaces;
using Microsoft.Synchronization.Files;

namespace AutoBackup.Misc
{
    public class MessageBoxContext : IInteractionContext
    {
        public void AlertRenamed(MyAppliedChangeEventArgs args)
        {
            MessageBox.Show("-- Applied RENAME for file " + args.OldFilePath +
                            " as " + args.NewFilePath);
        }

        public void AlertUpdated(MyAppliedChangeEventArgs args)
        {
            MessageBox.Show("-- Applied UPDATE for file " + args.OldFilePath);
        }

        public void AlertDeleted(MyAppliedChangeEventArgs args)
        {
            MessageBox.Show("-- Applied DELETE for file " + args.OldFilePath);
        }

        public void AlertCreated(MyAppliedChangeEventArgs args)
        {
            MessageBox.Show("-- Applied CREATE for file " + args.NewFilePath);
        }

        public void AlertSkipped(string changeType, string path, Exception exception)
        {
            var message = String.Format("-- Skipped applying {0} for {1} due to error.", changeType, path);
            MessageBox.Show(message + "   [" + ((exception != null) ? exception.Message : String.Empty) + "]");
        }
    }
}
