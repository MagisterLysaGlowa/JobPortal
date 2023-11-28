using JobPortal.Maui.ViewModels;
using System.ComponentModel;

namespace JobPortal.Maui.Pages;

public partial class ProfilePage : ContentPage
{
    private ProfilePageViewModel vm;
    public ProfilePage(ProfilePageViewModel profilePageViewModel)
	{
		InitializeComponent();
		BindingContext = profilePageViewModel;
        vm = profilePageViewModel;
        vm.PropertyChanged += OnViewModelPropertyChanged;
	}

    /*SET VISIBLITY OF CURRENT WORK GRID*/
    private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(vm.CurrentlyWorking))
        {
            if (vm.CurrentlyWorking)
            {
                testLayout.Children.Add(myGridTest);
            }
            else
            {
                testLayout.Children.Remove(myGridTest);
            }
        }
    }

    private void CurrentWork_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            if (BindingContext is ProfilePageViewModel viewModel)
            {
                viewModel.ToggleCheckedCurrentlyWorking();
            }
        }
    }
}