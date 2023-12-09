using TFTDirecting.Commands;
using TFTDirecting.Database;
using TFTDirecting.Dtos;

namespace TFTDirecting.Contracts
{
    public interface IMovieRepository
    {
        void Add(AddMovieCommand command);
        void Update(int movieId, UpdateMovieCommand command);
        void UpdateGenres(int movieId, UpdateMovieGenresCommand command);
        void UpdateActors(int movieId, UpdateMovieActorsCommand command);
        void Delete(Movie movie);
        IEnumerable<MovieDto> GetMoviesByDirector(int directorId, MovieFilter filter);
        MovieDto GetMovieById(int movieId);
        IEnumerable<MovieDto> GetMovies(MovieFilter filter);
    }
}
