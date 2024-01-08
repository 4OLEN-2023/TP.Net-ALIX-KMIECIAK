using MyVideoGames.Model;

namespace MyVideoGames.WebUI.Models
{
    public class PlatformListViewModel
    {
        public string? PageTitle { get; set; }

        public List<Platform>? Platforms { get; set; }
    }
}