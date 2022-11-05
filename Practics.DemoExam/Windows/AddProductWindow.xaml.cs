using System.Windows;
using Practics.DemoExam.Extensions;
using Practics.DemoExam.Models;
using Practics.DemoExam.Services;

namespace Practics.DemoExam.Windows
{
    public partial class AddProductWindow : Window
    {
        private readonly ProductWindow _parentWindow;
        private readonly ProductService _productService;
        
        public AddProductWindow(ProductService productService, ProductWindow parentWindow)
        {
            _productService = productService;
            _parentWindow = parentWindow;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            InitializeComponent();
        }

        private void AddProductButton_OnClick(object sender, RoutedEventArgs e)
        {
            Product product = FillProductFromInputs();

            if (product == null)
            {
                ControlExtensions.MessageBoxError("Ошибка", "Проверьте правильность информации");
                
                return;
            }

            _productService.Create(product);
            
            _parentWindow.RefreshProducts();
            Close();
        }

        private Product FillProductFromInputs()
        {
            string title = TitleTextBox.Text;
            string description = DescriptionTextBox.Text;
            string manufacturer = ManufacturerTextBox.Text;

            bool isPrice = decimal.TryParse(PriceTextBox.Text, out decimal price);

            if (!isPrice)
                return null;
            
            bool isDiscount = decimal.TryParse(DiscountTextBox.Text, out decimal discount);

            return !isDiscount 
                ? null 
                : new Product(title, description, manufacturer, price, discount);
        }
    }
}