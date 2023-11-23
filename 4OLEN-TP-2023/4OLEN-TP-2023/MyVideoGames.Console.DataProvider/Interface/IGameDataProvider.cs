using MyVideoGames.Model;

namespace MyVideoGames.Console.DataProvider.Interface;

public interface IGameDataProvider
{
    public GameModel GetMyGame(string myGameFile);
}