﻿using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Dtos;

namespace TFTDirecting.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void Add(AddMovieCommand command)
        {
            _movieRepository.Add(command);
        }

        public void Delete(int movieId)
        {
            _movieRepository.Delete(movieId);
        }

        public IEnumerable<MovieDto> GetMoviesByDirector(int directorId, MovieFilter filter)
        {
            return _movieRepository.GetMoviesByDirector(directorId, filter);
        }

        public MovieDto GetMovieById(int movieId)
        {
            return _movieRepository.GetMovieById(movieId);
        }

        public IEnumerable<MovieDto> GetMovies(MovieFilter filter)
        {
            return _movieRepository.GetMovies(filter);
        }

        public void Update(int movieId, UpdateMovieCommand command)
        {
            _movieRepository.Update(movieId, command);
        }
    }
}
