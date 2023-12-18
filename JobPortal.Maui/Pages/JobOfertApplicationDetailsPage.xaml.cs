using JobPortal.Maui.ViewModels;

namespace JobPortal.Maui.Pages;

public partial class JobOfertApplicationDetailsPage : ContentPage
{
	JobOfertApplicationDetailsPageViewModel vm;
    public JobOfertApplicationDetailsPage(JobOfertApplicationDetailsPageViewModel jobOfertApplicationDetailsPageViewModel)
	{
		InitializeComponent();
		BindingContext = jobOfertApplicationDetailsPageViewModel;
		vm = jobOfertApplicationDetailsPageViewModel;
	}
}