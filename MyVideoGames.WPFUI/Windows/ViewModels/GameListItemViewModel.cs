using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoGames.WPFUI.Windows.ViewModels
{
    // ViewModel définissant un élément de la liste "GameList"
    // Voir ViewModels/MainWindowViewModel.cs
    public class GameListItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public float Rating { get; set; }
    }
}