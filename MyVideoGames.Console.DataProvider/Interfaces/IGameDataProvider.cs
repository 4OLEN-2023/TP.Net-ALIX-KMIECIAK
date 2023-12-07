using MyVideoGames.Model;

namespace MyVideoGames.Console.DataProvider.Interfaces;

public interface IGameDataProvider
{
    public Game? GetMyGame();

    public IEnumerable<Game>? GetMyGames();
    public Game? GetGameById(int gameId);

    public void Add(Game gameToAdd);
    
    public void Update(Game Game);
}