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
}