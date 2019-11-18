using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace PageObject
{
    class MainPage
    {
        private const string searchButtonXPath = "//input[@class='bookbtn at-element-click-tracking']";
        private const string errorMessageXPath = "//div[@id='view-origin-station']";
        private const string checkInButtonXPath = "//* [@class = 'spiceFare']";

        [FindsBy(How = How.XPath, Using = searchButtonXPath)]
        private readonly IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = errorMessageXPath)]
        private readonly IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = checkInButtonXPath)]
        private readonly IWebElement checkInButton;

        public MainPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public MainPage ClickSearchButton()
        {
            searchButton.Click();
            return this;
        }

        public bool GetErrorMessage()
        {
            return (errorMessage.Text != null);
        }

        public MainPage ClickCheckInButton()
        {
            checkInButton.Click();
            return this;
        }
    }
}
