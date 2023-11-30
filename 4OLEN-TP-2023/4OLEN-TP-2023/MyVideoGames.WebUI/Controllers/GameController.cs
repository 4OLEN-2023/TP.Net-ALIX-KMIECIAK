using Microsoft.AspNetCore.Mvc;
using MyVideoGames.Console.DataProvider;
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
    }
}