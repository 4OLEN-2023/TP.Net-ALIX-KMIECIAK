using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Model
{
    public class Flight
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public int SeatCount { get; set; }
        public DateTime TakeOffDate { get; set; }
        public string OnBoardingMessage { get; set; }
        public bool IsDelayed { get; set; }
        public double NetSales { get; set; }
        public List<Passenger> Passengers { get; set; }
        
        
    }
}
