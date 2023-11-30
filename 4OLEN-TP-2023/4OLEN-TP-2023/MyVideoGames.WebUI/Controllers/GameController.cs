using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyVideoGames.Console.DataProvider;
using MyVideoGames.Model;
using MyVideoGames.WebUI.Models;


namespace MyVideoGames.WebUI.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            var _gameDataProvider = new GameDataProvider();

            var games = _gameDataProvider.GetAllGames();

            var viewModel = new GameListViewModel
            {
                Games = games
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new AddGameViewModel
            {
                GameToAdd = new GameModel(),
                PlatformsAvailable = IniPlatformsAvailable()
            };
            return View(viewModel);
        }

        private static List<SelectListItem> IniPlatformsAvailable()
        {
            return new List<SelectListItem>
            {
                new()
                {
                    Value = "1",
                    Text = "Xbox"
                },
                new()
                {
                    Value = "2",
                    Text = "PC"
                },
                new()
                {
                    Value = "1",
                    Text = "Playstation"
                }
            };
        }

        [HttpPost]
        public IActionResult Add(AddGameViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}