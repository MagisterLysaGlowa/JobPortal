using JobPortal.Maui.Model;
using JobPortal.Maui.ViewModels;
using Newtonsoft.Json;

namespace JobPortal.Maui.Pages;

public partial class OfertDetailsPage : ContentPage
{
    OfertDetailsPageViewModel vm;
    public OfertDetailsPage(OfertDetailsPageViewModel ofertDetailsPageViewModel)
	{
		InitializeComponent();
        BindingContext = ofertDetailsPageViewModel;
        vm = ofertDetailsPageViewModel;
        if(App.user.Access == "admin")
        {
            OfertDeleteButton.IsVisible = true;
        }
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await vm.SetupDetailPage();
        ((IView)measureBorderFix).InvalidateMeasure();
        ((IView)measureGridFix).InvalidateMeasure();
    }
}
