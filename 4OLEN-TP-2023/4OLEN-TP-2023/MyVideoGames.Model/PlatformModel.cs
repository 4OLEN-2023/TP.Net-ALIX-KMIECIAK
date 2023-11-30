using System.Text.Json.Serialization;

namespace MyVideoGames.Model;

public class PlatformModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonConstructor]
    public PlatformModel(string name)
    {
        Name = name;
    }
}
