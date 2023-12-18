using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JobPortal.Maui.Model;
using JobPortal.Maui.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.ViewModels
{
    [QueryProperty(nameof(JobOfert),nameof(JobOfert))]
    [QueryProperty(nameof(UserId), nameof(UserId))]
    public partial class JobOfertApplicationDetailsPageViewModel : ObservableObject
    {
        [ObservableProperty]
        JobOfert jobOfert;
        [ObservableProperty]
        int userId;

        [ObservableProperty]
        string name;
        [ObservableProperty]
        string surname;
        [ObservableProperty] 
        string email;
        [ObservableProperty] 
        string phone;
        [ObservableProperty] 
        string location;
        [ObservableProperty] 
        DateTime dateOfBirth;

        [ObservableProperty] 
        List<Ability> abilities = new();
        [ObservableProperty]
        List<Experience> experiences = new();
        [ObservableProperty]
        List<Education> educations = new();
        [ObservableProperty]
        List<Course> courses = new();
        [ObservableProperty]
        List<Language> languages = new();
        [ObservableProperty]
        List<Link> links = new();

        User user;
        IUserRepository userService = new UserService();
        IAbilityRepository abilityService = new AbilityService();
        IExperienceRepository experienceService = new ExperienceService();
        IEducationRepository educationService = new EducationService();
        ICourseRepository courseService = new CourseService();
        ILanguageRepository languageService = new LanguageService();
        ILinkRepository linkService = new LinkService();

        public JobOfertApplicationDetailsPageViewModel()
        {
            Task.FromResult(SetupJobOfertApplicationPage());
        }

        private async Task SetupJobOfertApplicationPage()
        {
            await Task.Delay(100);
            user = await userService.GetUser(UserId);
            Abilities = await abilityService.GetAbilities(UserId);
            Experiences = await experienceService.GetExperiences(UserId);
            Educations = await educationService.GetEducations(UserId);
            Courses = await courseService.GetCourses(UserId);
            Languages = await languageService.GetLanguages(UserId); 
            Links = await linkService.GetLinks(UserId);

            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            Phone = user.PhoneNumber;
            Location = user.Location;
            DateOfBirth = user.BirthDate;
        }

        [RelayCommand]
        private async Task MakeApplication()
        {
            await userService.PostUserJobOfertApplication(UserId, JobOfert);
        }
    }
}
