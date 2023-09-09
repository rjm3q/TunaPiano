using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string? Description { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
