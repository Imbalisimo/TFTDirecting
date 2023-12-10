using TFTDirecting.Contracts;
using TFTDirecting.Database;
using TFTDirecting.Dtos;

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
    }
}
