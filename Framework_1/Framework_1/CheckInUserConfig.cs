using AngleSharp;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Configuration;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Configuration = System.Configuration.Configuration;

namespace Framework_1
{
    class CheckInUserConfig
    {
        static Configuration ConfigFile
        {
            get
            {
                var variableFromConsole = TestContext.Parameters.Get("env");
                string file = string.IsNullOrEmpty(variableFromConsole) ? "dev" : variableFromConsole;
                int index = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
                var configeMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory.Substring(0, index) +
                    @"ConfigFiles\" + file + ".config"
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
