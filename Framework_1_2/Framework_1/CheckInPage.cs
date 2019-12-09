using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Framework_1
{
    public class CheckInPage
    {
        private const string ticketNumberXPath = "//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_ConfirmationNumber']";

        private const string surnameXPath = "//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_CONTACTEMAIL1']";        

        private const string searchButtonXPath = "//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_ButtonRetrieve']";

        private const string errorMessageXPath = "//div[@id='errorSectionContent']";

        [FindsBy(How = How.XPath, Using = ticketNumberXPath)]
        private readonly IWebElement ticketNumber;

        [FindsBy(How = How.XPath, Using = surnameXPath)]
        private readonly IWebElement surname;

        [FindsBy(How = How.XPath, Using = searchButtonXPath)]
        private readonly IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = errorMessageXPath)]
        private readonly IWebElement errorMessage;

        [Obsolete] //For PageFactory
        public CheckInPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public CheckInPage InputPrivateInformationInCheckInPage(ModelCheckInUser user)
        {
            ticketNumber.SendKeys(user.TicketNumber);
            surname.SendKeys(user.Surname);
            return this;
        }

        public CheckInPage PressSearchButton()
        {
            searchButton.Click();
            return this;
        }

        public string GetErrorMessageInCheckInPage()
        {
            return errorMessage.Text;
        }
    }
}
