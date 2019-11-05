using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumWebdriver.Tests
{
    [TestFixture]
    public class Tests : TestBase
    {
        [Test]
        public void SearchWithEmptyBoxes()
        {
            var findButton = GetWebElementByXPath("//input[@class='bookbtn at-element-click-tracking']");
            findButton.Click();

            var errorMessage = GetWebElementByXPath("//div[@id='view-origin-station']");
            string error = errorMessage.Text;
            Assert.AreEqual("Select Departure City", error);
        }

        [Test]
        public void WorkWithCheckIn()
        {

            var checkInButton = GetWebElementByXPath("//* [@class = 'spiceFare']");
            checkInButton.Click();

            var ticketNumberBox = GetWebElementByXPath("//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_ConfirmationNumber']");
            ticketNumberBox.SendKeys("P52FKC");

            var surnameBox = GetWebElementByXPath("//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_CONTACTEMAIL1']");
            surnameBox.SendKeys("Sakun");

            var searchButton = GetWebElementByXPath("//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_ButtonRetrieve']");
            searchButton.Click();

            var errorMessage = GetWebElementByXPath("//div[@id='errorSectionContent']");
            string error = errorMessage.Text;
            Assert.IsNotNull(error);
        }


    }
}
