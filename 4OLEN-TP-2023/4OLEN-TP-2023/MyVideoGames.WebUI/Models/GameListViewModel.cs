using MyVideoGames.WebUI.Models; 
using System.Collections.Generic;
using MyVideoGames.Model;

namespace MyVideoGames.WebUI.Models
{
    public class GameListViewModel
    {
        public List<Game> Games { get; set; } = new List<Game>();
    }
}