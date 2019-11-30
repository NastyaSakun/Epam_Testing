using NUnit.Framework;
using System;

namespace Framework_1
{
    [Obsolete]
    public class Tests:BaseClass
    {
        private const string ticketNumberValue = "P52FKC";
        private const string surnameValue = "Sakun";

        const string errorInBookingWithoutAllParameters = "Select Departure City";
        const string errorInWorkWithCheckIn = "The information submitted does not match any itinerary. Please verify the information is correct and try again.";

        

        [Test]
        public void BookingWithoutAllParameters()
        {
            new MainPage(webDriver).ClickSearchButton();
            MainPage error = new MainPage(webDriver);

            Assert.AreEqual(errorInBookingWithoutAllParameters, error.GetErrorMessageInMainPage());
        }

        [Test]
        public void WorkWithCheckIn()
        {
            new MainPage(webDriver).ClickCheckInButton();

            CheckInPage checkIn = new CheckInPage(webDriver).InputPrivateInformationInCheckInPage(ticketNumberValue, surnameValue);
            checkIn.PressSearchButton();

            CheckInPage error = new CheckInPage(webDriver);

            Assert.AreEqual(errorInWorkWithCheckIn, error.GetErrorMessageInCheckInPage());
        }
    }
}
