using Practics.DemoExam.Enums;
using Practics.DemoExam.Models.Base;

namespace Practics.DemoExam.Models
{
    public class User : Entity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        
        public string Login { get; set; }
        public string Password { get; set; }
        
        public Role Role { get; set; }
        
        public User() { }

        public User(string login, string password, string lastName, string firstName, string middleName)
        {
            Login = login;
            Password = password;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Role = Role.CLIENT;
        }
    }
}