using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Framework_1
{
    public class MainPage
    {
        private const string searchButtonXPath = "//*[@id='ControlGroupSearchView_AvailabilitySearchInputSearchView_ButtonSubmit']";
        private const string errorMessageXPath = "//div[@id='view-origin-station']";
        private const string errorMessageNotExistCityXPath = "//div[@class='heading']";
        private const string errorMessageAloneCityXPath = "//div[@id='view-destination-station']";
        private const string checkInButtonXPath = "//* [@class = 'spiceFare']";
        private const string flightStatusXPath = "//*[@class='flight_status']";
        private const string helpXPath = "//* [@class='flight_status']";
        private const string cityFromXPath = "//*[@id='ControlGroupSearchView_AvailabilitySearchInputSearchVieworiginStation1_CTXT']";
        private const string cityToXPath = "//*[@id='ControlGroupSearchView_AvailabilitySearchInputSearchViewdestinationStation1_CTXT']";
        private const string bothCitiesMessageXPath = "//*[@id='hide-mobile float-left']";
        private const string giftCardsXPath = "//*[@id='header-vacations']/a";
        private const string logoXPath = "//div[@class='picejet_logo']";
        private const string checkLogoXPath = "//*[@id='ctl00_mainContent_ddl_originStation1_CTXT']";

        [FindsBy(How = How.XPath, Using = logoXPath)]
        private readonly IWebElement logo;

        [FindsBy(How = How.XPath, Using = checkLogoXPath)]
        private readonly IWebElement checkLogo;

        [FindsBy(How = How.XPath, Using = giftCardsXPath)]
        private readonly IWebElement giftCardsPage;

        [FindsBy(How = How.XPath, Using = searchButtonXPath)]
        private readonly IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = errorMessageXPath)]
        private readonly IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = checkInButtonXPath)]
        private readonly IWebElement checkInButton;

        [FindsBy(How = How.XPath, Using = helpXPath)]
        private readonly IWebElement helpButton;

        [FindsBy(How = How.XPath, Using = cityFromXPath)]
        private readonly IWebElement notExistCityBox;

        [FindsBy(How = How.XPath, Using = cityToXPath)]
        private readonly IWebElement bothCitiesBox;

        [FindsBy(How = How.XPath, Using = errorMessageNotExistCityXPath)]
        private readonly IWebElement notExistCityError;

        [FindsBy(How = How.XPath, Using = bothCitiesMessageXPath)]
        private readonly IWebElement bothCitiesMessage;

        [FindsBy(How = How.XPath, Using = errorMessageAloneCityXPath)]
        private readonly IWebElement aloneCityError;

        [FindsBy(How = How.XPath, Using = flightStatusXPath)]
        private readonly IWebElement flightStatusPage;

        [Obsolete] //For PageFactory
        public MainPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public MainPage ClickSearchButton()
        {
            searchButton.Click();
            return this;
        }

        public MainPage InputCity(ModelCheckInUser user)
        {
            notExistCityBox.SendKeys(user.NotExistCity);
            return this;
        }

        public MainPage InputBothCities(ModelCheckInUser user)
        {
            bothCitiesBox.SendKeys(user.AloneCity);
            bothCitiesBox.SendKeys(user.CityTo);
            return this;
        }

        public string GetErrorMessageInMainPage()
        {
            return errorMessage.Text;
        }

        public string GetMessageInBothCitiesBox()
        {
            return bothCitiesMessage.Text;
        }

        public string GetErrorMessageInAloneCityBox()
        {
            return aloneCityError.Text;
        }

        public string GetErrorMessageInNotExistCityBox()
        {
            return notExistCityError.Text;
        }

        public MainPage ClickCheckInButton(IWebDriver driver)
        {
            checkInButton.Click();
            Actions action = new Actions(driver);
            action.MoveToElement(helpButton);
            action.Perform();
            return this;
        }

        public MainPage ClickFlightStatus()
        {
            flightStatusPage.Click();
            return this;
        }

        public MainPage ClickGiftCardsPage()
        {
            giftCardsPage.Click();
            return this;
        }

        public MainPage ClickLogo()
        {
            logo.Click();
            return this;
        }

        public string CheckLogo()
        {
            return checkLogo.Text;
        }
    }
}
