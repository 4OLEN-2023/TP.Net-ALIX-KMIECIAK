using MyVideoGames.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyVideoGames.WebUI.Models
{
    public class AddGameViewModel
    {
        public Game GameToAdd { get; set; }
        public IList<SelectListItem> PlatformsAvailable { get; set; }
        
    }
}