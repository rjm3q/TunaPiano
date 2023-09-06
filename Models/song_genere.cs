using System.ComponentModel.DataAnnotations;

namespace TunaPiano.Models
{
    public class song_genere
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int song_Id { get; set; }
        [Required]
        public int genere_Id { get; set; }

    }
}
