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
    }
}
