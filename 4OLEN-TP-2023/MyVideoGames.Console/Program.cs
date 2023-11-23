// Imports des projets nécessaires
using MyVideoGames.Console.DataProvider;
using MyVideoGames.Model;

// Création d'un GameDataProvider
GameDataProvider gameDataProvider = new GameDataProvider();

// Appel de la méthode qui retourne les données via un objet
GameModel myGameModel = gameDataProvider.GetMyGame();

// Affichage des données
PrintMyGame(myGameModel);

// Mise en pause de la console
Console.ReadLine();

// Méthode permettant l'affichage de notre jeu issue du json
static void PrintMyGame(GameModel game)
{
    var newLine = $"{Environment.NewLine}{Environment.NewLine}";

    Console.WriteLine($"My video game : {newLine}" +
                      $"{game.Id} - {game.Slug} {newLine}" +
                      $"{game.Name} {newLine}" +
                      $"Release date : {game.ReleaseDate.ToShortDateString()}{newLine}" +
                      $"Platform : {game.Plateform.Name}{newLine}" +
                      $"Rating : {game.Rating}/{game.RatingTop}{newLine}" +
                      $"Play time : {game.PlayTime}h{newLine}" +
                      $"Description : {game.Description}{newLine}");
}