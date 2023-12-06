using TFTDirecting.Commands;
using TFTDirecting.Database;
using TFTDirecting.Dtos;

namespace TFTDirecting.Contracts
{
    public interface IUserRepository
    {
        void AddUser(AddUserCommand command);
        User GetUserData(int actorId);
        void UpdateUserData(int actorId, UpdateUserCommand command);
    }
}
