using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JobPortal.Maui.Model;
using JobPortal.Maui.Repository;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace JobPortal.Maui.ViewModels
{
    public partial class JobOfertPageViewModel : ObservableObject
    {
        private User User { get; set; }

        [ObservableProperty]
        private string companyName;
        [ObservableProperty]
        private string companyAddress;
        [ObservableProperty]
        private string companyLocation;
        [ObservableProperty]
        private string companyDescription;
        [ObservableProperty]
        private DateTime recruitmentEndDate;
        [ObservableProperty]
        private string positionName;
        [ObservableProperty]
        private string positionLevel;
        [ObservableProperty]
        private string employmentContract;
        [ObservableProperty]
        private string employmentType;
        [ObservableProperty]
        private string jobType;
        [ObservableProperty]
        private decimal salaryMinimum;
        [ObservableProperty]
        private decimal salaryMaximum;
        [ObservableProperty]
        private string workDays;
        [ObservableProperty]
        private TimeSpan workStartHour;
        [ObservableProperty]
        private TimeSpan workEndHour;

        /*CATEGORY PROPERTIES*/
        [ObservableProperty]
        private string categoryInput;
        [ObservableProperty]
        private string categoryChoice;

        /*REQUIREMENT PROPERTIES*/
        [ObservableProperty]
        private string requirementNameLocal;

        /*DUTY PROPERTIES*/
        [ObservableProperty]
        private string dutyNameLocal;

        [ObservableProperty]
        List<string> employmentContractOptionsList = new List<string>()
        {
            "Umowa o pracę na czas nieokreślony",
            "Umowa o pracę na czas określony",
            "Umowa o pracę na czas częściowy",
            "Umowa o pracę tymczasową",
            "B2B"
        };

        [ObservableProperty]
        List<string> employmentTypeList = new List<string>()
        {
            "Pełny etat",
            "Czas częściowy",
            "Zatrudnienie na okresie próbnym",
            "Praca sezonowa",
            "Zatrudnienie tymczasowe"
        };
        [ObservableProperty]
        List<string> jobTypeList = new List<string>()
        {
            "zdalna", "stacjonarna", "hybrydowa"
        };
        [ObservableProperty]
        List<string> categoriesList;

        [ObservableProperty]
        ObservableCollection<Category> jobOfertCategories = new();
        [ObservableProperty]
        ObservableCollection<Requirement> jobOfertRequirements = new();
        [ObservableProperty]
        ObservableCollection<Duty> jobOfertDuties = new();

        /*UI PROPERTIES*/
        [ObservableProperty]
        private string categoryName;
        [ObservableProperty]
        private string requirementName;
        [ObservableProperty]
        private string dutyName;

        /*REPOSITORY INITIALIZATION*/
        private IJobOfertRepository jobOfertService = new JobOfertService();
        private ICategoryRepository categoryService = new CategoryService();
        private IRequirementRepository requirementService = new RequirementService();
        private IDutyRepository dutyService = new DutyService();

        public JobOfertPageViewModel()
        {
            User = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.user), null));
            SetUpJobOfertPage();
        }

        /*INSERT JOB OFERT COMMAND*/
        [RelayCommand]
        private async Task InsertJobOfert()
        {
            JobOfert jobOfert = new JobOfert();

            jobOfert.CompanyName = CompanyName;
            jobOfert.CompanyAddress = CompanyAddress;
            jobOfert.CompanyLocation = CompanyLocation;
            jobOfert.CompanyDescription = CompanyDescription;

            jobOfert.PositionName = PositionName;
            jobOfert.PositionLevel = PositionLevel;
            jobOfert.RecruitmentEndDate = RecruitmentEndDate;

            jobOfert.EmploymentContract = EmploymentContract;
            jobOfert.EmploymentType = EmploymentType;
            jobOfert.JobType = JobType;

            jobOfert.SalaryMinimum = SalaryMinimum;
            jobOfert.SalaryMaximum = SalaryMaximum;

            jobOfert.WorkStartHour = $"{WorkStartHour.Hours}:{WorkStartHour.Minutes}";
            jobOfert.WorkEndHour = $"{WorkEndHour.Hours}:{WorkEndHour.Minutes}";

            JobOfert db_result = await jobOfertService.AddJobOfert(User.Id,jobOfert);
            if(db_result != null)
            {
                foreach (Category category in JobOfertCategories)
                {
                    await categoryService.AddCategory(db_result.Id, category);
                }
                foreach (Requirement requirement in JobOfertRequirements)
                {
                    await requirementService.AddRequirement(db_result.Id, requirement);
                }
                foreach (Duty duty in JobOfertDuties)
                {
                    await dutyService.AddDuty(db_result.Id, duty);
                }
            }
        }

        /*INSERT CATEGORY COMMAND*/
        [RelayCommand]
        private void InsertCategory()
        {
            Category category = new Category();
            if(CategoryChoice == "inna")
            {
                category.CategoryName = CategoryInput;
                if (!JobOfertCategories.Any(x => x.CategoryName == category.CategoryName))
                {
                    JobOfertCategories.Add(category);
                }
            }
            else
            {
                if(CategoryChoice != null)
                {
                    category.CategoryName = CategoryChoice;
                    if (!JobOfertCategories.Any(x => x.CategoryName == category.CategoryName))
                    {
                        JobOfertCategories.Add(category);
                    }
                }
            }
        }

        /*INSERT REQUIREMENT COMMAND*/
        [RelayCommand]
        private void InsertRequirement()
        {
            Requirement requirement = new Requirement();
            requirement.RequirementName = RequirementNameLocal;
            JobOfertRequirements.Add(requirement);
        }

        /*INSERT DUTY COMMAND*/
        [RelayCommand]
        private void InsertDuty()
        {
            Duty duty = new Duty();
            duty.DutyName = DutyNameLocal;
            JobOfertDuties.Add(duty);
            
        }

        private async void SetUpJobOfertPage()
        {
            await UpdateCategoriesList();
        }

        private async Task UpdateCategoriesList()
        {
            var list = await categoryService.GetCategoriesAsString();
            list.Add("inna");
            CategoriesList = list;
        }
    }
}
