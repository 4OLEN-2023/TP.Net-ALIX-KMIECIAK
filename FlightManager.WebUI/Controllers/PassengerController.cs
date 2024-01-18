using Microsoft.AspNetCore.Mvc;

namespace FlightManager.WebUI.Controllers
{
    public class PassengerController : Controller
    {
        public PassengerController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
