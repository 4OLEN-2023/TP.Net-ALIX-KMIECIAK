using System.Text.Json.Serialization;

namespace MyVideoGames.Model;

public class Platform
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    public int Id { get; set; }

    [JsonConstructor]
    public Platform()
    {
    }
    
    public IList<Game>? RelatedGames { get; set; }
    
}
