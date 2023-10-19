using JobPortal.Maui.ViewModels;

namespace JobPortal.Maui.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
		BindingContext = loginPageViewModel;
	}
}