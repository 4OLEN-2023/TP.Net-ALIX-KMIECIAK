using System.Text.Json;
using MyVideoGames.Console.DataProvider.Interfaces;
using MyVideoGames.Model;

namespace MyVideoGames.Console.DataProvider;

public class GameDataProvider: IGameDataProvider
{
    // Propriété retournant le chemin
    private string myGamesFilePath
    {
        get { return "/Users/ClementFevre/Downloads/ORT/TP-Master/4OLEN-TP-2023/MyVideoGames.Console.DataProvider/JsonFiles"; }
    }

    // Propriété qui concatène le chemin et le nom du fichier
    private string myGameFile
    {
        get { return Path.Combine(myGamesFilePath, "MyGame.json"); }
    }

    private string myGamesFile
    {
        get { return Path.Combine(myGamesFilePath, "MyGames.json"); }
    }

    // Méthode de lecture et de déserialisation du fichier JSON
    public GameModel? GetMyGame()
    {
        // Ouverture du fichier et lecture de son contenu texte
        string jsonString = File.ReadAllText(myGameFile);

        // Transformation de l'objet en Objet (deserialisation)
        GameModel? game = JsonSerializer.Deserialize<GameModel>(jsonString);

        // Renvoi
        return game;
    }

    public List<GameModel>? GetMyGames()
    {
        string jsonString = File.ReadAllText(myGamesFile);

        List<GameModel>? games = JsonSerializer.Deserialize<List<GameModel>>(jsonString);

        return games;
    }
}