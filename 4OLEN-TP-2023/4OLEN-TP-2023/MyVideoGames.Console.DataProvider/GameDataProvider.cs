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
    
    
    public GameDataProvider()
    {
    }
    public List<GameModel> GetAllGames()
    {
        try
        {
            string jsonString = File.ReadAllText("C:\\ProjetNET\\tp.net-alix-kmieciak\\4OLEN-TP-2023\\4OLEN-TP-2023\\MyVideoGames.Console.DataProvider\\JsonFiles\\MyGame.json");
            return JsonSerializer.Deserialize<List<GameModel>>(jsonString);
        }
        catch (IOException ex)
        {
            throw new InvalidOperationException("Erreur lecture du JSON.", ex);
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException("Erreur lecture JSON.", ex);
        }
    }
}