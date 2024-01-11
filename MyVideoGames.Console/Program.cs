// Imports des projets nécessaires
using MyVideoGames.Console.DataProvider;
using MyVideoGames.Model;

// Création d'un GameDataProvider
GameDataProvider gameDataProvider = new GameDataProvider(null);

// Appel de la méthode qui retourne les données via un objet
List<Game> myGameModels = gameDataProvider.GetMyGames().ToList();

foreach (Game game in myGameModels)
{
    PrintMyGame(game);
}

myGameModels.Where(g => g.Name == "rekopskgre");

// Affichage des données
//PrintMyGame(myGameModel);

// Mise en pause de la console
Console.ReadLine();

// Méthode permettant l'affichage de notre jeu issue du json
static void PrintMyGame(Game game)
{
    var newLine = $"{Environment.NewLine}{Environment.NewLine}";

    Console.WriteLine($"My video game : {newLine}" +
                      $"{game.Id} - {game.Slug} {newLine}" +
                      $"{game.Name} {newLine}" +
                      $"Release date : {game.ReleaseDate.ToShortDateString()}{newLine}" +
                      $"Platform : {game.Platform.Name}{newLine}" +
                      $"Rating : {game.Rating}/{game.RatingTop}{newLine}" +
                      $"Play time : {game.PlayTime}h{newLine}" +
                      $"Description : {game.Description}{newLine}");
}