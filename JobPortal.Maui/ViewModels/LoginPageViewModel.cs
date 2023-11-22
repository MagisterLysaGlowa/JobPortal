using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JobPortal.Maui.Repository;
using JobPortal.Maui.Model;
using Newtonsoft.Json;

namespace JobPortal.Maui.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string email = "kacperr@wp.pl";
        [ObservableProperty]
        private bool emailError = false;
        [ObservableProperty]
        private string emailErrorText;

        [ObservableProperty]
        private string password = "Dol@r12345";
        [ObservableProperty]
        private bool passwordError;
        [ObservableProperty]
        private string passwordErrorText;
        readonly IUserRepository userService = new UserService();

        [RelayCommand]
        public async Task Login()
        {
            try
            {
                bool correct = true;
                /*EMAIL VALIDATION*/
                if (String.IsNullOrWhiteSpace(Email))
                {
                    EmailError = true;
                    EmailErrorText = "Niepoprawny email";
                    correct = false;
                }
                else
                {
                    EmailError = false;
                    EmailErrorText = "";
                }

                /*PASSWORD VALIDATION*/
                if (String.IsNullOrWhiteSpace(Password))
                {
                    PasswordError = true;
                    PasswordErrorText = "Niepoprawne hasło";
                    correct = false;
                }
                else
                {
                    PasswordError = false;
                    PasswordErrorText = "";
                }

                if (!correct) return;

                User user = await userService.Login(Email, Password);
                if(user == null)
                {
                    await Shell.Current.DisplayAlert("Error", "Username/Password is incorrect", "Ok");
                    return;
                }
                if (Preferences.ContainsKey(nameof(App.user)))
                {
                    Preferences.Remove(nameof(App.user));
                }
                string userDetails = JsonConvert.SerializeObject(user);
                Preferences.Set(nameof(App.user), userDetails);
                AppShell.User = user;
                App.user = user;
                await Shell.Current?.GoToAsync("//homePage");

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return;
            }
        }
    }
}
