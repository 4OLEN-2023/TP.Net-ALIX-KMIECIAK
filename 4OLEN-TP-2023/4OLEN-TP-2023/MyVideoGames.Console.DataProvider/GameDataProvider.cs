using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MyVideoGames.Console.DataProvider.Interface;
using MyVideoGames.DataContext;
using MyVideoGames.Model;

namespace MyVideoGames.Console.DataProvider;

public class GameDataProvider : IGameDataProvider
{
    private readonly MainDbContext _context;
    public GameDataProvider(MainDbContext context)
    {
        _context = context;
    }

    public GameDataProvider()
    {
    }

    public IEnumerable<Game> GetMyGames()
    {
        //string jsonString = File.ReadAllText(myGamesFile);
        //IList<Game> games = JsonConvert.DeserializeObject<List<Game>>(jsonString);

        IEnumerable<Game>? games = _context.Games.Include(game => game.Platform);
        return games;
    }

    public void Add(Game gameToAdd)
    {
        _context.Add(gameToAdd);
        _context.SaveChanges();
    }

    public Game? GetGameById(int gameId)
    {
        return _context.Games.SingleOrDefault(game => game.Id == gameId);
    }

    public void Update(Game gameToAdd)
    {
        _context.Update(gameToAdd);
        _context.SaveChanges();
    }
    
    public void Delete(int gameId)
    {
        _context.Games.Remove(GetGameById(gameId));
        _context.SaveChanges();
    }

    public Game GetMyGame(string myGameFile)
    {
       //ouverture du fichier et lecture
       
       string jsonString = File.ReadAllText(myGameFile);
       
       //transformation de l'objet en objet 
       Game? game = JsonSerializer.Deserialize<Game>(jsonString);
       
       //renvoi
       return game;
    }
    
    
    
    public List<Game> GetAllGames()
    {
        try
        {
            string jsonString = File.ReadAllText("C:\\ProjetNET\\tp.net-alix-kmieciak\\4OLEN-TP-2023\\4OLEN-TP-2023\\MyVideoGames.Console.DataProvider\\JsonFiles\\MyGame.json");
            return JsonSerializer.Deserialize<List<Game>>(jsonString);
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