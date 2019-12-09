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
        public ModelCheckInUser(string ticketNumber, string surname)
        {
            TicketNumber = ticketNumber;
            Surname = surname;
        }
    }
}
