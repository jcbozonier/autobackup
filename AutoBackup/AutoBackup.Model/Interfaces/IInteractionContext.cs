using System;
using Microsoft.Synchronization.Files;

namespace AutoBackup.Model.Interfaces
{
    /// <summary>
    /// This is a very strong separation of UI from code logic.
    /// With this interface in place you can drop in a whole new UI 
    /// by just reimplementing the interface in another way.
    /// </summary>
    public interface IInteractionContext
    {
        void AlertRenamed(MyAppliedChangeEventArgs args);
        void AlertUpdated(MyAppliedChangeEventArgs args);
        void AlertDeleted(MyAppliedChangeEventArgs args);
        void AlertCreated(MyAppliedChangeEventArgs args);
        void AlertSkipped(string changeType, string path, Exception exception);
    }
}