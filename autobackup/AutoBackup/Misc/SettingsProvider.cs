using AutoBackup.Model.Interfaces;
using AutoBackup.Properties;

namespace AutoBackup.Misc
{
    internal class SettingsProvider : ISettingsProvider
    {
        private readonly Settings _Settings;

        public SettingsProvider(Settings settings)
        {
            _Settings = settings;
        }

        public object Get(string key)
        {
            return _Settings[key].ToString();
        }

        public void Save(string key, object value)
        {
            _Settings[key] = value;
        }
    }
}
