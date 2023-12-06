using TFTDirecting.Commands;
using TFTDirecting.Database;
using TFTDirecting.Dtos;

namespace TFTDirecting.Contracts
{
    public interface IUserRepository
    {
        void AddUser(AddUserCommand command);
        UserDto GetUserByCredentials(string username, string password);
        UserDto GetUserData(int actorId);
        void UpdateUserData(int actorId, UpdateUserCommand command);
    }
}
