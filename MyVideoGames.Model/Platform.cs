using System.Text.Json.Serialization;

namespace MyVideoGames.Model;

public class Platform
{
        public int Id { get; set; }
        
        [JsonPropertyName("name")] 
        public string Name { get; set; }
        
        public IList<Game>? RelatedGames { get; set; }
}