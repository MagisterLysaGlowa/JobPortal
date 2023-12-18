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
    public partial class HomePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string companyName;
        [ObservableProperty]
        private string positionName;
        [ObservableProperty]
        private string companyLocation;
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
        private List<Category> jobOfertCategories;
        [ObservableProperty]
        private string categoryName;
        [ObservableProperty]
        private Category category;


        [ObservableProperty]
        private List<JobOfert> jobOfertsList = new();

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
        List<string> employmentContractOptionsFilterList = new List<string>()
        {
            "wszystkie",
            "Umowa o pracę na czas nieokreślony",
            "Umowa o pracę na czas określony",
            "Umowa o pracę na czas częściowy",
            "Umowa o pracę tymczasową",
            "B2B"
        };

        [ObservableProperty]
        List<string> employmentTypeFilterList = new List<string>()
        {
            "wszystkie",
            "Pełny etat",
            "Czas częściowy",
            "Zatrudnienie na okresie próbnym",
            "Praca sezonowa",
            "Zatrudnienie tymczasowe"
        };
        [ObservableProperty]
        List<string> jobTypeFilterList = new List<string>()
        {
            "wszystkie","zdalna", "stacjonarna", "hybrydowa"
        };
        [ObservableProperty]
        List<string> categoriesFilterList = new();

        [ObservableProperty]
        string positionFilterName;
        [ObservableProperty]
        string companyFilterName;
        [ObservableProperty]
        string positionLevelFilter;
        [ObservableProperty]
        string employmentContractOptionFilter;
        [ObservableProperty]
        string employmentTypeFilter;
        [ObservableProperty]
        string jobTypeFilter;
        [ObservableProperty]
        string categoryFilter;


        /*REPOSITORIES INITIALIZATION*/
        IJobOfertRepository jobOfertService = new JobOfertService();
        ICategoryRepository categoryService = new CategoryService();
        public HomePageViewModel()
        {
            SetUpHomePageInfo();
        }

        private async void SetUpHomePageInfo()
        {
            await ReRenderJobOfertsList();
            var categoriesFilterList = await categoryService.GetCategoriesAsString();
            categoriesFilterList.Insert(0, "wszystkie");
            CategoriesFilterList = categoriesFilterList;
            
        }

        [RelayCommand]
        private async Task FilterJobOferts()
        {
            await ReRenderJobOfertsList();
            var filterList = JobOfertsList;
            if (!string.IsNullOrWhiteSpace(PositionFilterName))
            {
                filterList = filterList.Where(x => x.PositionName.ToLower().Contains(PositionFilterName.ToLower())).ToList();
            }

            if (!string.IsNullOrWhiteSpace(CompanyFilterName))
            {
                filterList = filterList.Where(x => x.CompanyName.ToLower().Contains(CompanyFilterName.ToLower())).ToList();
            }

            if (!string.IsNullOrWhiteSpace(CategoryFilter) && CategoryFilter != "wszystkie")
            {
                filterList = filterList
                    .Where(x => x.JobOfertCategories
                    .Any(x => x.Category.CategoryName
                    .ToLower() == CategoryFilter
                    .ToLower()))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(PositionLevelFilter) && PositionLevelFilter != "wszystkie")
            {
                filterList = filterList.Where(x => x.PositionLevel.ToLower() == PositionLevelFilter.ToLower()).ToList();
            }

            if (!string.IsNullOrWhiteSpace(EmploymentTypeFilter) && EmploymentTypeFilter != "wszystkie")
            {
                filterList = filterList.Where(x => x.EmploymentType.ToLower() == EmploymentTypeFilter.ToLower()).ToList();
            }

            if (!string.IsNullOrWhiteSpace(EmploymentContractOptionFilter) && EmploymentContractOptionFilter != "wszystkie")
            {
                filterList = filterList.Where(x => x.EmploymentContract.ToLower() == EmploymentContractOptionFilter.ToLower()).ToList();
            }

            if (!string.IsNullOrWhiteSpace(JobTypeFilter) && JobTypeFilter != "wszystkie")
            {
                filterList = filterList.Where(x => x.JobType.ToLower() == JobTypeFilter.ToLower()).ToList();
            }

            JobOfertsList = filterList;
        }
        private async Task ReRenderJobOfertsList()
        {
            JobOfertsList = await jobOfertService.GetAllJobOfertsWithCategories();
        }
    }
}
