using JobPortal.Maui.Model;
using JobPortal.Maui.ViewModels;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace JobPortal.Maui.Pages;

public partial class HomePage : ContentPage
{

    private HomePageViewModel vm;
    private bool filterIsVisible = false;
    public HomePage(HomePageViewModel homePageViewModel)
	{
		InitializeComponent();
        BindingContext = homePageViewModel;
        vm = homePageViewModel;
        filterBorder.IsVisible = filterIsVisible;
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

    // Prevent default selection highlight
    ((ListView)sender).SelectedItem = null;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.SetUpHomePageInfo();
    }

    private void ToggleFilter_Click(object sender, EventArgs e)
    {
        filterIsVisible = !filterIsVisible;
        filterBorder.IsVisible = filterIsVisible;
    }
}