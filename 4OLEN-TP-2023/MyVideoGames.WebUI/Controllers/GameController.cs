using MyVideoGames.Console.DataProvider;
using MyVideoGames.Model;
using MyVideoGames.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyVideoGames.WebUI.Controllers;

public class GameController: Controller
{
    // Déclaration d'un GameDataProvider
    private GameDataProvider gameDataProvider;

    // Constructeur du controller
    public GameController()
    {
        // Création du data provider
        gameDataProvider = new GameDataProvider();
    }

    /// <summary>
    /// Création d'une action "Index"
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        // Récupération des données via le data-provider
        List<GameModel>? data = gameDataProvider.GetMyGames();

        // Création du model pour la vue
        GameListViewModel model = new GameListViewModel()
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
}