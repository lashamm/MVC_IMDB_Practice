using MVC_IMDB_Practice.Enums;

namespace MVC_IMDB_Practice.Models.Entities
{

    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Genre Genre { get; set; }   

        public DateTime ReleaseYear { get; set; }

        public string Director { get; set; }

        public TimeSpan Duration { get; set; }


    }
}
