using Microsoft.AspNetCore.Mvc.Rendering;
using MyVideoGames.Model;

namespace MyVideoGames.WebUI.Models
{
    public class AddOrEditPlatformViewModel
    {
        public Platform PlatformToAddOrEdit { get; set; }
    }
}