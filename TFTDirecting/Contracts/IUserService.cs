using TFTDirecting.Commands;
using TFTDirecting.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TFTDirecting.Contracts
{
    public interface IUserService
    {
        UserDto GetUserData(int actorId);
        void AddUser(AddUserCommand command);
        void UpdateUserData(int actorId, UpdateUserCommand command);
    }
}
