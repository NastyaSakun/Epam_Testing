using Framework_1.PageModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Framework_1.Pages
{
    public class FlightStatusPage
    {

        private const string cityFromXPath = "//*[@id='FlifoSearchInputSearchView_originStation']";

        private const string searchButtonXPath = "//*[@id='FlifoSearchInputSearchView_ButtonSubmit']";

        private const string errorMessageXPath = "//*[@id='FlifoSearchInputSearchView_originStation']";

        private const string errorMessageCityFromXPath = "//div[@id='FlifoSearchInputSearchView_destinationStation']";

        [FindsBy(How = How.XPath, Using = cityFromXPath)]
        private readonly IWebElement cityFrom;

        [FindsBy(How = How.XPath, Using = searchButtonXPath)]
        private readonly IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = errorMessageXPath)]
        private readonly IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = errorMessageCityFromXPath)]
        private readonly IWebElement errorMessageCityFrom;

        [Obsolete] //For PageFactory
        public FlightStatusPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public FlightStatusPage ClickSearchWithoutAllParameters()
        {
            searchButton.Click();
            return this;
        }

        public FlightStatusPage InputCityFromInFlightStatusPage(ModelFlightStatus user)
        {
            cityFrom .SendKeys(user.CitytFrom);
            return this;
        }

        public string GetErrorMessageInFlightStatusPage()
        {
            return errorMessage.Text;
        }

        public string GetErrorMessageInFlightStatusPageWithCityFrom()
        {
            return errorMessageCityFrom.Text;
        }
    }
}
