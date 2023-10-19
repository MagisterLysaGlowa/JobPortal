using JobPortal.Maui.ViewModels;

namespace JobPortal.Maui.Pages;

public partial class WelcomePage : ContentPage
{
	public WelcomePage(WelcomePageViewModel welcomePageViewModel)
	{
		InitializeComponent();
		BindingContext = welcomePageViewModel;
	}
}