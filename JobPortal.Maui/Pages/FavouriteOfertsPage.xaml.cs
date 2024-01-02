using JobPortal.Maui.Model;
using JobPortal.Maui.ViewModels;
using Newtonsoft.Json;

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

    private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is JobOfert tappedJobOfert)
        {
            string serializedObject = JsonConvert.SerializeObject(tappedJobOfert);
            await Shell.Current.GoToAsync($"//ofertDetailsPage", new Dictionary<string, object>
            {
                ["JobOfert"] = tappedJobOfert
            });
        }

    ((ListView)sender).SelectedItem = null;
    }
}