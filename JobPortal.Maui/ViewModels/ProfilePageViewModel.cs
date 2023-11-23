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

        /*UTILITY PROPERTIES*/
        [ObservableProperty]
        private bool basicInfoEdit = true;
        [ObservableProperty]
        private string basicInfoEditButtonText = "Edytuj";


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
        private void SetEditMode()
        {
            BasicInfoEditButtonText = !BasicInfoEdit ? "Edytuj" : "Zapisz";
            if (!BasicInfoEdit)
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
            }
            BasicInfoEdit = !BasicInfoEdit;
        }

        /*UTILITY METHODDS*/
        private async void SetProfileImage(string filePath)
        {
            ProfileImage = await fileOperationService.ImportUserImage(filePath);
        }
    }
}
