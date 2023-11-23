using MyVideoGames.Model;

namespace MyVideoGames.Console.DataProvider.Interfaces;

public interface IGameDataProvider
{
    public GameModel? GetMyGame();

    public List<GameModel>? GetMyGames();
}