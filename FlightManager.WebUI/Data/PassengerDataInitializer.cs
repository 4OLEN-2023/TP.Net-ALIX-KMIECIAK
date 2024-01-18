using FlightManager.Model;
using System;
using System.Linq;

namespace FlightManager.WebUI.Data
{
    public static class PassengerDataInitializer
    {
        public static void Initialize(FlightManagerContext context)
        {
            if (context.Passengers.Any())
            {
                return;
            }

            // Générez et ajoutez les passagers ici
            var flight1 = context.Flights.FirstOrDefault(f => f.Destination == "New York");
            var flight2 = context.Flights.FirstOrDefault(f => f.Destination == "Paris");
            var flight3 = context.Flights.FirstOrDefault(f => f.Destination == "Tokyo");

            var passenger1 = new Passenger
            {
                FirstName = "Jules",
                LastName = "Rotilio",
                Age = 30,
                TicketPrice = 500.0,
                IsCheckedId = true,
                Flight = flight1
            };

            var passenger2 = new Passenger
            {
                FirstName = "Axel",
                LastName = "Silvestre",
                Age = 25,
                TicketPrice = 450.0,
                IsCheckedId = false,
                Flight = flight1 
            };

            var passenger3 = new Passenger
            {
                FirstName = "julien",
                LastName = "Coppel",
                Age = 35,
                TicketPrice = 600.0,
                IsCheckedId = true,
                Flight = flight2 
            };
            
            var passenger4 = new Passenger
            {
                FirstName = "Syrill",
                LastName = "Alix",
                Age = 22,
                TicketPrice = 20000,
                IsCheckedId = true,
                Flight = flight3
            };
            
            var passenger5 = new Passenger
            {
                FirstName = "Théo",
                LastName = "Marion",
                Age = 22,
                TicketPrice = 20000,
                IsCheckedId = true,
                Flight = flight3
            };

            context.Passengers.AddRange(passenger1, passenger2, passenger3, passenger4, passenger5);
            context.SaveChanges();
        }
    }
}