using Practics.DemoExam.Models.Base;

namespace Practics.DemoExam.Models
{
    public class Product : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        
        public decimal Discount { get; set; }
        
        public Product() { }

        public Product(string title, string description, string manufacturer, decimal price, decimal discount)
        {
            Title = title;
            Description = description;
            Manufacturer = manufacturer;
            Price = price;
            Discount = discount;
        }
    }
}