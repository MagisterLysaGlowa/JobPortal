using JobPortal.Maui.ViewModels;

namespace JobPortal.Maui.Pages;

public partial class FavouriteOfertsPage : ContentPage
{
	FavouriteOfertsPageViewModel vm;
	public FavouriteOfertsPage(FavouriteOfertsPageViewModel favouriteOfertsPageViewModel)
	{
		InitializeComponent();
		BindingContext = favouriteOfertsPageViewModel;
		vm = favouriteOfertsPageViewModel;
	}

    private async void DeleteFavourite_Clicked(object sender, EventArgs e)
    {
        int jobOfertId = (int)(sender as Button).CommandParameter;
        await vm.DeleteUserJobOfertFavourite(jobOfertId);
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await vm.SetupFavourites();
    }
}