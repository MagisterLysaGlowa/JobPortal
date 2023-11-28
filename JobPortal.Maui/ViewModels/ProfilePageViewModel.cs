using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JobPortal.Maui.Model;
using JobPortal.Maui.Repository;
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
        private string company;
        [ObservableProperty]
        private DateTime proffesionSince;
        [ObservableProperty]
        private string industry;

        /*EDIT CURRENT WORKPLACE PROPERTIES*/
        [ObservableProperty]
        private bool currentlyWorking = true;
        [ObservableProperty]
        private bool currentlyUnemployed = false;
        [ObservableProperty]
        private bool workplaceInfoEdit = false;
        [ObservableProperty]
        private string workplaceInfoEditButtonText = "Edytuj";


        /*REPOSITORIES INIT*/
        private IFileOperationRepository fileOperationService = new FileOperationsService();
        private IUserRepository userService = new UserService();

        public ProfilePageViewModel()
        {
            /*GET USER SAVED IN PREFERENCES FILES*/
            User = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.user), null));

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
        }

        /*COMMANDS*/

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

        [RelayCommand]
        private async Task SetWorkplaceInfoEditMode()
        {
            WorkplaceInfoEditButtonText = WorkplaceInfoEdit ? "Edytuj" : "Zapisz";
            if (CurrentlyWorking)
            {
                var user = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.user), null));
                user.Proffesion = Proffesion;
                user.Company = Company;
                user.ProffesionDescription = ProffesionDescription;
                user.Industry = Industry;
                user.ProffesionSince = ProffesionSince;
                await userService.UpdateUser(User.Id, user);
                await Shell.Current.DisplayAlert("EDIT MODE", User.Name, "WORKING");
            }

            WorkplaceInfoEdit = !WorkplaceInfoEdit;
        }

        /*UTILITY METHODDS*/
        private async void SetProfileImage(string filePath)
        {
            ProfileImage = await fileOperationService.ImportUserImage(filePath);
        }

        public void ToggleCheckedCurrentlyWorking()
        {
            if (CurrentlyWorking)
            {
                Shell.Current.DisplayAlert("WORKING", "WORKING", "WORKING");
            }

            if (CurrentlyUnemployed)
            {
                Shell.Current.DisplayAlert("WE SIE KURWA DO ROBOTY", "WE SIE KURWA DO ROBOTY", "WE SIE KURWA DO ROBOTY");
            }
        }
    }
}
