using System;
namespace App.Models;

public class Passenger
{
    public int PassengerId { get; set; } // Clé primaire
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public decimal TicketPrice { get; set; }
    public bool IsCheckedIn { get; set; }

   
    public int FlightId { get; set; }
    public Flight Flight { get; set; }
    
}