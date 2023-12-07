using MyVideoGames.Model;

namespace MyVideoGames.WebUI.Models;

public class GameListViewModel
{
    public string PageTitle { get; set; }

    public List<Game> Games { get; set; }
}