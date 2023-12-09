using TFTDirecting.Database;

namespace TFTDirecting.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public double Budget { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public int DirectorId { get; set; }

        public MovieDto(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Description = movie.Description;
            Duration = movie.Duration;
            Budget = movie.Budget;
            StartingDate = movie.StartingDate;
            EndingDate = movie.EndingDate;
            DirectorId = movie.DirectorId;
        }

        public Movie ToMovie()
        {
            return new Movie
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Duration = Duration,
                Budget = Budget,
                StartingDate = StartingDate,
                EndingDate = EndingDate,
                DirectorId = DirectorId
            };
        }
    }
}
