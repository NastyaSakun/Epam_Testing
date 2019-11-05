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

            #region TestData

            #endregion

            var findButton = GetWebElementByXPath("//input[@class='bookbtn at-element-click-tracking']");
            findButton.Click();

            var errorMessage = GetWebElementByXPath("//div[@id='view-origin-station']");
            string error = errorMessage.Text;
            Assert.AreEqual("Select Departure City", error);
        }

        [Test]
        public void Calendar()
        {

            #region TestData

            #endregion

            var checkIn = GetWebElementByXPath("//* [@class = 'spiceFare']");
            checkIn.Click();

            var ticketNumber = GetWebElementByXPath("//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_ConfirmationNumber']");
            ticketNumber.SendKeys("111");

            var surname = GetWebElementByXPath("//*[@id='BookingRetrieveInputSearch1WebCheckinSearchView_CONTACTEMAIL1']");
            surname.SendKeys("111");


            var search = GetWebElementByXPath("//*[@id='ControlGroupSearchView_AvailabilitySearchInputSearchView_ButtonSubmit']");
            search.Click();

            var beginCheck = GetWebElementByXPath("//*[@input='CONTROLGROUPSEARCHWEBCHECKINVIEW$BookingRetrieveInputSearch1WebCheckinView$ButtonRetrieve']");
            beginCheck.Click();

            var errorMessage = GetWebElementByXPath("//div[@id='errorSectionContent']");
            string error = errorMessage.Text;
            Assert.IsNotNull(error);
        }


    }
}