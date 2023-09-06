using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models
{
    public class song
    {
        [Required]
        public int Id { get; set; }
        [Required] 
        public string? title { get; set; }
        [Required] 
        public int artist_Id { get; set; }
        [Required] 
        public string? album { get; set; }
        [Required] 
        public int length { get; set; }
        
        public List<genere> genere { get; } = new();
    }
}
