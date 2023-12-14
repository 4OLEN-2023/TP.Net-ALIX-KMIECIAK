using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyVideoGames.Console.DataProvider;
using MyVideoGames.Console.DataProvider.Interface;
using MyVideoGames.Model;
using MyVideoGames.WebUI.Models;


namespace MyVideoGames.WebUI.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameDataProvider _gameDataProvider;

        public GameController(IGameDataProvider gameDataProvider)
        {
            _gameDataProvider = gameDataProvider;
        }

        public IActionResult Index()
        {
            var games = _gameDataProvider.GetMyGames();

            var viewModel = new GameListViewModel
            {
                Games = games.ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddOrEdit(int? id = null)
        {
            Game gameToAddOrEdit = new();

            if (id.HasValue)
            {
                gameToAddOrEdit = _gameDataProvider.GetGameById(id.Value);
            }

            AddOrEditGameViewModel model = new()
            {
                GameToAddOrEdit = gameToAddOrEdit,
                PlatformsAvailable = IniPlatformsAvailable()
            };

            return View(model);
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
                    Value = "3",
                    Text = "PC"
                },
                new()
                {
                    Value = "2",
                    Text = "Playstation"
                }
            };
        }

        [HttpPost]
        public IActionResult AddOrEdit(AddOrEditGameViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.PlatformsAvailable = IniPlatformsAvailable();
                return View(viewModel);
            }

            if (viewModel.GameToAddOrEdit.Id != 0)
            {
                _gameDataProvider.Update(viewModel.GameToAddOrEdit);
            }
            else
            {
                _gameDataProvider.Add(viewModel.GameToAddOrEdit);
            }

            return this.RedirectToAction("Index");
        }
    }
}