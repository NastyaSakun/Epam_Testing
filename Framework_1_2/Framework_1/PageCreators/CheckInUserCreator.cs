using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework_1
{
    class CheckInUserCreator
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
