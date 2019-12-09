﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;

namespace Framework_1
{
    public class BaseClass
    {
        public IWebDriver webDriver;

        [SetUp]
        public void OpenGoogleChrome()
        {
            webDriver = Driver.GetDriver();
            webDriver.Navigate().GoToUrl(@"https://book.spicejet.com/");
        }

        public void MakeScreenshotWhenFail(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\Screens";
                Directory.CreateDirectory(screenFolder);
                var screen = webDriver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\" + DateTime.Now.ToString("dd-MM-yy_hh-mm-ss") + ".png", ScreenshotImageFormat.Png);
                throw;
            }
        }

        [TearDown]
        public void CloseGoogleChrome()
        {
            Driver.CloseBrowser();
        }
    }
}
