using Practics.DemoExam.Models.Base;

namespace Practics.DemoExam.Models
{
    public class OrderProduct : Entity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}