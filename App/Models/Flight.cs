using System;
using System.Collections.Generic;

namespace App.Models;

public class Flight
{
    public int FlightId { get; set; } 
    public string Destination { get; set; }
    public int SeatCount { get; set; }
    public DateTime TakeOffDate { get; set; }
    public string OnBoardingMessage { get; set; }
    public bool IsDelayed { get; set; }
    public decimal NetSales { get; set; }
    
    public ICollection<Passenger> Passengers { get; set; }
    
}