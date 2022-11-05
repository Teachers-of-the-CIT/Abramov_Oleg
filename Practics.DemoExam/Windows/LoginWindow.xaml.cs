using System.Windows;
using Practics.DemoExam.Contexts;
using Practics.DemoExam.Extensions;
using Practics.DemoExam.Services;

namespace Practics.DemoExam.Windows
{
    public partial class LoginWindow : Window
    {
        private readonly ApplicationContext _context;
        private readonly ProductService _productService;
        private readonly LoginService _loginService;
        private readonly UserService _userService;
        
        public LoginWindow()
        {
            _context = new ApplicationContext();
            _userService = new UserService(_context);
            _loginService = new LoginService(_userService);
            _productService = new ProductService(_context);
            
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        private void TryLoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            (string login, string password) = GetLoginFromInput();
            
            bool result = _loginService.Login(login, password);

            if (!result)
            {
                ControlExtensions.MessageBoxError("Ошибка", "Проверьте введенные данные");
                
                return;
            }
            
            
            this.OpenWindow<ProductWindow>(_productService);
            
            Visibility = Visibility.Hidden;
        }

        private void SignUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.OpenWindow<SignUpWindow>(_loginService);
        }

        private (string login, string password) GetLoginFromInput()
        {
            return (LoginTextBox.Text, PasswordTextBox.Password);
        }

        private void LoginWithoutCredentialsButton_OnClick(object sender, RoutedEventArgs e)
        {
            bool result = ControlExtensions.MessageBoxChoose
            (
                "Вы уверены, что хотите продолжить просмотр товаров без регистрации? " +
                "Информация о ваших сделанных заказах будет недоступна при следующем входе!"
            );
            
            if (!result)
                return;
            
            this.OpenWindow<ProductWindow>(_productService);
            
            Visibility = Visibility.Hidden;
        }
    }
}