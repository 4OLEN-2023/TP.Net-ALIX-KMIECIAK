using Microsoft.AspNetCore.Mvc.Rendering;
using MyVideoGames.Model;

namespace MyVideoGames.WebUI.Models
{
    public class AddGameViewModel
    {
        // Objet "GameModel" qui sera à ajouter
        public GameModel GameToAdd { get; set; }

        // Liste de plateforme disponibles
        public IList<SelectListItem>? PlatformsAvailable { get; set; }

    }
}