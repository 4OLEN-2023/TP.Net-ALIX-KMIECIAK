using Microsoft.AspNetCore.Mvc.Rendering;
using MyVideoGames.Model;

namespace MyVideoGames.WebUI.Models
{
    public class AddOrEditGameViewModel
    {
        // Objet "GameModel" qui sera à ajouter
        public Game GameToAddOrEdit { get; set; }

        // Liste de plateforme disponibles
        public IList<SelectListItem>? PlatformsAvailable { get; set; }

    }
}