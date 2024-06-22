namespace MovieApi.Models
{
    public class Movie
    {
        public int  id { get; set; }

        public string title { get; set; }
        public int year { get; set; }

        public double rate { get; set; }

        public string storeline { get; set; }

        public byte[] poster { get; set; }

        public int genreid { get; set; }

        public Genre genre { get; set; }
    }
}
