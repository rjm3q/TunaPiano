namespace Tuna_Piano.Models
{
    public class song
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int artist_Id { get; set; }
        public string album {  get; set; }
        public int length { get; set; }

    }
}
