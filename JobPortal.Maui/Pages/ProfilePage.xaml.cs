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
        abilityLayout.Children.Remove(abilityGrid);
        courseLayout.Children.Remove(courseGrid);
        linkLayout.Children.Remove(linkGrid);
        Task.Delay(100);
        ((IView)scrollViewControll).InvalidateMeasure();
        ((IView)basicInfoGrid).InvalidateMeasure();
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
            ((IView)scrollViewControll).InvalidateMeasure();
            ((IView)experienceLayout).InvalidateMeasure();
        }
        if (e.PropertyName == nameof(vm.EducationsList))
        {
            ((IView)scrollViewControll).InvalidateMeasure();
            ((IView)educationLayout).InvalidateMeasure();
        }
        if (e.PropertyName == nameof(vm.LanguagesList))
        {
            ((IView)scrollViewControll).InvalidateMeasure();
            ((IView)languageLayout).InvalidateMeasure();
        }
        if (e.PropertyName == nameof(vm.AbilitiesList))
        {
            ((IView)scrollViewControll).InvalidateMeasure();
            ((IView)abilityLayout).InvalidateMeasure();
        }
        if (e.PropertyName == nameof(vm.CoursesList))
        {
            ((IView)scrollViewControll).InvalidateMeasure();
            ((IView)courseLayout).InvalidateMeasure();
        }
        if (e.PropertyName == nameof(vm.LinksList))
        {
            ((IView)scrollViewControll).InvalidateMeasure();
            ((IView)linkLayout).InvalidateMeasure();
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
        experienceGridButton.IsVisible = false;
    }

    private void HideExperienceGrid_Clicked(object sender, EventArgs e)
    {
        experienceLayout.Children.Remove(experienceGrid);
        experienceGridButton.IsVisible = true;
    }

    private async void DeleteExperience_Click(object sender, EventArgs e)
    {
        int experienceId = (int)(sender as Button).CommandParameter;
        await vm.DeleteExperience(experienceId);
    }

    private void DisplayEducationGrid_Clicked(object sender, EventArgs e)
    {
        educationLayout.Children.Add(educationGrid);
        educationGridButton.IsVisible = false;
    }
    private void HideEducationGrid_Clicked(object sender, EventArgs e)
    {
        educationLayout.Children.Remove(educationGrid);
        educationGridButton.IsVisible = true;
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
        languageGridButton.IsVisible = true;
    }

    private void DisplayLanguageGrid_Clicked(object sender, EventArgs e)
    {
        languageLayout.Children.Add(languageGrid);
        languageGridButton.IsVisible = false;
    }

    private void DisplayAbilityGrid_Clicked(object sender, EventArgs e)
    {
        abilityLayout.Children.Add(abilityGrid);
        abilityGridButton.IsVisible = false;
    }

    private void HideAbilityGrid_Clicked(object sender, EventArgs e)
    {
        abilityLayout.Children.Remove(abilityGrid);
        abilityGridButton.IsVisible = true;
    }

    private async void DeleteAbility_Click(object sender, EventArgs e)
    {
        int abilityId = (int)(sender as Button).CommandParameter;
        await vm.DeleteAbility(abilityId);
    }

    private async void DeleteCourse_Click(object sender, EventArgs e)
    {
        int couseId = (int)(sender as Button).CommandParameter;
        await vm.DeleteCourse(couseId);
    }

    private void HideCourseGrid_Clicked(object sender, EventArgs e)
    {
        courseLayout.Children.Remove(courseGrid);
        courseGridButton.IsVisible = true;
    }

    private void DisplayCourseGrid_Clicked(object sender, EventArgs e)
    {
        courseLayout.Children.Add(courseGrid);
        courseGridButton.IsVisible = false;
    }

    private async void DeleteLink_Click(object sender, EventArgs e)
    {
        int linkId = (int)(sender as Button).CommandParameter;
        await vm.DeleteLink(linkId);
    }

    private void HideLinkGrid_Clicked(object sender, EventArgs e)
    {
        linkLayout.Children.Remove(linkGrid);
        linkGridButton.IsVisible = true;
    }

    private void DisplayLinkGrid_Clicked(object sender, EventArgs e)
    {
        linkLayout.Children.Add(linkGrid);
        linkGridButton.IsVisible = false;
    }
}