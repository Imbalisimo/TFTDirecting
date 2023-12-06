using TFTDirecting.Database;

namespace TFTDirecting.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public double ExpectedSalary { get; set; }


        public UserDto(User user)
        {
            if (user != null)
            {
                Id = user.Id;
                Username = user.Username;
                Password = user.Password;
                Role = user.Role;
                Name = user.Name;
                Surname = user.Surname;
                Address = user.Address;
                ExpectedSalary = user.ExpectedSalary;
            }
        }
    }
}
