using Framework_1.PageCreators;
using Framework_1.Pages;
using NUnit.Framework;
using System;
namespace Framework_1
{
    [Obsolete]
    public class Tests:TestConfig
    {
        const string errorInBookingWithoutAllParameters = "Select Departure City";
        const string errorInWorkWithCheckIn = "The information submitted does not match any itinerary. Please verify the information is correct and try again.";
        const string errorInBookingWithNotExistCity = "No city matches your search.";
        const string bothCitiesMessage = "Kindly fill your GST / UIN details";
        const string errorInFlightStatusWithoutParameters = "Departure City";
        const string errorInFlightStatusWithCityFrom = "Arrival City";
        const string errorBalance = "*Please enter a valid card number.";
        const string messageSignUp = "Enter one time password (OTP)";
        const string messageInfant= "If you wish to book a greater number of Infants than Adults, please contact our reservation center for possible arrangements";

        readonly CheckInUserCreator currentUser = new CheckInUserCreator();
        readonly FlightStatusCreator currentStatus = new FlightStatusCreator();
        readonly SignUpCreator registrationUser = new SignUpCreator();

        [Test]
        //1 +
        public void BookingWithoutAllParameters()
        {
            MakeScreenshotWhenFail(()=>
            {
                new MainPage(webDriver).ClickSearchButton();
                MainPage mainPage = new MainPage(webDriver);
                Assert.AreEqual(errorInBookingWithoutAllParameters, mainPage.GetErrorMessageInMainPage());
            });
        }

        [Test]
        //2 +
        public void BookingWithNotExistCity()
        {
            MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage=new MainPage(webDriver).InputCity(currentUser.DataForBookingWithNotExistCity());
                mainPage.ClickSearchButton();
                Assert.AreEqual(errorInBookingWithNotExistCity, mainPage.GetErrorMessageInNotExistCityBox());
            });
        }

        [Test]
        //3 +
        public void BookingWithRightParameters()
        {
            MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage = new MainPage(webDriver).InputBothCities(currentUser.DataForBookingWithBothCities());
                mainPage.ClickSearchButton();
                Assert.IsTrue( mainPage.GetMessageInBothCitiesBox().Contains(bothCitiesMessage));
            });
        }

        [Test]
        //4 +
        public void WorkWithCheckIn()
        {
            MakeScreenshotWhenFail(() =>
            {
                new MainPage(webDriver).ClickCheckInButton(webDriver);    
                CheckInPage checkInPage = new CheckInPage(webDriver).InputPrivateInformationInCheckInPage(currentUser.DataForCheckIn());
                checkInPage.PressSearchButton();
                Assert.AreEqual(errorInWorkWithCheckIn, checkInPage.GetErrorMessageInCheckInPage());
            });
        }

        [Test]
        //5
        public void WorkWithFlightStatusWithoutAllParameters()
        {
            MakeScreenshotWhenFail(() =>
            {
                new MainPage(webDriver).ClickFlightStatus();
                new FlightStatusPage(webDriver).ClickSearchWithoutAllParameters();
                FlightStatusPage flightStatusPage = new FlightStatusPage(webDriver);
                Assert.IsTrue(flightStatusPage.GetErrorMessageInFlightStatusPage().Contains(errorInFlightStatusWithoutParameters));
            });
        }

        [Test]
        //6
        public void FlightStatusWithAloneCity()
        {
            MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage = new MainPage(webDriver).InputCity(currentUser.DataForBookingWithAloneCity());
                mainPage.ClickSearchButton();
                FlightStatusPage flightStatusPage = new FlightStatusPage(webDriver).InputCityFromInFlightStatusPage(currentStatus.DataForFlighStatus());
                flightStatusPage.ClickSearchWithoutAllParameters();
                Assert.AreEqual(errorInFlightStatusWithCityFrom, flightStatusPage.GetErrorMessageInFlightStatusPageWithCityFrom());
            });
        }

        [Test]
        //7
        public void GiftCardsWithoutParameters()
        {
            MakeScreenshotWhenFail(() =>
            {
                new MainPage(webDriver).ClickGiftCardsPage();
                new GiftCardsPage(webDriver).CheckBalance();
                GiftCardsPage giftCardsPage = new GiftCardsPage(webDriver);
                Assert.AreEqual(errorBalance, giftCardsPage.GetErrorBalance());
            });
        }

        [Test]
        //8
        public void InputPastDate()
        {
            MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage = new MainPage(webDriver);
                Assert.IsTrue(mainPage.GetDate());
            });
        }

        [Test]
        //9
        public void SignIn()
        {
            MakeScreenshotWhenFail(() =>
            {
                new MainPage(webDriver).GoToLogPage();
                LogPage logPage = new LogPage(webDriver);
                logPage.GoSignUp();
                logPage.InputData(registrationUser.DataForRegistration());
                logPage.SubmitSignUp();
                Assert.IsTrue(logPage.GetMessage().Contains(messageSignUp));
            });
        }

        [Test]
        //10
        public void SetOneAdultFourInfant()
        {
            MakeScreenshotWhenFail(() =>
            {
                MainPage mainPage = new MainPage(webDriver).InputBothCities(currentUser.DataForBookingWithBothCities());
                mainPage.SetInfant();
                Assert.AreEqual(messageInfant, mainPage.GetInfantMessage());
            });
        }

    }
}
