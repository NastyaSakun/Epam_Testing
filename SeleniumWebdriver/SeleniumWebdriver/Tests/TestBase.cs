using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebdriver.Tests
{
    public abstract class TestBase
    {
        public IWebDriver webDriver;

        [SetUp]
        public void OpenBrowserAndGoToTheTestSite()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Navigate().GoToUrl("https://book.spicejet.com/");
            
        }

        [TearDown]
        public void CloseBrowser()
        {
            webDriver.Quit();
        }

        protected IWebElement GetWebElementByXPath(string xPath)
        {
            return webDriver.FindElement(By.XPath(xPath));
        }
    }
}
