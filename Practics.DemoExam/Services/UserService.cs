using Practics.DemoExam.Contexts;
using Practics.DemoExam.Models;
using Practics.DemoExam.Services.Base;

namespace Practics.DemoExam.Services
{
    public class UserService : EntityService<User>
    {
        public UserService(ApplicationContext context) : base(context) { }
    }
}