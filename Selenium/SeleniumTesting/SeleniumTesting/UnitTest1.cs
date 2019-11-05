using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;


namespace SeleniumTesting
{

    [TestClass]
    public class UnitTest1: BrouserBaseFunction
    {      

        [TestMethod]
        public void SearchWithoutEnteringTheCityOfArrival()
        {
            #region TestData

            #endregion

            //var departureCity = GetWebElementById("reservationFlightSearchForm.originAirport");
            //departureCity.SendKeys(departureCityText); 
            var searchButton = GetWebElementByXPath("//BUTTON[@type='submit'][@class='BpkButton_bpk-button__3V91- BpkButton_bpk-button--large__2bgJa App_submit-button__3OawW App_submit-button-oneline__23Etl']"); ;
            searchButton.Click();
            var errorMessage = GetWebElementByXPath("//[@class = 'BpkInput_bpk-input__3iutT SingleDestControls_fsc-large-above-tablet__1WC8y SingleDestControls_fsc-docked-middle-above-tablet___J8b1 SingleDestControls_fsc-docked-last-on-tablet__uU4v_ LocationSelector_fsc-location-input__2eRlW']");
            string error = errorMessage.Text;
            NUnit.Framework.Assert.AreEqual("Везде", error);
        }
    }

    public abstract class BrouserBaseFunction
    {
        public IWebDriver chrome= new ChromeDriver();

        [SetUp]
        public void OpenChrome()
        {
            chrome = new ChromeDriver();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            chrome.Manage().Window.Maximize();
            chrome.Navigate().GoToUrl("https://www.skyscanner.net/");
        }

        [TearDown]
        public void CloseChrome()
        {
            chrome.Quit();
        }

        protected IWebElement GetWebElementById(string Id)
        {
            return chrome.FindElement(By.Id(Id));
        }
        protected IWebElement GetWebElementByXPath(string xPath)
        {
            return chrome.FindElement(By.XPath(xPath));
        }
    }

}
