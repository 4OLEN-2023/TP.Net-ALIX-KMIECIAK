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
    
    // Constructeur avec injection de dépendances
    public GameController(IGameDataProvider gameDataProvider)
    {
        this.gameDataProvider = gameDataProvider;
    }
    
    /// <summary>
    /// Création d'une action "Index"
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        // Récupération des données via le data-provider
        List<Game>? data = gameDataProvider.GetMyGames()?.ToList();

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
    public IActionResult AddOrEdit(int? id)
    {
        Game gameToAddOrEdit = new();

        if (id.HasValue)
        {
            gameToAddOrEdit = gameDataProvider.GetGameById(id.Value);
        }

        AddOrEditGameViewModel model = new()
        {
            GameToAddOrEdit = gameToAddOrEdit,
            PlatformsAvailable = InitializePlatforms()
        };

        return View(model);
    }

    // Création d'une action de type HttpPost
    [HttpPost]
    public IActionResult AddOrEdit(AddOrEditGameViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.PlatformsAvailable = InitializePlatforms();
            return View(model);
        }

        if(model.GameToAddOrEdit.Id != 0)
        {
            gameDataProvider.Update(model.GameToAddOrEdit);
        }
        else
        {
            gameDataProvider.Add(model.GameToAddOrEdit);
        }

        return this.RedirectToAction("Index");
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