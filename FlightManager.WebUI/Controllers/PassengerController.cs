using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.WebUI.Controllers
{
    public class PassengerController : Controller
    {
        private readonly FlightManagerContext _context;

        public PassengerController(FlightManagerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var passengers = _context.Passengers.Include(p => p.Flight).ToList();
            return View(passengers);
        }

    }
}
