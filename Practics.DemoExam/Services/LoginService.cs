using System.Linq;
using Practics.DemoExam.Models;

namespace Practics.DemoExam.Services
{
    public class LoginService
    {
        private readonly UserService _userService;

        public LoginService(UserService userService)
        {
            _userService = userService;
        }

        public bool Login(string login, string password)
        {
            User user = _userService.Read().FirstOrDefault(entity => entity.Login == login);

            return user != null && string.Equals(password, user.Password);
        }

        public bool Register(User user)
        {
            return _userService.Create(user) != null;
        }
    }
}