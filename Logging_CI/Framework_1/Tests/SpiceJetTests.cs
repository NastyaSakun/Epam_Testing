using Framework_1.PageCreators;
using Framework_1.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Framework_1
{
    [Obsolete]
    public class SpiceJetTests:TestConfig
    {
        const string errorInBookingWithoutAllParameters = "Select Departure City";
        const string errorInWorkWithCheckIn = "The information submitted does not match any itinerary. Please verify the information is correct and try again.";
        const string errorInBookingWithNotExistCity = "Select Arrival City";
        const string bothCitiesMessage = "Kindly fill your GST / UIN details Select Arrival City";
        const string errorInFlightStatusWithoutParameters = "Departure City";
        const string errorInFlightStatusWithCityFrom = "Select Arrival City";
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
                Logger.InitLogger();
                new MainPage(webDriver).ClickSearchButton();
                MainPage mainPage = new MainPage(webDriver);
                Assert.AreEqual(errorInBookingWithoutAllParameters, mainPage.GetErrorMessageInMainPage());
                Logger.Log.Info("Test complete successfully");
            });
        }

        [Test]
        //2 +
        public void BookingWithNotExistCity()
        {
            MakeScreenshotWhenFail(() =>
            {
                Logger.InitLogger();
                MainPage mainPage=new MainPage(webDriver).InputCity(currentUser.DataForBookingWithNotExistCity());
                mainPage.ClickSearchButton();
                Assert.AreEqual(errorInBookingWithNotExistCity, mainPage.GetErrorMessageInNotExistCityBox());
                Logger.Log.Info("Test complete successfully");
            });
        }

        [Test]
        //3 
        public void BookingWithRightParameters()
        {
            MakeScreenshotWhenFail(() =>
            {
                Logger.InitLogger();
                MainPage mainPage = new MainPage(webDriver).InputBothCities(currentUser.DataForBookingWithBothCities(), webDriver);
                mainPage.ClickSearchButton();
                Assert.IsTrue(bothCitiesMessage.Contains(mainPage.GetMessageInBothCitiesBox()));
                Logger.Log.Info("Test complete successfully");
            });
        }

        [Test]
        //4 +
        public void WorkWithCheckIn()
        {
            MakeScreenshotWhenFail(() =>
            {
                Logger.InitLogger();
                new MainPage(webDriver).ClickCheckInButton(webDriver);    
                CheckInPage checkInPage = new CheckInPage(webDriver).InputPrivateInformationInCheckInPage(currentUser.DataForCheckIn());
                checkInPage.PressSearchButton();
                Assert.AreEqual(errorInWorkWithCheckIn, checkInPage.GetErrorMessageInCheckInPage());
                Logger.Log.Info("Test complete successfully");
            });
        }

        [Test]
        //5 +
        public void WorkWithFlightStatusWithoutAllParameters()
        {
            MakeScreenshotWhenFail(() =>
            {
                Logger.InitLogger();
                new MainPage(webDriver).ClickFlightStatus();
                new FlightStatusPage(webDriver).ClickSearchWithoutAllParameters();
                FlightStatusPage flightStatusPage = new FlightStatusPage(webDriver);
                Assert.IsTrue(flightStatusPage.GetErrorMessageInFlightStatusPage().Contains(errorInFlightStatusWithoutParameters));
                Logger.Log.Info("Test complete successfully");
            });
        }

        [Test]
        //6
        public void FlightStatusWithAloneCity()
        {
            MakeScreenshotWhenFail(() =>
            {
                Logger.InitLogger();
                MainPage mainPage = new MainPage(webDriver).InputCity(currentUser.DataForBookingWithAloneCity());
                mainPage.ClickSearchButton();
                //FlightStatusPage flightStatusPage = new FlightStatusPage(webDriver).InputCityFromInFlightStatusPage(currentStatus.DataForFlighStatus());
                //flightStatusPage.ClickSearchWithoutAllParameters();
                Assert.AreEqual(errorInFlightStatusWithCityFrom, mainPage.EmpthyCityError.Text);
                Logger.Log.Info("Test complete successfully");
            });
        }

        [Test]
        //7
        public void GiftCardsWithoutParameters()
        {
            MakeScreenshotWhenFail(() =>
            {
                Logger.InitLogger();
                new MainPage(webDriver).ClickGiftCardsPage();
                webDriver.SwitchTo().Window(webDriver.WindowHandles.Last());
                GiftCardsPage giftCardsPage = new GiftCardsPage(webDriver).CheckBalance(); ;
                Assert.AreEqual(errorBalance, giftCardsPage.GetErrorBalance());
                Logger.Log.Info("Test complete successfully");
            });
        }

        [Test]
        //8
        public void InputPastDate()
        {
            MakeScreenshotWhenFail(() =>
            {
                Logger.InitLogger();
                MainPage mainPage = new MainPage(webDriver);
                Assert.IsTrue(mainPage.GetDate());
                Logger.Log.Info("Test complete successfully");
            });
        }

        [Test]
        //9
        public void SignIn()
        {
            MakeScreenshotWhenFail(() =>
            {
                Logger.InitLogger();
                new MainPage(webDriver).GoToLogPage();
                LogPage logPage = new LogPage(webDriver);
                logPage.GoSignUp();
                Assert.IsTrue(logPage.IsDisplaySignUp());
                Logger.Log.Info("Test complete successfully");
            });
        }

        [Test]
        //10
        public void SetOneAdultFourInfant()
        {
            MakeScreenshotWhenFail(() =>
            {
                Logger.InitLogger();
                MainPage mainPage = new MainPage(webDriver).InputBothCities(currentUser.DataForBookingWithBothCities(), webDriver);
                mainPage.SetInfant();
                Assert.AreEqual(messageInfant, mainPage.GetInfantMessage(webDriver));
                Logger.Log.Info("Test complete successfully");
            });
        }

    }
}
