using Microsoft.EntityFrameworkCore;
using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Database;
using TFTDirecting.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TFTDirecting.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IConfiguration _config;
        public MovieRepository(IConfiguration config)
        {
            _config = config;
        }

        public void Add(AddMovieCommand command)
        {
            using (var db = new MoviesDbContext(_config))
            {
                db.Movies.Add(command.ToMovie());
                db.SaveChanges();
            }
        }

        public void Delete(Movie movie)
        {
            using (var db = new MoviesDbContext(_config))
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }

        public MovieDto GetMovieById(int movieId)
        {
            using (var db = new MoviesDbContext(_config))
            {
                var u = (from movie in db.Movies
                         where movie.Id == movieId
                         select movie).SingleOrDefault();

                return new MovieDto(u);
            }
        }

        public IEnumerable<MovieDto> GetMovies(MovieFilter filter)
        {
            using (var db = new MoviesDbContext(_config))
            {
                return (from movie in db.Movies.Include(g => g.Genres)
                        where filter.Budget != null ? movie.Budget == filter.Budget : true &&
                           filter.StartingDate != null ? movie.EndingDate >= filter.StartingDate : true &&
                           filter.EndingDate != null ? movie.EndingDate <= filter.EndingDate : true &&
                           filter.Genre != null ? movie.Genres.Any(genre => genre.Id == filter.Genre) : true
                        select new MovieDto(movie)).ToList();
            }
        }

        public IEnumerable<MovieDto> GetMoviesByDirector(int directorId, MovieFilter filter)
        {
            using (var db = new MoviesDbContext(_config))
            {
                return (from movie in db.Movies.Include(g => g.Genres)
                        where filter.Budget != null ? movie.Budget == filter.Budget : true &&
                           filter.StartingDate != null ? movie.EndingDate >= filter.StartingDate : true &&
                           filter.EndingDate != null ? movie.EndingDate <= filter.EndingDate : true &&
                           filter.Genre != null ? movie.Genres.Any(genre => genre.Id == filter.Genre) : true &&
                           movie.DirectorId == directorId
                        select new MovieDto(movie)).ToList();
            }
        }

        public void Update(int movieId, UpdateMovieCommand command)
        {
            using (var db = new MoviesDbContext(_config))
            {
                if (command.StartingDate != null)
                {
                    var isExpenseHigherThanBudget = (from movie in db.Movies
                                                     where movie.Budget > GetExpectedMovieCost(movie.Id)
                                                     select movie).Any();

                    if (isExpenseHigherThanBudget)
                    {
                        throw new Exception("Actors' salary cost higher than the movie budget!");
                    }
                }

                var updatingMovie = (from movie in db.Movies
                                    where movie.Id == movieId
                                    select movie).SingleOrDefault();

                command.UpdateMovie(updatingMovie);
                db.SaveChanges();
            }
        }

        public double GetExpectedMovieCost(int movieId)
        {
            using (var db = new MoviesDbContext(_config))
            {
                return (from app in db.ActorMovieApplications
                        where app.MovieId == movieId &&
                            app.IsAcceptedByDirector &&
                            app.IsAcceptedByActor
                        join actor in db.Users on app.ActorId equals actor.Id
                        select actor.ExpectedSalary).Sum();
            }
        }

        public void UpdateActors(int movieId, UpdateMovieActorsCommand command)
        {
            using (var db = new MoviesDbContext(_config))
            {
                var newActors = from actor in db.Users
                                where command.Actors.Any((id) => id == actor.Id)
                                select actor;
                var updatingMovie = (from movie in db.Movies.Include(a => a.Actors)
                                     where movie.Id == movieId
                                     select movie).SingleOrDefault();

                updatingMovie.Actors = newActors.ToList();
                db.SaveChanges();
            }
        }

        public void UpdateGenres(int movieId, UpdateMovieGenresCommand command)
        {
            using (var db = new MoviesDbContext(_config))
            {
                var newGenres = from genre in db.Genres
                                where command.Genres.Any((id) => id == genre.Id)
                                select genre;
                var updatingMovie = (from movie in db.Movies.Include(g => g.Genres)
                                     where movie.Id == movieId
                                     select movie).SingleOrDefault();

                updatingMovie.Genres = newGenres.ToList();
                db.SaveChanges();
            }
        }
    }
}
