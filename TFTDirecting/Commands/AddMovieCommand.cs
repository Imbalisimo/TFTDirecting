using TFTDirecting.Database;

namespace TFTDirecting.Commands
{
    public class AddMovieCommand: UpdateMovieCommand
    {
        public int DirectorId { get; set; }

        public Movie ToMovie()
        {
            var movie = ToMovie(0);
            movie.DirectorId = DirectorId;
            return movie;
        }
    }
}
