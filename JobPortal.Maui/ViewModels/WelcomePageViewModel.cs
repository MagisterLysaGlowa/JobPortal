using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JobPortal.Maui.Pages;

namespace JobPortal.Maui.ViewModels
{
    public partial class WelcomePageViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task NavigateLoginPage()
        {
            await Shell.Current?.GoToAsync("//loginPage");
        }

        [RelayCommand]
        public async Task NavigateRegisterPage()
        {
            await Shell.Current?.GoToAsync("//registerPage");
        }
    }
}
