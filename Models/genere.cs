using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models
{
    public class genere
    {
        public int Id { get; set; }
        public string? description { get; set; }
        public List<song> songs { get; } = new();
    }
}
