using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyVideoGames.Model;

public class Game
{
    // Attribut indiquant à la librairie JSON le nom de la propriété JSON associée au champs
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("name")]
    [StringLength(20, ErrorMessage = "Can contain only 20 characters")]
    [Required] 
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
    
    public int PlatformId { get; set; }
}