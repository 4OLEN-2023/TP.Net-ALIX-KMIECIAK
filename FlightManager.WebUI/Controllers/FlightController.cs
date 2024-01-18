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
        
        public IActionResult Index()
        {
            var flights = _context.Flights.ToList(); 
            return View(flights);
        }
    }
}