using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models
{
    public class artist
    {
        [Required]
        public int Id { get; set; }
        [Required] 
        public string? name { get; set; }
        [Required] 
        public int age { get; set; }
        [Required] 
        public string? bio { get; set; }
        public List<song> songs { get; } = new();
    }
}
