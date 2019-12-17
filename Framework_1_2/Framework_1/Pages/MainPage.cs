using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Framework_1
{
    public class MainPage
    {
        private const string searchButtonXPath = "//input[@id='ControlGroupSearchView_AvailabilitySearchInputSearchView_ButtonSubmit']";
        private const string errorMessageXPath = "//div[@id='view-origin-station']";
        private const string errorMessageNotExistCityXPath = "//div[@class='heading']";
        private const string checkInButtonXPath = "//a[@class = 'spiceFare']";
        private const string flightStatusXPath = "//span[@class='flight_status']";
        private const string helpXPath = "//span[@class='flight_status']";
        private const string cityFromXPath = "//input[@id='ControlGroupSearchView_AvailabilitySearchInputSearchVieworiginStation1_CTXT']";
        private const string cityToXPath = "//input[@id='ControlGroupSearchView_AvailabilitySearchInputSearchViewdestinationStation1_CTXT']";
        private const string bothCitiesMessageXPath = "//div[@id='hide-mobile float-left']";
        private const string giftCardsXPath = "//span[@id='header-vacations']/a";
        private const string buttonForCalendarXPath= "//input[@class=' ui-datepicker-week-end ui-datepicker-unselectable ui-state-disabled']";
        private const string dateXPath = "//input[@class='ui-state-default']";
        private const string logXPath = "//input[@id='Login']";
        private const string peopleBoxXPath = "//div[@id='divpaxinfo']";
        private const string infantXPat = "//select[@id='ControlGroupSearchView_AvailabilitySearchInputSearchView_DropDownListPassengerType_INFANT']";
        private const string messageInfantXPath = "//div[@class='wMed1s required guests']";

        [FindsBy(How = How.XPath, Using = peopleBoxXPath)]
        private readonly IWebElement people;

        [FindsBy(How = How.XPath, Using = messageInfantXPath)]
        private readonly IWebElement messageInfant;

        [FindsBy(How = How.XPath, Using = infantXPat)]
        private readonly IWebElement infant;

        [FindsBy(How = How.XPath, Using = logXPath)]
        private readonly IWebElement logPage;

        [FindsBy(How = How.XPath, Using = buttonForCalendarXPath)]
        private readonly IWebElement buttonForCalendar;

        [FindsBy(How = How.XPath, Using = dateXPath)]
        private readonly IWebElement date;

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

        [FindsBy(How = How.XPath, Using = flightStatusXPath)]
        private readonly IWebElement flightStatusPage;

        [Obsolete] //For PageFactory
        public MainPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public MainPage SetInfant()
        {
            people.Click();
            infant.SendKeys("4");
            return this;
        }

        public string GetInfantMessage()
        {
            return messageInfant.Text;
        }

        public bool GetDate()
        {
            buttonForCalendar.Click();
            return date.ToString().Contains("dis");
        }

        public MainPage GoToLogPage()
        {
            logPage.Click();
            return this;
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

    }
}
