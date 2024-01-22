using HRSOFT.Domain.Common.Models;

namespace HRSOFT.Domain.Common
{
    public class User : AggregateRootIdentity
    {
        public int Id { get; init; }
        public string PrivateNumber { get; init; }
        public string Name { get; init; }
        public string LastName { get; init; }
        public DateTime DateOfBirht { get; init; }
        public string Password { get; init; }
        public string RepeatPassword { get; init; }

        public User()
        {

        }

        private User(string privateNumber, string name, string userName, string lastName, DateTime dateOfBirht, string email, string password, string repeatPassword)
        {
            PrivateNumber = privateNumber;
            Name = name;
            LastName = lastName;
            DateOfBirht = dateOfBirht;
            Email = email;
            UserName = userName;
            Password = password;
            RepeatPassword = repeatPassword;
            //EmailConfirmed = true;
        }

        public static User Create(string privateNumber, string name, string userName, string lastName, DateTime dateOfBirht, string email, string password, string repeatPassword)
        {
            return new User(privateNumber, name, userName, lastName, dateOfBirht, email, password, repeatPassword);
        }
    }
}
