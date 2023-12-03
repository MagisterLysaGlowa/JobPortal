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

        /*UI CHANGES RELATED WITH VIEWMODEL*/

        if (!vm.CurrentlyWorking)
        {
            workLayout.Children.Remove(workGrid);
        }

        if (!vm.CarrierYes)
        {
            carrierLayout.Children.Remove(carrierGrid);
        }
    }

    /*SET VISIBLITY OF GRID*/
    private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        /*WORK GRID*/
        if (e.PropertyName == nameof(vm.CurrentlyWorking))
        {
            if (vm.CurrentlyWorking)
            {
                workLayout.Children.Add(workGrid);
            }
            else
            {
                workLayout.Children.Remove(workGrid);
            }
        }

        /*CARRIER GRID*/
        if (e.PropertyName == nameof(vm.CarrierYes))
        {
            if (vm.CarrierYes)
            {
                carrierLayout.Children.Add(carrierGrid);
            }
            else
            {
                carrierLayout.Children.Remove(carrierGrid);
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

    private void Carrier_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            if (BindingContext is ProfilePageViewModel viewModel)
            {
                viewModel.ToggleCheckedCarrier();
            }
        }
    }
}