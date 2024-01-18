using Microsoft.AspNetCore.Mvc;
using FlightManager.WebUI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FlightManager.WebUI.Controllers
{
    public class FlightController : Controller
    {
        private readonly FlightManagerContext _context;
        
        public FlightController(FlightManagerContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var flights = await _context.Flights
                .Include(f => f.Passengers)
                .ToListAsync();
            return View(flights);
        }
    }
}