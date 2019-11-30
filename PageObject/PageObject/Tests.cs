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

        private const string ticketNumberValue = "P52FKC";
        private const string surnameValue = "Sakun";

        const string errorInBookingWithoutAllParameters = "Select Departure City";
        const string errorInWorkWithCheckIn = "The information submitted does not match any itinerary. Please verify the information is correct and try again.";

        [SetUp]
        public void OpenGoogleChrome()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(@"https://book.spicejet.com/");
        }

        [Test]
        public void BookingWithoutAllParameters()
        {            
            MainPage mainPage = new MainPage(webDriver).ClickSearchButton();
            MainPage error = new MainPage(webDriver);

            NUnit.Framework.Assert.AreEqual(errorInBookingWithoutAllParameters, error.GetErrorMessageInMainPage());
        }

        [Test]
        public void WorkWithCheckIn()
        {
            MainPage mainPage = new MainPage(webDriver).ClickCheckInButton();

            CheckInPage checkIn = new CheckInPage(webDriver).InputPrivateInformationInCheckInPage(ticketNumberValue, surnameValue);
            checkIn.PressSearchButton();

            CheckInPage error = new CheckInPage(webDriver);

            NUnit.Framework.Assert.AreEqual(errorInWorkWithCheckIn, error.GetErrorMessageInCheckInPage());
        }

        [TearDown]
        public void CloseGoogleChrome()
        {
            webDriver.Quit();
            webDriver.Dispose();
        }
    }
}
