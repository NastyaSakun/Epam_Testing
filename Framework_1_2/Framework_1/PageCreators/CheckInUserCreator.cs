
namespace Framework_1
{
    public class CheckInUserCreator
    {
        public ModelCheckInUser DataForCheckIn()
        {
            return new ModelCheckInUser(CheckInUserConfig.GetData("TicketNumber"),
                            CheckInUserConfig.GetData("Surname"));
        }

        public ModelCheckInUser DataForBookingWithNotExistCity()
        {
            return new ModelCheckInUser(CheckInUserConfig.GetData("NotExistCity"));
        }

        public ModelCheckInUser DataForBookingWithAloneCity()
        {
            return new ModelCheckInUser(CheckInUserConfig.GetData("AloneCity"));
        }

        public ModelCheckInUser DataForBookingWithBothCities()
        {
            return new ModelCheckInUser(CheckInUserConfig.GetData("AloneCity"), CheckInUserConfig.GetData("CityTo"));
        }
    }
}
