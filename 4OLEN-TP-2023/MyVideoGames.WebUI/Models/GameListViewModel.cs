using MyVideoGames.Model;

namespace MyVideoGames.WebUI.Models;

public class GameListViewModel
{
    public string PageTitle { get; set; }

    public List<GameModel> Games { get; set; }
}