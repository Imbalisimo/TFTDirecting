using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Dtos;

namespace TFTDirecting.Repository
{
    public class MovieRepository : IMovieRepository
    {
        public void Add(AddMovieCommand command)
        {
            throw new NotImplementedException();
        }

        public void Delete(int movieId)
        {
            throw new NotImplementedException();
        }

        public MovieDto GetMovieById(int movieId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDto> GetMovies(MovieFilter filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDto> GetMoviesByDirector(int directorId, MovieFilter filter)
        {
            throw new NotImplementedException();
        }

        public void Update(int movieId, UpdateMovieCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
