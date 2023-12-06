using JobPortal.Maui.Model;
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

        /*RESTART PROPERTIES GRID*/
        vm.PropertyChanged += OnViewModelPropertyChanged;
        experienceLayout.Children.Remove(experienceGrid);
        educationLayout.Children.Remove(educationGrid);
        languageLayout.Children.Remove(languageGrid);

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

        if(e.PropertyName == nameof(vm.ExperiencesList))
        {
            experienceListLayout.HeightRequest = vm.ExperiencesList.Count * 200;
            experienceListLayout.Remove(experienceListControll);
            experienceListLayout.Add(experienceListControll);
        }
        if (e.PropertyName == nameof(vm.EducationsList))
        {
            educationListLayout.HeightRequest = vm.EducationsList.Count * 200;
            educationListLayout.Remove(educationListControll);
            educationListLayout.Add(educationListControll);
        }
        if (e.PropertyName == nameof(vm.LanguagesList))
        {
            languageListLayout.HeightRequest = vm.LanguagesList.Count * 200;
            languageListLayout.Remove(languageListControll);
            languageListLayout.Add(languageListControll);
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

    private void DisplayExperienceGrid_Clicked(object sender, EventArgs e)
    {
        experienceLayout.Children.Add(experienceGrid);
    }

    private void HideExperienceGrid_Clicked(object sender, EventArgs e)
    {
        experienceLayout.Children.Remove(experienceGrid);
    }

    private async void DeleteExperience_Click(object sender, EventArgs e)
    {
        int experienceId = (int)(sender as Button).CommandParameter;
        await vm.DeleteExperience(experienceId);
    }

    private void DisplayEducationGrid_Clicked(object sender, EventArgs e)
    {
        educationLayout.Children.Add(educationGrid);
    }
    private void HideEducationGrid_Clicked(object sender, EventArgs e)
    {
        educationLayout.Children.Remove(educationGrid);
    }

    private async void DeleteEducation_Click(object sender, EventArgs e)
    {
        int educationId = (int)(sender as Button).CommandParameter;
        await vm.DeleteEducation(educationId);
    }

    private async void DeleteLanguage_Click(object sender, EventArgs e)
    {
        int languageId = (int)(sender as Button).CommandParameter;
        await vm.DeleteLanguage(languageId);
    }

    private void HideLanguagesGrid_Clicked(object sender, EventArgs e)
    {
        languageLayout.Children.Remove(languageGrid);
    }

    private void DisplayLanguageGrid_Clicked(object sender, EventArgs e)
    {
        languageLayout.Children.Add(languageGrid);
    }
}