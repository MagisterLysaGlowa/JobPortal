using JobPortal.Maui.ViewModels;

namespace JobPortal.Maui.Pages;

public partial class LogoutPage : ContentPage
{
	private LogoutPageViewModel vm;
	public LogoutPage(LogoutPageViewModel logoutPageViewModel)
	{
		InitializeComponent();
		BindingContext = logoutPageViewModel;
		vm = logoutPageViewModel;
	}

    protected async override void OnAppearing()
    {
		await Task.Delay(50);
		App.user = null;
		await Shell.Current.GoToAsync("//loginPage");
    }
}