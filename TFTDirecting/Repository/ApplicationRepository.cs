using System.Linq;
using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Database;
using TFTDirecting.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TFTDirecting.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly IConfiguration _config;
        public ApplicationRepository(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<UserDto> GetActorsAppliedForMovie(int movieId)
        {
            using (var db = new MoviesDbContext(_config))
            {
                return (from application in db.ActorMovieApplications
                       where application.MovieId == movieId
                       from actor in db.Users
                       where actor.Id == application.ActorId
                       select new UserDto(actor)).ToList();
            }
        }

        public IEnumerable<InviteDto> GetMoviesApplicationsForActor(int actorId)
        {
            using (var db = new MoviesDbContext(_config))
            {
                return (from application in db.ActorMovieApplications
                        where application.ActorId == actorId &&
                            application.IsAcceptedByActor &&
                            !application.IsAcceptedByDirector
                        select new InviteDto(application)).ToList();
            }
        }

        public IEnumerable<InviteDto> GetMoviesInvitesForActor(int actorId)
        {
            using (var db = new MoviesDbContext(_config))
            {
                return (from application in db.ActorMovieApplications
                        where application.ActorId == actorId &&
                            !application.IsAcceptedByActor &&
                            application.IsAcceptedByDirector
                        select new InviteDto(application)).ToList();
            }
        }

        public IEnumerable<MovieDto> GetMoviesWithApprovedRoles(int actorId)
        {
            using (var db = new MoviesDbContext(_config))
            {
                return (from application in db.ActorMovieApplications
                        where application.ActorId == actorId &&
                            application.IsAcceptedByActor &&
                            application.IsAcceptedByDirector
                        from movie in db.Movies
                        where movie.Id == application.MovieId
                        select new MovieDto(movie)).ToList();
            }
        }

        public void InviteActor(InviteActorCommand command)
        {
            using (var db = new MoviesDbContext(_config))
            {
                var wantedActor = (from actor in db.Users
                                   where actor.Id == command.ActorId
                                   select actor).SingleOrDefault();

                var selectedMovie = (from movie in db.Movies
                                     where movie.Id == command.MovieId
                                     select movie).SingleOrDefault();

                var invitedActors = (from application in db.ActorMovieApplications
                                     where application.MovieId == command.MovieId && application.IsAcceptedByDirector
                                     from actors in db.Users
                                     where actors.Id == application.ActorId
                                     select actors).ToList();

                if (selectedMovie.Budget >= wantedActor.ExpectedSalary + invitedActors.Sum(actor => actor.ExpectedSalary))
                {
                    db.ActorMovieApplications.Add(command.ToActorMovieApplication());
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Insufficient movie budget");
                }
            }
        }

        public IEnumerable<MovieDto> GetAppliableMovies(int actorId)
        {
            using (var db = new MoviesDbContext(_config))
            {
                var intendedActor = (from actor in db.Users
                                   where actor.Id == actorId
                                   select actor).SingleOrDefault();

                return from movie in db.Movies
                       where movie.Budget - intendedActor.ExpectedSalary >
                          (from app in db.ActorMovieApplications
                           where app.MovieId == movie.Id
                           join actor in db.Users on app.ActorId equals actor.Id
                           select actor.ExpectedSalary).Sum()
                       select new MovieDto(movie);
            }
        }
    }
}
