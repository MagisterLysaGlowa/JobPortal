using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JobPortal.Maui.Model;
using JobPortal.Maui.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.ViewModels
{
    [QueryProperty(nameof(JobOfert), nameof(JobOfert))]
    public partial class EditJobOfertPageViewModel : ObservableObject
    {
        private User User { get; set; }

        [ObservableProperty]
        private JobOfert jobOfert;

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

        /*BENEFIT PROPERTIES*/
        [ObservableProperty]
        private string benefitNameLocal;

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

        /*FILTER PROPERTIES*/
        [ObservableProperty]
        List<string> positionLevelFilterList = new List<string>()
        {
            "wszystkie",
            "praktykant/stażysta",
            "asystent",
            "młodszy specjalista",
            "specjalista",
            "starszy specjalista",
            "ekspert",
            "kierownik/koordynator",
            "menedżer",
            "dyrektor",
            "prezes"
        };

        [ObservableProperty]
        List<string> categoriesList;

        [ObservableProperty]
        ObservableCollection<Category> jobOfertCategories = new();
        [ObservableProperty]
        ObservableCollection<Requirement> jobOfertRequirements = new();
        [ObservableProperty]
        ObservableCollection<Duty> jobOfertDuties = new();
        [ObservableProperty]
        ObservableCollection<Benefit> jobOfertBenefits = new();

        /*UI PROPERTIES*/
        [ObservableProperty]
        private string categoryName;
        [ObservableProperty]
        private string requirementName;
        [ObservableProperty]
        private string dutyName;
        [ObservableProperty]
        private string benefitName;

        /*REPOSITORY INITIALIZATION*/
        private IJobOfertRepository jobOfertService = new JobOfertService();
        private ICategoryRepository categoryService = new CategoryService();
        private IRequirementRepository requirementService = new RequirementService();
        private IDutyRepository dutyService = new DutyService();
        private IBenefitRepository benefitService = new BenefitService();

        /*INSERT JOB OFERT COMMAND*/
        [RelayCommand]
        private async Task EditJobOfert()
        {
            JobOfert jobOfert = new JobOfert();

            jobOfert.Id = JobOfert.Id;
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

            jobOfert.JobOfertCategories = new();

            bool correct = await jobOfertService.UpdateJobOfert(JobOfert.Id, jobOfert);
            if (correct)
            {
                await Shell.Current.GoToAsync("//homePage");
            }
        }

        private void ClearAllInputs()
        {
            CompanyName = "";
            CompanyAddress = "";
            CompanyLocation = "";
            CompanyDescription = "";
            PositionName = "";
            PositionLevel = "";
            RecruitmentEndDate = DateTime.Now;
            EmploymentContract = "";
            EmploymentType = "";
            JobType = "";
            SalaryMinimum = 0;
            SalaryMaximum = 0;
            WorkStartHour = TimeSpan.Zero;
            WorkEndHour = TimeSpan.Zero;
            JobOfertCategories.Clear();
            JobOfertDuties.Clear();
            JobOfertBenefits.Clear();
            JobOfertRequirements.Clear();
        }

        /*INSERT CATEGORY COMMAND*/
        [RelayCommand]
        private void InsertCategory()
        {
            Category category = new Category();
            if (CategoryChoice == "inna")
            {
                category.CategoryName = CategoryInput;
                if (!JobOfertCategories.Any(x => x.CategoryName == category.CategoryName))
                {
                    JobOfertCategories.Add(category);
                }
                CategoryInput = "";
            }
            else
            {
                if (CategoryChoice != null)
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
            if (!JobOfertRequirements.Any(x => x.RequirementName == requirement.RequirementName))
            {
                JobOfertRequirements.Add(requirement);
            }
            RequirementNameLocal = "";
        }

        /*INSERT DUTY COMMAND*/
        [RelayCommand]
        private void InsertDuty()
        {
            Duty duty = new Duty();
            duty.DutyName = DutyNameLocal;
            if (!JobOfertDuties.Any(x => x.DutyName == duty.DutyName))
            {
                JobOfertDuties.Add(duty);
            }
            DutyNameLocal = "";
        }

        /*INSERT BENEFIT COMMAND*/
        [RelayCommand]
        private void InsertBenefit()
        {
            Benefit benefit = new Benefit();
            benefit.BenefitName = BenefitNameLocal;
            if (!JobOfertBenefits.Any(x => x.BenefitName == benefit.BenefitName))
            {
                JobOfertBenefits.Add(benefit);
            }
            BenefitNameLocal = "";
        }

        public async Task SetUpEditJobOfertPage()
        {
            CompanyName = JobOfert.CompanyName;
            CompanyAddress = JobOfert.CompanyAddress;
            CompanyLocation = JobOfert.CompanyLocation;
            CompanyDescription = JobOfert.CompanyDescription;

            PositionName = JobOfert.PositionName;
            PositionLevel = JobOfert.PositionLevel;
            RecruitmentEndDate =JobOfert. RecruitmentEndDate;

            EmploymentContract = JobOfert.EmploymentContract;
            EmploymentType = JobOfert.EmploymentType;
            JobType = JobOfert.JobType;

            SalaryMinimum = JobOfert.SalaryMinimum;
            SalaryMaximum = JobOfert.SalaryMaximum;

            JobOfertBenefits = new ObservableCollection<Benefit>(await benefitService.GetBenefits(JobOfert.Id));
            JobOfertDuties = new ObservableCollection<Duty>(await dutyService.GetDuties(JobOfert.Id));
            JobOfertRequirements = new ObservableCollection<Requirement>(await requirementService.GetRequirements(JobOfert.Id));
            JobOfertCategories = new ObservableCollection<Category>(await categoryService.GetCategories(JobOfert.Id));
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
