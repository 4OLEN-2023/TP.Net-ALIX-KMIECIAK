using System;
using MyVideoGames.Model; 
using MyVideoGames.Console.DataProvider;
using MyVideoGames.Console.DataProvider.Interface;

class Program
{
    static void Main(string[] args)
    {
     
        IGameDataProvider gameDataProvider = new GameDataProvider();
        Game game = gameDataProvider.GetMyGame(@"C:\ProjetNET\tp.net-alix-kmieciak\4OLEN-TP-2023\4OLEN-TP-2023\MyVideoGames.Console.DataProvider\JsonFiles\MyGame.json");
        
        if (game != null)
        {
            DisplayGameData(game);
        }
        else
        {
            Console.WriteLine("Données non chargées.");
        }
    }

    static void DisplayGameData(Game game)
    {
      
        Console.WriteLine($"Nom: {game.Name}");
        Console.WriteLine($"Date de sortie: {game.ReleaseDate}");
        Console.WriteLine($"Note: {game.Rating} / {game.RatingTop}");
        Console.WriteLine($"Temps de jeu: {game.PlayTime} heures");
        Console.WriteLine($"platform: {game.Platform.Name}");
    }
}