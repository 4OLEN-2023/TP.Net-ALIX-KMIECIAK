using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyVideoGames.Model;


public enum TypeDeJeu
{
    
    FPS = 1,
    Platforme = 2,
    Autre = 3
}

public class Game
{
    public int Id { get; set; }
    
    public TypeDeJeu Type { set; get; }

    public string Slug { get; set; }

    [StringLength(20, ErrorMessage = "Can contain only 20 characters")]
    [Required] 
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime ReleaseDate { get; set; }

    public float Rating { get; set; }

    public int RatingTop { get; set; }

    public int PlayTime { get; set; }

    public Platform? Platform { get; set; }
    
    public int PlatformId { get; set; }
}