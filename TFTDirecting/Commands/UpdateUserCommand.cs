using TFTDirecting.Database;

namespace TFTDirecting.Commands
{
    public class UpdateUserCommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public double ExpectedSalary { get; set; }

        public User ToUser(int userId)
        {
            return new User
            {
                Id = userId,
                Name = Name,
                Surname = Surname,
                Address = Address,
                ExpectedSalary = ExpectedSalary
            };
        }

        public void UpdateUser(User? user)
        {
            if (user == null) return;
            
            user.Name = Name;
            user.Surname = Surname;
            user.Address = Address;
            user.ExpectedSalary = ExpectedSalary;
        }
    }
}
