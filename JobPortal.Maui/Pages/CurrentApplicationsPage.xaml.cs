using JobPortal.Maui.ViewModels;
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
}