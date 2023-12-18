using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JobPortal.Maui.Model;
using JobPortal.Maui.Repository;

namespace JobPortal.Maui.ViewModels
{
    [QueryProperty(nameof(JobOfert),nameof(JobOfert))]
    public partial class OfertDetailsPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private JobOfert jobOfert;

        [ObservableProperty]
        List<Duty> duties;
        [ObservableProperty]
        List<Requirement> requirements;
        [ObservableProperty]
        List<Benefit> benefits;


        /*UI PROPERTIES TO CORRECT DISPLAY*/
        [ObservableProperty]
        string benefitName;
        [ObservableProperty]
        string requirementName;
        [ObservableProperty]
        string dutyName;

        /*REPOSITORY INITALIZATION*/
        IRequirementRepository requirementService = new RequirementService();
        IJobOfertRepository jobOfertService = new JobOfertService();
        IBenefitRepository benefitService = new BenefitService();
        IDutyRepository dutyService = new DutyService();

        public OfertDetailsPageViewModel()
        {

        }

        public async Task SetupDetailPage()
        {
            Duties = await dutyService.GetDuties(JobOfert.Id);
            Requirements = await requirementService.GetRequirements(JobOfert.Id);
            Benefits = await benefitService.GetBenefits(JobOfert.Id);
        }

        [RelayCommand]
        private async Task NavigateToJobOfertApplication()
        {
            await Shell.Current.GoToAsync("//jobOfertApplicationDetailsPage", new Dictionary<string, object>
            {
                ["JobOfert"] = JobOfert,
                ["UserId"] = App.user.Id,
            });
        }
    }
}
