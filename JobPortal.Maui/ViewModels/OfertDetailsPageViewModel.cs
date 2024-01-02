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
        [ObservableProperty]
        bool applicationIsPossible;
        [ObservableProperty]
        bool favouriteIsPossible = true;
        [ObservableProperty]
        string buttonImageSource;

        /*REPOSITORY INITALIZATION*/
        IRequirementRepository requirementService = new RequirementService();
        IJobOfertRepository jobOfertService = new JobOfertService();
        IBenefitRepository benefitService = new BenefitService();
        IDutyRepository dutyService = new DutyService();
        IUserRepository userService = new UserService();

        /*UTILITY PROPERTIES*/
        User User { get; set; }
        public OfertDetailsPageViewModel()
        {
            User = App.user;
        }

        public async Task SetupDetailPage()
        {
            await Task.Delay(100);
            Duties = await dutyService.GetDuties(JobOfert.Id);
            Requirements = await requirementService.GetRequirements(JobOfert.Id);
            Benefits = await benefitService.GetBenefits(JobOfert.Id);
            var applicationsList = await userService.GetUserJobOfertApplications(User.Id);
            bool currentlyApplicated = applicationsList.Any(x => x.JobOfertId == JobOfert.Id);
            ApplicationIsPossible = !currentlyApplicated;

            if(App.user.Access == "employer" || App.user.Access == "admin")
            {
                ApplicationIsPossible = false;
                FavouriteIsPossible = false;
            }

            var favouritiesList = await userService.GetUserJobOfertFavourites(User.Id);
            bool isCurrentlyFavourite = favouritiesList.Any(x => x.JobOfertId == JobOfert.Id);
            ButtonImageSource = isCurrentlyFavourite ? "heart_fill_icon.png" : "heart_icon.png";
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

        [RelayCommand]
        private async Task ToggleOfertToFavourites()
        {
            var favouritiesList = await userService.GetUserJobOfertFavourites(User.Id);
            bool isCurrentlyFavourite = favouritiesList.Any(x => x.JobOfertId == JobOfert.Id);
            if (isCurrentlyFavourite)
            {
                await userService.RemoveUserJobOfertFavourite(User.Id,JobOfert.Id);
            }
            else
            {
                await userService.PostUserJobOfertFavourite(User.Id, JobOfert);
            }
            ButtonImageSource = isCurrentlyFavourite ? "heart_icon.png" : "heart_fill_icon.png";
        }

        [RelayCommand]
        private async Task DeleteJobOfert()
        {
            bool delete = await Shell.Current.DisplayAlert("Usuwanie oferty", "Czy napewno chcesz usunąć ofertę?", "Tak", "Nie");
            if(delete)
            {
                await jobOfertService.DeleteJobOfert(JobOfert.Id);
                await Shell.Current.GoToAsync("//homePage");
            }
        }
    }
}
