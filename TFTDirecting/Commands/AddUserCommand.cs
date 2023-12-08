using TFTDirecting.Database;

namespace TFTDirecting.Commands
{
    public class AddUserCommand: UpdateUserCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public User ToUser()
        {
            var user = ToUser(0);
            user.Username = Username;
            user.Password = Password;
            user.Role = Role;
            return user;
        }
    }
}
