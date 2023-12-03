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

        /*UTILITY PROPERTIES*/
        public bool workFlag = false;
        public bool carrierFlag = false;

        /*REPOSITORIES INIT*/
        private IFileOperationRepository fileOperationService = new FileOperationsService();
        private IUserRepository userService = new UserService();
        private IWorkRepository workService = new WorkService();
        private ICarrierRepository carrierService = new CarrierService(); 

        public ProfilePageViewModel()
        {
            /*GET USER SAVED IN PREFERENCES FILES*/
            User = JsonConvert.DeserializeObject<User>(Preferences.Get(nameof(App.user), null));

            SetUpUserInfo();
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
                    await Shell.Current.DisplayAlert("dodany", $"dodany ID: {carrier.Name} {carrier.DateSince} {carrier.UserId}", "dodany");
                    await carrierService.AddCarrier(carrier);
                }
            }

            CarrierInfoEdit = !CarrierInfoEdit;
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
        }
    }
}
