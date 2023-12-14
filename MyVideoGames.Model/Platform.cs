using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyVideoGames.Model;

public class Platform
{
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        //[NotMapped]
        public DateTime ReleaseDate { get; set; }
        
        public IList<Game>? RelatedGames { get; set; }
}