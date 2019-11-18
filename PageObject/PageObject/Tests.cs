using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver webDriver;

        [Test]
        [Obsolete]
        public void BookingWithoutAllParameters()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(@"https://book.spicejet.com/");
            MainPage mainPage = new MainPage(webDriver).ClickSearchButton();
            MainPage error = new MainPage(webDriver);

            NUnit.Framework.Assert.IsTrue(error.GetErrorMessage());

            webDriver.Quit();
        }

        [Test]
        [Obsolete]
        public void WorkWithCheckIn()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(@"https://book.spicejet.com/");
            MainPage mainPage = new MainPage(webDriver).ClickCheckInButton();

            CheckInPage checkIn = new CheckInPage(webDriver).InputPrivateInformationInCheckInPage();
            checkIn.PressSearchButton();

            NUnit.Framework.Assert.IsTrue(checkIn.GetErrorMessage());

            webDriver.Quit();
        }
    }
}
