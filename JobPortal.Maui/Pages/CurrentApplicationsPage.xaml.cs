using JobPortal.Maui.Model;
using JobPortal.Maui.ViewModels;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JobPortal.Maui.Pages;

public partial class CurrentApplicationsPage : ContentPage
{
	CurrentApplicationsViewModel vm;
    public CurrentApplicationsPage(CurrentApplicationsViewModel currentApplicationsViewModel)
	{
		InitializeComponent();
		BindingContext = currentApplicationsViewModel;
		vm = currentApplicationsViewModel;
	}

    private async void DeleteApplication_Clicked(object sender, EventArgs e)
    {
        int jobOfertId = (int)(sender as Button).CommandParameter;
        await vm.DeleteUserJobOfertApplication(jobOfertId);
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await vm.SetupCurrentApplications();
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