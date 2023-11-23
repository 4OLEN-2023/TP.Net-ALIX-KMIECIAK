using System.Text.Json;
using MyVideoGames.Console.DataProvider.Interface;
using MyVideoGames.Model;

namespace MyVideoGames.Console.DataProvider;

public class GameDataProvider : IGameDataProvider
{
    public GameModel GetMyGame(string myGameFile)
    {
       //ouverture du fichier et lecture
       
       string jsonString = File.ReadAllText(myGameFile);
       
       //transformation de l'objet en objet 
       GameModel? game = JsonSerializer.Deserialize<GameModel>(jsonString);
       
       //renvoi
       return game;
    }
}