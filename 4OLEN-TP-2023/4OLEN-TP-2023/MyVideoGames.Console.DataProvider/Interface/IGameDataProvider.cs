using MyVideoGames.Model;

namespace MyVideoGames.Console.DataProvider.Interface;

public interface IGameDataProvider
{
    public Game GetMyGame(string myGameFile);
    List<Game> GetAllGames();
}