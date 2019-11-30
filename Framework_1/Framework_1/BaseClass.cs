using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework_1
{
    public class BaseClass
    {
        public IWebDriver webDriver;

        [SetUp]
        public void OpenGoogleChrome()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(@"https://book.spicejet.com/");
        }

        [TearDown]
        public void CloseGoogleChrome()
        {
            webDriver.Quit();
            webDriver.Dispose();
        }
    }
}
