using MyVideoGames.Console.DataProvider;
using MyVideoGames.Model;
using MyVideoGames.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyVideoGames.Console.DataProvider.Interfaces;

namespace MyVideoGames.WebUI.Controllers;

public class GameController: Controller
{
    // Déclaration d'un GameDataProvider
    public IGameDataProvider gameDataProvider;


    /// <summary>
    /// Création d'une action "Index"
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        GameDataProvider gameDataProvider = new ();
        // Récupération des données via le data-provider
        List<GameModel>? data = gameDataProvider.GetMyGames();

        // Création du model pour la vue
        GameListViewModel model = new ()
        {
            PageTitle = "Ma liste de jeux"
        };

        // Vérification de la donnée
        if (data != null)
        {
            // Passage des données récupérée au model
            model.Games = data;
        }

        // Retour de la vue avec le model associé
        return View(model);
    }

    // Création d'une action de type HttpGET
    [HttpGet]
    public IActionResult Add()
    {
        AddGameViewModel model = new()
        {
            GameToAdd = new(),
            PlatformsAvailable = InitializePlatforms()
        };

        return View(model);
    }

    // Création d'une action de type HttpPost
    [HttpPost]
    public IActionResult Add(AddGameViewModel model)
    {
        if (!ModelState.IsValid)
        {
            //ModelState.AddModelError("Name", "Game Not Found");
            model.PlatformsAvailable = InitializePlatforms();
            return View(model);
        }

        //Quand tout est ok 
        return RedirectToAction(nameof(this.Index));
    }

    private List<SelectListItem> InitializePlatforms()
    {
        return new List<SelectListItem>
        {
            new () { Text = "Xbox", Value = "1" },
            new () { Text = "Playstation", Value = "2" },
            new () { Text = "PC", Value = "3" }
        };
    }
}