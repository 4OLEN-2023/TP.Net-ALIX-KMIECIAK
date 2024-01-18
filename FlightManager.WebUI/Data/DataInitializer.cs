using FlightManager.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FlightManager.WebUI.Data
{
    public static class DataInitializer
    {
        public static void Initialize(FlightManagerContext context)
        {
            context.Database.EnsureCreated();

          
            if (context.Flights.Any())
            {
                return; 
            }
            
            var flight1 = new Flight
            {
                Destination = "New York",
                SeatCount = 150,
                TakeOffDate = DateTime.Parse("2024-01-25"),
                OnBoardingMessage = "Un vol aussi rapide que l'éclair",
                IsDelayed = false,
                NetSales = 150000
            };

            var flight2 = new Flight
            {
                Destination = "Paris",
                SeatCount = 200,
                TakeOffDate = DateTime.Parse("2024-02-10"),
                OnBoardingMessage = "La qualité Air france n'a pas de prix",
                IsDelayed = true,
                NetSales = 180000
            };
            
            var flight3 = new Flight
            {
                Destination = "Tokyo",
                SeatCount = 10,
                TakeOffDate = DateTime.Parse("2024-01-20"),
                OnBoardingMessage = "Un jet privé pour vos amis les plus privés ",
                IsDelayed = false,
                NetSales = 90000
            };

            context.Flights.AddRange(flight1, flight2, flight3);
            context.SaveChanges();
            
            var passenger1 = new Passenger
            {
                FirstName = "Jules",
                LastName = "Rotilio",
                Age = 30,
                TicketPrice = 500.0,
                IsCheckedId = true,
                // Flight = flight1 
            };

           
            context.SaveChanges();
        }
    }
}