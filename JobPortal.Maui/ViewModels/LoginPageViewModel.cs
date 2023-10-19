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
        private string _email;
        [ObservableProperty]
        private string _password;
        readonly IUserRepository userService = new UserService();

        [RelayCommand]
        public async Task Login()
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
                {
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
                    App.user = user;
                    await Shell.Current.DisplayAlert("Loged", $"User loged as {user.Email}", "Ok");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "All fields required", "Ok");
                    return;
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return;
            }
        }
    }
}
