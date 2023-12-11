using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class HomePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string companyName;
        [ObservableProperty]
        private List<Category> jobOfertCategories;
        [ObservableProperty]
        private string categoryName;
        [ObservableProperty]
        private Category category;


        [ObservableProperty]
        private List<JobOfert> jobOfertsList = new();

        /*REPOSITORIES INITIALIZATION*/
        IJobOfertRepository jobOfertService = new JobOfertService();

        public HomePageViewModel()
        {
            SetUpHomePageInfo();
        }

        private async void SetUpHomePageInfo()
        {
            await ReRenderJobOfertsList();
        }

        private async Task ReRenderJobOfertsList()
        {
            JobOfertsList = await jobOfertService.GetAllJobOfertsWithCategories();
        }
    }
}
