using Framework_1.PageCreators;
using Framework_1.Pages;
using NUnit.Framework;
using System;
namespace Framework_1
{
    [Obsolete]
    public class Tests:BaseClass
    {
        const string errorInBookingWithoutAllParameters = "Select Departure City";
        const string errorInWorkWithCheckIn = "The information submitted does not match any itinerary. Please verify the information is correct and try again.";
        const string errorInBookingWithNotExistCity = "No city matches your search.";
        const string errorInBookingWithAloneCity = "Select Arrival City";
        const string bothCitiesMessage = "Kindly fill your GST / UIN details";
        const string errorInFlightStatusWithoutParameters = "Departure City";
        const string errorInFlightStatusWithCityFrom = "Arrival City";
        const string errorBalance = "*Please enter a valid card number.";
        const string helpMessage = "Departure City";

        readonly CheckInUserCreator currentUser = new CheckInUserCreator();
        readonly FlightStatusCreator currentStatus = new FlightStatusCreator();

        [Test]
        public void BookingWithoutAllParameters()
        {
            MakeScreenshotWhenFail(()=>
            {
                new MainPage(webDriver).ClickSearchButton();
                MainPage error = new MainPage(webDriver);

                Assert.AreEqual(errorInBookingWithoutAllParameters, error.GetErrorMessageInMainPage());
            });
        }

        [Test]
        public void BookingWithNotExistCity()
        {
            MakeScreenshotWhenFail(() =>
            {
                MainPage inputCity=new MainPage(webDriver).InputCity(currentUser.DataForBookingWithNotExistCity());
                inputCity.ClickSearchButton();

                MainPage error = new MainPage(webDriver);

                Assert.AreEqual(errorInBookingWithNotExistCity, error.GetErrorMessageInNotExistCityBox());
            });
        }

        [Test]
        public void BookingWithRightParameters()
        {
            MakeScreenshotWhenFail(() =>
            {
                MainPage inputCity = new MainPage(webDriver).InputCity(currentUser.DataForBookingWithBothCities());
                inputCity.ClickSearchButton();

                MainPage message = new MainPage(webDriver);

                Assert.AreEqual(bothCitiesMessage, message.GetMessageInBothCitiesBox());
            });
        }

        [Test]
        public void BookingWithAloneCity()
        {
            MakeScreenshotWhenFail(() =>
            {
                MainPage inputCity = new MainPage(webDriver).InputCity(currentUser.DataForBookingWithAloneCity());
                inputCity.ClickSearchButton();

                MainPage error = new MainPage(webDriver);

                Assert.AreEqual(errorInBookingWithAloneCity, error.GetErrorMessageInAloneCityBox());
            });
        }

        [Test]
        public void WorkWithCheckIn()
        {
            MakeScreenshotWhenFail(() =>
            {
                new MainPage(webDriver).ClickCheckInButton(webDriver);                

                CheckInPage checkIn = new CheckInPage(webDriver).InputPrivateInformationInCheckInPage(currentUser.DataForCheckIn());
                checkIn.PressSearchButton();

                CheckInPage error = new CheckInPage(webDriver);

                Assert.AreEqual(errorInWorkWithCheckIn, error.GetErrorMessageInCheckInPage());
            });
        }

        [Test]
        public void WorkWithFlightStatusWithoutAllParameters()
        {
            MakeScreenshotWhenFail(() =>
            {
                new MainPage(webDriver).ClickFlightStatus();
                new FlightStatusPage(webDriver).ClickSearchWithoutAllParameters();

                FlightStatusPage error = new FlightStatusPage(webDriver);

                Assert.AreEqual(errorInFlightStatusWithoutParameters, error.GetErrorMessageInFlightStatusPage());
            });
        }

        [Test]
        public void FlightStatusWithAloneCity()
        {
            MakeScreenshotWhenFail(() =>
            {
                MainPage inputCity = new MainPage(webDriver).InputCity(currentUser.DataForBookingWithAloneCity());
                inputCity.ClickSearchButton();

                FlightStatusPage flightStatusPage = new FlightStatusPage(webDriver).InputCityFromInFlightStatusPage(currentStatus.DataForFlighStatus());
                flightStatusPage.ClickSearchWithoutAllParameters();

                FlightStatusPage error = new FlightStatusPage(webDriver);

                Assert.AreEqual(errorInFlightStatusWithCityFrom, error.GetErrorMessageInFlightStatusPageWithCityFrom());
            });
        }

        [Test]
        public void GiftCardsWithoutParameters()
        {
            MakeScreenshotWhenFail(() =>
            {
                new MainPage(webDriver).ClickGiftCardsPage();

                new GiftCardsPage(webDriver).CheckBalance();

                GiftCardsPage error = new GiftCardsPage(webDriver);

                Assert.AreEqual(errorBalance, error.GetErrorBalance());
            });
        }

        [Test]
        public void CheckLogo()
        {
            MakeScreenshotWhenFail(() =>
            {
                new MainPage(webDriver).ClickLogo();

                MainPage checking = new MainPage(webDriver);

                Assert.AreEqual(helpMessage, checking.CheckLogo());
            });
        }
    }
}
