using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Database;
using TFTDirecting.Dtos;

namespace TFTDirecting.Repository
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(AddUserCommand command)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserByCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserData(int actorId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserData(int actorId, UpdateUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
