using JobPortal.Maui.ViewModels;
using System.ComponentModel;

namespace JobPortal.Maui.Pages;

public partial class JobOfertPage : ContentPage
{
	JobOfertPageViewModel vm;
	public JobOfertPage(JobOfertPageViewModel vm)
	{
		BindingContext = vm;
		this.vm = vm;
		InitializeComponent();
		categoryGrid.Children.Remove(categoryLayout);
		vm.PropertyChanged += OnViewModelPropertyChanged;
	}

    private void CategoryPicker_Changed(object sender, EventArgs e)
    {
		Picker picker = sender as Picker;
		if(picker.SelectedItem.ToString() == "inna")
		{
            categoryGrid.Children.Add(categoryLayout);
        }
        if (picker.SelectedItem.ToString() != "inna")
        {
			if (categoryGrid.Children.Contains(categoryLayout))
			{
				categoryGrid.Children.Remove(categoryLayout);
			}
        }
    }

    private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
	{

	}

    private void RemoveCategory_Click(object sender, EventArgs e)
    {
		string categoryName = (string)(sender as ImageButton).CommandParameter;
		vm.JobOfertCategories.RemoveAt(vm.JobOfertCategories.IndexOf(vm.JobOfertCategories.Where(x => x.CategoryName == categoryName).FirstOrDefault()));
    }

    private void RemoveRequirement_Click(object sender, EventArgs e)
    {
        string requirementName = (string)(sender as ImageButton).CommandParameter;
        vm.JobOfertRequirements.RemoveAt(vm.JobOfertRequirements.IndexOf(vm.JobOfertRequirements.Where(x => x.RequirementName == requirementName).FirstOrDefault()));
    }

    private void RemoveDuty_Click(object sender, EventArgs e)
    {
        string dutyName = (string)(sender as ImageButton).CommandParameter;
        vm.JobOfertDuties.RemoveAt(vm.JobOfertDuties.IndexOf(vm.JobOfertDuties.Where(x => x.DutyName == dutyName).FirstOrDefault()));
    }

    private void RemoveBenefit_Click(object sender, EventArgs e)
    {
        string benefitName = (string)(sender as ImageButton).CommandParameter;
        vm.JobOfertBenefits.RemoveAt(vm.JobOfertBenefits.IndexOf(vm.JobOfertBenefits.Where(x => x.BenefitName == benefitName).FirstOrDefault()));
    }
}