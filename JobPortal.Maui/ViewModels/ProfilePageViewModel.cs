using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JobPortal.Maui.Model;
using JobPortal.Maui.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.ViewModels
{
    public partial class ProfilePageViewModel : ObservableObject
    {
        private User User { get; set; }

        /*HEADER PROPERTIES*/
        [ObservableProperty]
        private ImageSource profileImage;
        [ObservableProperty]
        private string currentHeaderName;
        [ObservableProperty]
        private string currentHeaderSurname;


        /*BASIC INFO PROPERTIES*/
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string surname;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string phoneNumber;
        [ObservableProperty]
        private string location;
        [ObservableProperty]
        private DateTime birthDate;

        /*EDIT BASIC INFO PROPERTIES*/
        [ObservableProperty]
        private bool basicInfoEdit = false;
        [ObservableProperty]
        private string basicInfoEditButtonText = "Edytuj";

        /*CURRENT WORKPLACE PROPERTIES*/
        [ObservableProperty]
        private string proffesion;
        [ObservableProperty]
        private string proffesionDescription;
        [ObservableProperty]
        private string companyName;
        [ObservableProperty]
        private DateTime proffesionSince;
        [ObservableProperty]
        private string industry;

        /*EDIT CURRENT WORKPLACE PROPERTIES*/
        [ObservableProperty]
        private bool currentlyWorking;
        [ObservableProperty]
        private bool currentlyUnemployed;
        [ObservableProperty]
        private bool workplaceInfoEdit = false;
        [ObservableProperty]
        private string workplaceInfoEditButtonText = "Edytuj";

        /*CARRIER PROPERTIES*/
        [ObservableProperty]
        private string carrierName;
        [ObservableProperty]
        private DateTime carrierSince;

        /*EDIT CARRIER PROPERTIES*/
        [ObservableProperty]
        private bool carrierYes = false;
        [ObservableProperty]
        private bool carrierNo = true;
        [ObservableProperty]
        private bool carrierInfoEdit = false;
        [ObservableProperty]
        private string carrierInfoEditButtonText = "Edytuj";

        /*EXPERIENCE PROPERTIES*/
        [ObservableProperty]
        private string experienceProffesionLocal;
        [ObservableProperty]
        private string experienceCompanyNameLocal;
        [ObservableProperty]
        private string experienceLocationLocal;
        [ObservableProperty]
        private DateTime experienceStartDateLocal;
        [ObservableProperty]
        private DateTime experienceEndDateLocal;
        [ObservableProperty]
        private List<Experience> experiencesList = new();

        /*PROPERITES USED FOR CORRECT LIST VIEW DISPLAY*/
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private DateTime startDate;
        [ObservableProperty]
        private DateTime endDate;

        /*EDUCATION PROPERTIES*/
        [ObservableProperty]
        private string schoolNameLocal;
        [ObservableProperty]
        private string schoolLevelLocal;
        [ObservableProperty]
        private string schoolDegreeLocal;
        [ObservableProperty]
        private string schoolLocationLocal;
        [ObservableProperty]
        private DateTime schoolStartDateLocal;
        [ObservableProperty]
        private DateTime schoolEndDateLocal;
        [ObservableProperty]
        private List<Education> educationsList = new();

        /*PROPERITES USED FOR CORRECT LIST VIEW DISPLAY*/
        [ObservableProperty]
        private string schoolName;
        [ObservableProperty]
        private string schoolLevel;
        [ObservableProperty]
        private string schoolDegree;
        [ObservableProperty]
        private string schoolLocation;
        [ObservableProperty]
        private DateTime schoolStartDate;
        [ObservableProperty]
        private DateTime schoolEndDate;

        /*LANGUAGE PROPERTIES*/
        [ObservableProperty]
        private string languageNameLocal;
        [ObservableProperty]
        private string languageLevelLocal;

        /*PROPERITES USED FOR CORRECT LIST VIEW DISPLAY*/
        [ObservableProperty]
        private string languageName;
        [ObservableProperty]
        private string languageLevel;
        [ObservableProperty]
        List<Language> languagesList = new();

        /*ABILITY PROPERTIES*/
        [ObservableProperty]
        private string abilityNameLocal;

        /*PROPERITES USED FOR CORRECT LIST VIEW DISPLAY*/
        [ObservableProperty]
        private string abilityName;
        [ObservableProperty]
        List<Ability> abilitiesList = new();

        /*COURSE PROPERTIES*/
        [ObservableProperty]
        private string courseNameLocal;
        [ObservableProperty]
        private string courseOrganizerLocal;
        [ObservableProperty]
        private DateTime courseStartDateLocal;
        [ObservableProperty]
        private DateTime courseEndDateLocal;

        /*PROPERITES USED FOR CORRECT LIST VIEW DISPLAY*/
        [ObservableProperty]
        private string courseName;
        [ObservableProperty]
        private string courseOrganizer;
        [ObservableProperty]
        private DateTime courseStartDate;
        [ObservableProperty]
        private DateTime courseEndDate;
        [ObservableProperty]
        List<Course> coursesList = new();

        /*LINK PROPERTIES*/
        [ObservableProperty]
        private string linkContentLocal;

        /*PROPERITES USED FOR CORRECT LIST VIEW DISPLAY*/
        [ObservableProperty]
        private string linkContent;
        [ObservableProperty]
        private List<Link> linksList = new();

        /*UTILITY PROPERTIES*/
        public bool workFlag = false;
        public bool carrierFlag = false;
        [ObservableProperty]
        List<string> educationLevels = new()
        {
            "podstawowe","średnie", "zawodowe","licencjat","wyższe"
        };
        [ObservableProperty]
        List<string> languageLevels = new()
        {
            "A1","A2", "B1","B2","C1","C2"
        };
        [ObservableProperty]
        private bool isEmployee;

        /*REPOSITORIES INIT*/
        private IFileOperationRepository fileOperationService = new FileOperationsService();
        private IUserRepository userService = new UserService();
        private IWorkRepository workService = new WorkService();
        private ICarrierRepository carrierService = new CarrierService(); 
        private IExperienceRepository experienceService = new ExperienceService();
        private IEducationRepository educationService = new EducationService();
        private ILanguageRepository languageService = new LanguageService();
        private IAbilityRepository abilityService = new AbilityService();
        private ICourseRepository courseService = new CourseService();
        private ILinkRepository linkService = new LinkService();

        public ProfilePageViewModel()
        {
            /*GET USER SAVED IN PREFERENCES FILES*/
            User = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.user), null));

            SetUpUserInfo();
            IsEmployee = User.Access == "employer" ? false : true;
        }

        /*---COMMANDS---*/


        /*BASIC USER INFO EDIT COMMAND*/
        [RelayCommand]
        private void SetBasicInfoEditMode()
        {
            BasicInfoEditButtonText = BasicInfoEdit ? "Edytuj" : "Zapisz";
            if (BasicInfoEdit)
            {
                User user = new User();
                user.Id = User.Id;
                user.Access = User.Access;
                user.Password = User.Password;
                user.ImagePath = User.ImagePath;

                user.Name = Name;
                user.Email = Email;
                user.Surname = Surname;
                user.Location = Location;
                user.BirthDate = BirthDate;
                user.PhoneNumber = PhoneNumber;

                userService.UpdateUser(User.Id,user);
                string userDetails = JsonConvert.SerializeObject(user);
                Preferences.Set(nameof(App.user), userDetails);
            }
            BasicInfoEdit = !BasicInfoEdit;
        }

        /*USER WORK INFO EDIT COMMAND*/
        [RelayCommand]
        private async Task SetWorkplaceInfoEditMode()
        {
            WorkplaceInfoEditButtonText = WorkplaceInfoEdit ? "Edytuj" : "Zapisz";
            if (CurrentlyWorking && WorkplaceInfoEdit)
            {
                Work currentUserWork = await workService.GetWorkByUserId(User.Id);
                if(currentUserWork != null)
                {
                    var work = new Work();
                    work.Id = currentUserWork.Id;
                    work.Proffesion = Proffesion;
                    work.ProffesionDescription = ProffesionDescription;
                    work.CompanyName = CompanyName;
                    work.ProffesionSince = ProffesionSince;
                    work.Industry = Industry;
                    work.UserId = User.Id;
                    await workService.UpdateWork(currentUserWork.Id, work);
                }
                else
                {
                    var work = new Work();
                    work.Proffesion = Proffesion;
                    work.ProffesionDescription = ProffesionDescription;
                    work.CompanyName = CompanyName;
                    work.ProffesionSince = ProffesionSince;
                    work.Industry = Industry;
                    work.UserId = User.Id;
                    await workService.AddWork(work);
                }
            }

            WorkplaceInfoEdit = !WorkplaceInfoEdit;
        }

        /*USER CARRIER INFO EDIT COMMAND*/
        [RelayCommand]
        private async Task SetCarrierInfoEditMode()
        {
            CarrierInfoEditButtonText = CarrierInfoEdit ? "Edytuj" : "Zapisz";
            if (CarrierYes && CarrierInfoEdit)
            {
                Carrier userCarrier = await carrierService.GetCarrierByUserId(User.Id);
                if (userCarrier != null)
                {
                    var carrier = new Carrier();
                    carrier.Id = userCarrier.Id;
                    carrier.Name = CarrierName;
                    carrier.DateSince = CarrierSince;
                    carrier.UserId = User.Id;
                    await carrierService.UpdateCarrier(userCarrier.Id, carrier);
                }
                else
                {
                    var carrier = new Carrier();
                    carrier.Name = CarrierName;
                    carrier.DateSince = CarrierSince;
                    carrier.UserId = User.Id;
                    await carrierService.AddCarrier(carrier);
                }
            }

            CarrierInfoEdit = !CarrierInfoEdit;
        }

        [RelayCommand]
        /*ADD NEW EXPERIENCE ELEMENT COMMAND*/
        private async Task InsertExperience()
        {
            Experience experience = new Experience();
            experience.Proffesion = ExperienceProffesionLocal;
            experience.CompanyName = ExperienceCompanyNameLocal;
            experience.Location = ExperienceLocationLocal;
            experience.StartDate = ExperienceStartDateLocal;
            experience.EndDate = ExperienceEndDateLocal;
            await experienceService.AddExperience(User.Id, experience);
            ReRenderExperienceList();
        }

        /*ADD NEW EDUCATION ELEMENT COMMAND*/
        [RelayCommand]
        private async Task InsertEducation()
        {
            Education education = new Education();
            education.SchoolName = SchoolNameLocal;
            education.SchoolLocation = SchoolLocationLocal;
            education.SchoolLevel = SchoolLevelLocal;
            education.SchoolDegree = SchoolDegreeLocal;
            education.SchoolStartDate = SchoolStartDateLocal;
            education.SchoolEndDate = SchoolEndDateLocal;
            await educationService.AddEducation(education,User.Id);
            ReRenderEducationList();
        }

        /*ADD NEW LANGUAGE ELEMENT COMMAND*/
        [RelayCommand]
        private async Task InsertLanguage()
        {
            Language language = new Language();
            language.LanguageName = LanguageNameLocal;
            language.LanguageLevel = LanguageLevelLocal;
            await languageService.AddLanguage(User.Id,language);
            ReRenderLanguageList();
        }

        /*ADD NEW ABILITY ELEMENT COMMAND*/
        [RelayCommand]
        private async Task InsertAbility()
        {
            Ability ability = new Ability();
            ability.AbilityName = AbilityNameLocal;
            await abilityService.AddAbility(User.Id,ability);
            ReRenderAbilityList();
        }

        /*ADD NEW COURSE ELEMENT COMMAND*/
        [RelayCommand]
        private async Task InsertCourse()
        {
            Course course = new Course();
            course.CourseName = CourseNameLocal;
            course.CourseOrganizer = CourseOrganizerLocal;
            course.CourseStartDate = CourseStartDateLocal;
            course.CourseEndDate = CourseEndDateLocal;
            await courseService.AddCourse(User.Id, course);
            ReRenderCourseList();
        }

        /*ADD NEW LINK ELEMENT COMMAND*/
        [RelayCommand]
        private async Task InsertLink()
        {
            Link link = new Link();
            link.LinkContent = LinkContentLocal;
            await linkService.AddLink(User.Id, link);
            ReRenderLinkList();
        }

        /*UTILITY METHODDS*/
        private async void SetProfileImage(string filePath)
        {
            ProfileImage = await fileOperationService.ImportUserImage(filePath);
        }

        public async void ToggleCheckedCurrentlyWorking()
        {
            if (CurrentlyUnemployed)
            {
                if (workFlag)
                {
                    Work currentUserWork = await workService.GetWorkByUserId(User.Id);
                    if(currentUserWork != null)
                    {
                        await workService.DeleteWork(currentUserWork.Id);
                        Proffesion = null;
                        ProffesionDescription = null;
                        CompanyName = null;
                        ProffesionSince = DateTime.Now;
                        Industry = null;
                    }
                }
            }
        }

        public async void ToggleCheckedCarrier()
        {
            if (CarrierNo)
            {
                if (carrierFlag)
                {
                    Carrier userCarrier = await carrierService.GetCarrierByUserId(User.Id);
                    if (userCarrier != null)
                    {
                        await carrierService.DeleteCarrier(userCarrier.Id);
                        CarrierName = null;
                        CarrierSince = DateTime.Now;
                    }
                }
            }
        }

        public async void SetUpUserInfo()
        {
            /*GET USER SAVED IN PREFERENCES FILES*/
            User = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.user), null));

            /*FETCH USER DATA*/
            Work userWork = await workService.GetWorkByUserId(User.Id);
            Carrier userCarrier = await carrierService.GetCarrierByUserId(User.Id);

            /*SETUP PROFILE HEADER*/
            SetProfileImage(User.ImagePath);
            CurrentHeaderName = User.Name;
            CurrentHeaderSurname = User.Surname;

            /*SETUP USER BASIC INFO*/
            Name = User.Name;
            Surname = User.Surname;
            Email = User.Email;
            PhoneNumber = User.PhoneNumber;
            Location = User.Location;
            BirthDate = User.BirthDate;

            /*SETUP WORK INFO*/
            if(userWork != null)
            {
                CurrentlyWorking = true;
                CurrentlyUnemployed = false;
                workFlag = true;
                Proffesion = userWork.Proffesion;
                ProffesionDescription = userWork?.ProffesionDescription;
                ProffesionSince = userWork.ProffesionSince;
                Industry = userWork.Industry;
                CompanyName = userWork.CompanyName;
            }
            else
            {
                CurrentlyWorking = false;
                CurrentlyUnemployed = true;
            }

            /*SETUP CARRIER INFO*/
            if (userCarrier != null)
            {
                CarrierYes = true;
                CarrierNo = false;
                carrierFlag = true;
                CarrierName = userCarrier.Name;
                CarrierSince = userCarrier.DateSince;
            }
            else
            {
                CarrierYes = false;
                CarrierNo = true;
            }

            /*SETUP EXPERIENCE INFO*/
            ReRenderExperienceList();
            /*SETUP EDUCATION INFO*/
            ReRenderEducationList();
            /*SETUP LANGUAGE INFO*/
            ReRenderLanguageList();
            /*SETUP ABILITY INFO*/
            ReRenderAbilityList();
            /*SETUP COURSE INFO*/
            ReRenderCourseList();
            /*SETUP LINK INFO*/
            ReRenderLinkList();
        }

        private async void ReRenderExperienceList()
        {
            ExperiencesList = await experienceService.GetExperiences(User.Id);
        }
        private async void ReRenderEducationList()
        {
            EducationsList = await educationService.GetEducations(User.Id);
        }
        private async void ReRenderLanguageList()
        {
            LanguagesList = await languageService.GetLanguages(User.Id);
        }

        private async void ReRenderAbilityList()
        {
            AbilitiesList = await abilityService.GetAbilities(User.Id);
        }

        private async void ReRenderCourseList()
        {
            CoursesList = await courseService.GetCourses(User.Id);
        }
        private async void ReRenderLinkList()
        {
            LinksList = await linkService.GetLinks(User.Id);
        }

        /*DELETE EXPERIENCE ELEMENT COMMAND*/
        public async Task DeleteExperience(int experienceId)
        {

            bool delete = await Shell.Current.DisplayAlert("Czy napewno chcesz usunąć element?", "Czy napewno chcesz usunąć element?", "Tak", "Nie");
            if (delete)
            {
                await experienceService.DeleteExperience(experienceId);
                ReRenderExperienceList();
            }
        }

        /*DELETE EDUCATION ELEMENT COMMAND*/
        public async Task DeleteEducation(int educationId)
        {
            bool delete = await Shell.Current.DisplayAlert("Czy napewno chcesz usunąć element?", "Czy napewno chcesz usunąć element?", "Tak", "Nie");
            if (delete)
            {
                await educationService.DeleteEducation(educationId);
                ReRenderEducationList();
            }
        }

        /*DELETE LANGUAGE ELEMENT COMMAND*/
        public async Task DeleteLanguage(int languageId)
        {
            bool delete = await Shell.Current.DisplayAlert("Czy napewno chcesz usunąć element?", "Czy napewno chcesz usunąć element?", "Tak", "Nie");
            if (delete)
            {
                await languageService.DeleteLanguage(languageId);
                ReRenderLanguageList();
            }
        }

        /*DELETE ABILITY ELEMENT COMMAND*/
        public async Task DeleteAbility(int abilityId)
        {
            bool delete = await Shell.Current.DisplayAlert("Czy napewno chcesz usunąć element?", "Czy napewno chcesz usunąć element?", "Tak", "Nie");
            if (delete)
            {
                await abilityService.DeleteAbility(abilityId);
                ReRenderAbilityList();
            }
        }

        /*DELETE COURSE ELEMENT COMMAND*/
        public async Task DeleteCourse(int courseId)
        {
            bool delete = await Shell.Current.DisplayAlert("Czy napewno chcesz usunąć element?", "Czy napewno chcesz usunąć element?", "Tak", "Nie");
            if (delete)
            {
                await courseService.DeleteCourse(courseId);
                ReRenderCourseList();
            }
        }

        /*DELETE LINK ELEMENT COMMAND*/
        public async Task DeleteLink(int linkId)
        {
            bool delete = await Shell.Current.DisplayAlert("Czy napewno chcesz usunąć element?", "Czy napewno chcesz usunąć element?", "Tak", "Nie");
            if (delete)
            {
                await linkService.DeleteLink(linkId);
                ReRenderLinkList();
            }
        }
    }
}
