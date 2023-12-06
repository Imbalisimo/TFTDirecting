using TFTDirecting.Commands;
using TFTDirecting.Contracts;
using TFTDirecting.Dtos;

namespace TFTDirecting.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddUser(AddUserCommand command)
        {
            _userRepository.AddUser(command);
        }

        public UserDto GetUserByCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserData(int actorId)
        {
            return new UserDto(_userRepository.GetUserData(actorId));
        }

        public void UpdateUserData(int actorId, UpdateUserCommand command)
        {
            _userRepository.UpdateUserData(actorId, command);
        }
    }
}
