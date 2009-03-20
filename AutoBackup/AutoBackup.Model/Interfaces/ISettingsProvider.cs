namespace AutoBackup.Model.Interfaces
{
    /// <summary>
    /// This interface allows us to have some clean unit tests
    /// and it also enables us to change how we store and get
    /// settings in the future. The application no longer cares
    /// if this is a settings file or a web service as long as
    /// we support this interface.
    /// </summary>
    public interface ISettingsProvider
    {
        object Get(string key);
        void Save(string key, object value);
    }
}