using JobPortal.Maui.ViewModels;

namespace JobPortal.Maui.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel homePageViewModel)
	{
		InitializeComponent();
        BindingContext = homePageViewModel;
    }
}