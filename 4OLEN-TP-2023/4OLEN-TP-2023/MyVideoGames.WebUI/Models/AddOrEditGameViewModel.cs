using MyVideoGames.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyVideoGames.WebUI.Models
{
    public class AddOrEditGameViewModel
    {
        public Game GameToAddOrEdit { get; set; }
        public IList<SelectListItem>? PlatformsAvailable { get; set; }
        
    }
}