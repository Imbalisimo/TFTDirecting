using Microsoft.AspNetCore.Mvc;
using System.IO;
using TFTDirecting.Commands;
using TFTDirecting.Database;
using TFTDirecting.Dtos;

namespace TFTDirecting.Contracts
{
    public interface IMovieService
    {
        IEnumerable<MovieDto> GetMovies(MovieFilter filter);
        MovieDto GetMovieById(int movieId);
        IEnumerable<MovieDto> GetMoviesByDirector(int directorId, MovieFilter filter);
        void Add(AddMovieCommand command);
        void Update(int movieId, UpdateMovieCommand command);
        void Delete(int movieId);
    }
}
