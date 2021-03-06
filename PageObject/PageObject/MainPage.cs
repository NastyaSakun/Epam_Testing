﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace PageObject
{
    public class MainPage
    {
        private const string searchButtonXPath = "//*[@id='ControlGroupSearchView_AvailabilitySearchInputSearchView_ButtonSubmit']";
        private const string errorMessageXPath = "//div[@id='view-origin-station']";
        private const string checkInButtonXPath = "//* [@class = 'spiceFare']";

        [FindsBy(How = How.XPath, Using = searchButtonXPath)]
        private readonly IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = errorMessageXPath)]
        private readonly IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = checkInButtonXPath)]
        private readonly IWebElement checkInButton;

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

        public string GetErrorMessageInMainPage()
        {
            return errorMessage.Text;
        }

        public MainPage ClickCheckInButton()
        {
            checkInButton.Click();
            return this;
        }
    }
}
