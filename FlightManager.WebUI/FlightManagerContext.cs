using Microsoft.EntityFrameworkCore;
using System;
using FlightManager.Model;

namespace FlightManager.WebUI;

public class FlightManagerContext : DbContext
{
        public FlightManagerContext(DbContextOptions<FlightManagerContext> options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
        }
}
    