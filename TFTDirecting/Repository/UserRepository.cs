using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Database;

namespace TFTDirecting.Repository
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(AddUserCommand command)
        {
            throw new NotImplementedException();
        }

        public User GetUserData(int actorId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserData(int actorId, UpdateUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
