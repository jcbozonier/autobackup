using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Synchronization.Files;

namespace AutoBackup.Model
{
    public class MyAppliedChangeEventArgs : EventArgs
    {
        public MyAppliedChangeEventArgs()
        {

        }

        public ChangeType ChangeType;
        public string OldFilePath;
        public string NewFilePath;
    }

    public class MySkippedChangeEventArgs : EventArgs
    {
        public MySkippedChangeEventArgs()
        {

        }

        public ChangeType ChangeType;
        public string CurrentFilePath;
        public string NewFilePath;
        public Exception Exception;
    }
}
