using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebdriver.Tests
{
    [TestFixture]
    public class Tests : TestBase
    {
        private const string errorInSearchWithoutPrivateInformation = "Select Departure City";
        private const string errorInWorkWithCheckIn = "The information submitted does not match any itinerary. Please verify the information is correct and try again.";

        [Test]
        public void SearchWithoutPrivateInformation()
        {
            var findButton = GetWebElementByXPath("//input[@class='bookbtn at-element-click-tracking']");
            findButton.Click();

            var errorMessage = GetWebElementByXPath("//div[@id='view-origin-station']");
            string error = errorMessage.Text;
            Assert.AreEqual(errorInSearchWithoutPrivateInformation, error);
        }

        DefaultWait<IWebDriver> fWait;

        [Test]
        public void WorkWithCheckIn()
        {
            fWait = WaitCheckIn.GetWaitCheckIn(this.webDriver);
            
            var checkIn = GetWebElementByXPath("//* [@class = 'spiceFare']");
            checkIn.Click();

            var ticketNumber = GetWebElementByXPath("//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_ConfirmationNumber']");
            ticketNumber.SendKeys("P52FKC");

            var surname = GetWebElementByXPath("//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_CONTACTEMAIL1']");
            surname.SendKeys("Sakun");

            var search = fWait.Until(x => x.FindElement(By.XPath("//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_ButtonRetrieve']"))); // GetWebElementByXPath("//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_ButtonRetrieve']"));
            search.Click();

            var errorMessage = GetWebElementByXPath("//div[@id='errorSectionContent']");
            string error = errorMessage.Text;
            Assert.AreEqual(errorInWorkWithCheckIn, error);
        }


    }
}
