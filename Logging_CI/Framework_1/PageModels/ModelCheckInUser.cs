using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework_1
{
    public class ModelCheckInUser
    {
        public string TicketNumber { get; set; }
        public string Surname { get; set; }
        public string NotExistCity { get; set; }
        public string AloneCity { get; set; }
        public string CityTo { get; set; }
        public ModelCheckInUser(string t, string s)
        {
            TicketNumber = t;
            Surname = s;
            AloneCity = t;
            CityTo = s;
        }

        public ModelCheckInUser(string city)
        {
            NotExistCity = city;
            AloneCity = city;
        }
    }
}
