using System;
using System.Configuration;
using Configuration = System.Configuration.Configuration;

namespace Framework_1
{
    public class CheckInUserConfig
    {
        static Configuration ConfigFile
        {
            get
            {
                string file = "dev";
                int index = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
                var configeMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory.Substring(0, index) +
                    $@"{file}.config"
                };
                return ConfigurationManager.OpenMappedExeConfiguration(configeMap, ConfigurationUserLevel.None);
            }
        }

        public static string GetData(string key)
        {
            return ConfigFile.AppSettings.Settings[key]?.Value;
        }
    }
}
