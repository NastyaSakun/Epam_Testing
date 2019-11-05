using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebdriver.Tests
{
    public abstract class TestBase
    {
        public IWebDriver webDriver;

        [SetUp]
        public void OpenBrouserAndGoToTheTestSite()
        {
            webDriver = new ChromeDriver();
            //webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Navigate().GoToUrl("https://book.spicejet.com/");
            
        }

        [TearDown]
        public void CloseBrouser()
        {
            webDriver.Quit();
        }

        //protected IWebElement GetWebElementById(string Id)
        //{
        //    return webDriver.FindElement(By.CssSelector(Id));
        //}

        protected IWebElement GetWebElementByXPath(string xPath)
        {
            return webDriver.FindElement(By.XPath(xPath));
        }
    }
}
