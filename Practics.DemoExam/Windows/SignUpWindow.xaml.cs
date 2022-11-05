using System.Windows;
using Practics.DemoExam.Extensions;
using Practics.DemoExam.Models;
using Practics.DemoExam.Services;

namespace Practics.DemoExam.Windows
{
    public partial class SignUpWindow : Window
    {
        private readonly LoginService _loginService;
        
        public SignUpWindow(LoginService loginService)
        {
            _loginService = loginService;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            InitializeComponent();
        }

        private User InitializeUserFromInputs()
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;

            string lastName = LastNameTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string middleName = MiddleNameTextBox.Text;

            return new User(login, password, lastName, firstName, middleName);
        }

        private void SignUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            User user = InitializeUserFromInputs();

            bool result = _loginService.Register(user);

            if (!result)
                ControlExtensions.MessageBoxError("Ошибка", "Проверьте корректность ввода");
            
            Close();
        }
    }
}