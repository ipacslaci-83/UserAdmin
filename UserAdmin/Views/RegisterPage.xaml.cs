using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserAdmin.Models;
using UserAdmin.Services;

namespace UserAdmin.Views
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private readonly UserDbService _userdbservice = new UserDbService();
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void Login_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            ErrorText.Visibility = Visibility.Collapsed;
            ErrorText.Text = string.Empty;

            var username = UsernameBox.Text.Trim();
            var email = EmailBox.Text.Trim();
            var password = PasswordBoxInput.Password;
            var confirmpassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmpassword))
            {
                ErrorText.Text = "Minden mező kitöltése kötelező";
                ErrorText.Visibility = Visibility.Visible;
                return;
            }
           

            if (password.Length < 6)
            {
                ErrorText.Text = "Túl rövid a jelszó";
                ErrorText.Visibility = Visibility.Visible;
                return;
            }
            
            
            if (password != confirmpassword)
            {
                ErrorText.Text = "Nem egyezik a jelszó";
                ErrorText.Visibility = Visibility.Visible;
                return;
            }
            

            
            var user = new User
            {
                UserName = username,
                Email = email,
                Password = password,
                RegisteredAt = DateTime.Now
            };

            _userdbservice.Add(user);

            MessageBox.Show("Sikeres regisztráció!");
        }
    }
}
