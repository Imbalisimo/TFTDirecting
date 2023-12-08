using TFTDirecting.Database;

namespace TFTDirecting.Commands
{
    public class UpdateMovieCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
        public double Budget { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }

        public Movie ToMovie(int movieId)
        {
            return new Movie
            {
                Id = movieId,
                Name = Name,
                Description = Description,
                Duration = Duration,
                Budget = Budget,
                StartingDate = StartingDate,
                EndingDate = EndingDate
            };
        }

        public void UpdateMovie(Movie? movie)
        {
            if (movie == null) return;

            movie.Name = Name;
            movie.Description = Description;
            movie.Duration = Duration;
            movie.Budget = Budget;
            movie.StartingDate = StartingDate;
            movie.EndingDate = EndingDate;
        }
    }
}
