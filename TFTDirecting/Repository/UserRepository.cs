using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Database;
using TFTDirecting.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TFTDirecting.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        public UserRepository(IConfiguration config)
        {
            _config = config;
        }

        public void AddUser(AddUserCommand command)
        {
            using (var db = new MoviesDbContext(_config))
            {
                db.Users.Add(command.ToUser());
                db.SaveChanges();
            }
        }

        public UserDto GetUserByCredentials(string username, string password)
        {
            using (var db = new MoviesDbContext(_config))
            {
                var u = (from user in db.Users
                       where user.Username == username && user.Password == password
                       select user).SingleOrDefault();

                return new UserDto(u);
            }
        }

        public UserDto GetUserData(int actorId)
        {
            using (var db = new MoviesDbContext(_config))
            {
                var u = (from user in db.Users
                         where user.Id == actorId
                         select user).SingleOrDefault();

                return new UserDto(u);
            }
        }

        public void UpdateUserData(int actorId, UpdateUserCommand command)
        {
            using (var db = new MoviesDbContext(_config))
            {
                var isActorCurrentlyActing = IsActorCurrentlyActing(actorId);

                if (isActorCurrentlyActing)
                {
                    var updatingUser = (from u in db.Users
                                        where u.Id == actorId
                                        select u).SingleOrDefault();

                    command.UpdateUser(updatingUser);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Unable to update user as they are currenly starring in an ongoing movie");
                }
            }
        }

        public bool IsActorCurrentlyActing(int actorId)
        {
            using (var db = new MoviesDbContext(_config))
            {
                return (from movie in db.Movies
                        where movie.Actors.Any(actor => actor.Id == actorId) && movie.EndingDate < DateTime.Now
                        select movie).Any();
            }
        }
    }
}
