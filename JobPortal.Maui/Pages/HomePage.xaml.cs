using JobPortal.Maui.Model;
using JobPortal.Maui.ViewModels;
using System.Collections.ObjectModel;

namespace JobPortal.Maui.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel homePageViewModel)
	{
		InitializeComponent();
        BindingContext = homePageViewModel;
    }
}