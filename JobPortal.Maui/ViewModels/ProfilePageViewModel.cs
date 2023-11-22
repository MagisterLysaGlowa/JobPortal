using CommunityToolkit.Mvvm.ComponentModel;
using JobPortal.Maui.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.ViewModels
{
    public partial class ProfilePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private User user;

        public ProfilePageViewModel()
        {
            User = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.user), null));
            Shell.Current.DisplayAlert("from profile view model", User.Name, "OK");
        }
    }
}
