using MyVideoGames.Model;

namespace MyVideoGames.Console.DataProvider.Interface;

public interface IGameDataProvider
{
    public Game GetMyGame(string myGameFile);
    List<Game> GetAllGames();
    
    public IEnumerable<Game> GetMyGames();

    public void Add(Game gameToAdd);
    public Game? GetGameById(int gameId);
    
    public void Update(Game gameToAdd);

}