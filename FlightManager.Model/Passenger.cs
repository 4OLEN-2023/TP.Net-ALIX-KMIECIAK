using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Model
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double TicketPrice { get; set; }
        public bool IsCheckedId { get; set; }
        public Flight Flight { get; set; }
    }
}
