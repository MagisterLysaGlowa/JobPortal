using JobPortal.Maui.ViewModels;

namespace JobPortal.Maui.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfilePageViewModel profilePageViewModel)
	{
		InitializeComponent();
		BindingContext = profilePageViewModel;
	}
}