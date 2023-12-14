using System.Text.Json.Serialization;

namespace MyVideoGames.Model;
    
public class Game
{
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    public int PlatformId { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description_raw")]
    public string Description { get; set; }

    [JsonPropertyName("released")]
    public DateTime ReleaseDate { get; set; }

    [JsonPropertyName("rating")]
    public float Rating { get; set; }

    [JsonPropertyName("rating_top")]
    public int RatingTop { get; set; }

    [JsonPropertyName("playtime")]
    public int PlayTime { get; set; }

    [JsonPropertyName("platform")]
    public Platform? Platform { get; set; }
    
    
    
}
