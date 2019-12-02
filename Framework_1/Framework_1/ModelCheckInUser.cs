using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework_1
{
    public class ModelCheckInUser
    {
        public string TicketNumber { get; }
        public string Surname { get; }
        public ModelCheckInUser(string ticketNumber, string surname)
        {
            Surname = surname;
            TicketNumber = ticketNumber;
        }
    }
}
