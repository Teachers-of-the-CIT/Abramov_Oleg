using Practics.DemoExam.Contexts;
using Practics.DemoExam.Models;
using Practics.DemoExam.Services.Base;

namespace Practics.DemoExam.Services
{
    public class ProductService : EntityService<Product>
    {
        public ProductService(ApplicationContext context) : base(context) { }
    }
}