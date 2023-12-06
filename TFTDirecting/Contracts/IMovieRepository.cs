using TFTDirecting.Commands;
using TFTDirecting.Dtos;

namespace TFTDirecting.Contracts
{
    public interface IMovieRepository
    {
        void Add(AddMovieCommand command);
        void Update(int movieId, UpdateMovieCommand command);
        void Delete(int movieId);
        IEnumerable<MovieDto> GetMoviesByDirector(int directorId, MovieFilter filter);
        MovieDto GetMovieById(int movieId);
        IEnumerable<MovieDto> GetMovies(MovieFilter filter);
    }
}
