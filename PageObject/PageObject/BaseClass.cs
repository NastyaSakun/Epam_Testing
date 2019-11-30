using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObject
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
