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
        public void SearchWithWrongReservationNumber()
        {
            var findButton = GetWebElementByXPath("//input[@class='bookbtn at-element-click-tracking']");
            findButton.Click();

            var errorMessage = GetWebElementByXPath("//div[@id='view-origin-station']");
            string error = errorMessage.Text;
            Assert.AreEqual("Select Departure City", error);
        }

        [Test]
        public void Calendar()
        {

            var checkIn = GetWebElementByXPath("//* [@class = 'spiceFare']");
            checkIn.Click();

            var ticketNumber = GetWebElementByXPath("//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_ConfirmationNumber']");
            ticketNumber.SendKeys("P52FKC");

            var surname = GetWebElementByXPath("//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_CONTACTEMAIL1']");
            surname.SendKeys("Sakun");

            var search = GetWebElementByXPath("//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_ButtonRetrieve']");
            search.Click();

            var errorMessage = GetWebElementByXPath("//div[@id='errorSectionContent']");
            string error = errorMessage.Text;
            Assert.IsNotNull(error);
        }


    }
}