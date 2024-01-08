using Microsoft.AspNetCore.Authorization;
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
        private readonly IPlatformDataProvider platformDataProvider;
        
        public GameController(IGameDataProvider gameDataProvider, IPlatformDataProvider _platformDataProvider)
        {
            _gameDataProvider = gameDataProvider;
            platformDataProvider = _platformDataProvider;
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

        public List<SelectListItem> IniPlatformsAvailable()
        {
            return platformDataProvider.GetPlatforms().Select(platform => new SelectListItem
            {
                Text = platform.Name,
                Value = platform.Id.ToString()
            }).ToList();
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
        
        public IActionResult Delete(int id)
        {
            _gameDataProvider.Delete(id);

            return this.RedirectToAction("Index");
        }
    }
}