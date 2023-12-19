using CommunityToolkit.Mvvm.ComponentModel;
using JobPortal.Maui.Model;
using JobPortal.Maui.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.ViewModels
{
    public partial class FavouriteOfertsPageViewModel : ObservableObject
    {
        [ObservableProperty]
        List<JobOfert> userJobOferts = new();
        List<UserJobOfertFavourite> UserJobOfertFavourites { get; set; }
        User User { get; set; }
        IUserRepository userService = new UserService();
        IJobOfertRepository jobOfertService = new JobOfertService();
        public FavouriteOfertsPageViewModel()
        {
            User = App.user;
        }

        public async Task SetupFavourites()
        {
            UserJobOfertFavourites = await userService.GetUserJobOfertFavourites(User.Id);
            var ofertListTmp = new List<JobOfert>();
            foreach (var item in UserJobOfertFavourites)
            {
                ofertListTmp.Add(await jobOfertService.GetJobOfert(item.JobOfertId));
            }
            UserJobOferts = ofertListTmp;

        }

        public async Task DeleteUserJobOfertFavourite(int jobOfertId)
        {
            bool toDelete = await Shell.Current.DisplayAlert("Czy chcesz usunąć ogłoszenie z ulubionych?", "Czy chcesz usunąć ogłoszenie z ulubionych?", "Tak", "Nie");
            if (toDelete)
            {
                var jobOfert = UserJobOferts.Where(x => x.Id == jobOfertId).FirstOrDefault();
                await userService.RemoveUserJobOfertFavourite(User.Id, jobOfertId);
                await SetupFavourites();
            }
        }
    }
}
