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
    public partial class CurrentApplicationsViewModel : ObservableObject
    {
        [ObservableProperty]
        List<JobOfert> userJobOferts = new();
        List<UserJobOfertApplication> UserJobOfertApplications { get; set; }
        User User {get;set;}
        IUserRepository userService = new UserService();
        IJobOfertRepository jobOfertService = new JobOfertService();
        public CurrentApplicationsViewModel()
        {
            User = App.user;
        }

        public async Task SetupCurrentApplications()
        {
            UserJobOfertApplications = await userService.GetUserJobOfertApplications(User.Id);
            var ofertListTmp = new List<JobOfert>();
            foreach (var item in UserJobOfertApplications)
            {
                ofertListTmp.Add(await jobOfertService.GetJobOfert(item.JobOfertId));
            }
            UserJobOferts = ofertListTmp;

        }

        public async Task DeleteUserJobOfertApplication(int jobOfertId)
        {
            bool toDelete = await Shell.Current.DisplayAlert("Czy chcesz cofnąć aplikację?", "Czy chcesz cofnąć aplikację?", "Tak","Nie");
            if (toDelete)
            {
                var jobOfert = UserJobOferts.Where(x => x.Id == jobOfertId).FirstOrDefault();
                await userService.RemoveUserJobOfertApplication(User.Id, jobOfertId);
                await SetupCurrentApplications();
            }
        }
    }
}
