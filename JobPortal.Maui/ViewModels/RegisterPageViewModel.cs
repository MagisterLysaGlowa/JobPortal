using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JobPortal.Maui.Model;
using JobPortal.Maui.Repository;
using JobPortal.Maui.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JobPortal.Maui.ViewModels
{
    public partial class RegisterPageViewModel : ObservableObject
    {
        /*REGISTER PROPERTIES*/

        /*NAME PROPERTIES*/
        [ObservableProperty]
        private string name = "kacper";
        [ObservableProperty]
        private bool nameError = false;
        [ObservableProperty]
        private string nameErrorText;

        /*SURNAME PROPERTIES*/
        [ObservableProperty]
        private string surname = "piaskowy";
        [ObservableProperty]
        private bool surnameError = false;
        [ObservableProperty]
        private string surnameErrorText;

        /*EMAIL PROPERTIES*/
        [ObservableProperty]
        private string email = "kacper@wp.pl";
        [ObservableProperty]
        private bool emailError = false;
        [ObservableProperty]
        private string emailErrorText;

        /*PHONE NUMBER PROPERTIES*/
        [ObservableProperty]
        private string phoneNumber = "123456789";
        [ObservableProperty]
        private bool phoneNumberError = false;
        [ObservableProperty]
        private string phoneNumberErrorText;

        /*PASSWORD PROPERTIES*/
        [ObservableProperty]
        private string password = "Dol@r12345";
        [ObservableProperty]
        private bool passwordError = false;
        [ObservableProperty]
        private string passwordErrorText;

        /*PASSWORD REPEAT PROPERTIES*/
        [ObservableProperty]
        private string repeatPassword = "Dol@r12345";
        [ObservableProperty]
        private bool repeatPasswordError = false;
        [ObservableProperty]
        private string repeatPasswordErrorText;

        /*LOCATION PROPERTIES*/
        [ObservableProperty]
        private string location = "Limanowa";
        [ObservableProperty]
        private bool locationError = false;
        [ObservableProperty]
        private string locationErrorText;

        /*DATE OF BIRTH PROPERTIES*/
        [ObservableProperty]         
        private DateTime dateOfBirth;
        [ObservableProperty]
        private bool dateOfBirthError = false;
        [ObservableProperty]
        private string dateOfBirthErrorText;

        /*UI PROPERTIES*/
        [ObservableProperty]
        private int step = 0;
        [ObservableProperty]
        private bool isBusy;

        /*USER IMAGE PROPERTY*/
        [ObservableProperty]
        private ImageSource userImageSource = "user_icon.jpg";

        /*UTILITY PROPERTIES*/
        private FileResult FileToUpload { get; set; }

        /*REPOSITORY PROPERITES*/
        private IUploadFileRepository uploadFileRepository = new UploadFileService();
        private IUserRepository userRepository = new UserService();

        /*STEP COMMANDS WHICH CHANGE CURRENT VISIBLE FRAME*/
        [RelayCommand]
        public async Task NextStep(string frame)
        {
            bool correct = EntryValidation(frame);
            if (!correct) return;
            IsBusy = true;
            Step++;
            await Task.Delay(550);
            IsBusy = false;
        }

        [RelayCommand]
        public async Task PreviousStep(string frame)
        {
            bool correct = EntryValidation(frame);
            if (!correct) return;
            IsBusy = true;
            Step--;
            await Task.Delay(550);
            IsBusy = false;
            EntryValidation(frame);
        }

        /*[COMMAND] BROWSER FILE TO UPLOAD*/
        [RelayCommand]
        public async Task BrowserImageToUpload()
        {
            try
            {
                FileToUpload = await MediaPicker.PickPhotoAsync();

                if (FileToUpload != null)
                {
                    var stream = await FileToUpload.OpenReadAsync();
                    UserImageSource = ImageSource.FromStream(()=>stream);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("ERROR", "THERE IS AN ERROR WITH YOUR BROWSED FILE", "OK");
            }
        }

        /*[COMMAND] UPLOAD USER IMAGE*/
        [RelayCommand]
        public async Task UploadImage(FileResult uploadFile)
        {
            // check for null
            if (uploadFile is null) return;

            // Read the file
            var httpContent = new MultipartFormDataContent();
            httpContent.Add(new StreamContent(await uploadFile.OpenReadAsync()), "file", uploadFile.FileName);

            // Create instance of HttpClient
            var httpClient = new HttpClient();
            var result = await httpClient.PostAsync("https://localhost:7260/api/UlpoadFile", httpContent);
            var response = await result.Content.ReadAsStringAsync();

            this.UserImageSource = await FetchImage(uploadFile.FileName);
        }
        /*[COMMAND] GET USER IMAGE*/
        private async Task<ImageSource> FetchImage(string fileName)
        {
            try
            {
                var apiUrl = $"https://localhost:7260/api/UlpoadFile/{fileName}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(apiUrl);
                await Shell.Current.DisplayAlert("Response From Server", response.StatusCode.ToString(), "Ok");
                if (response.IsSuccessStatusCode)
                {
                    var imageStream = await response.Content.ReadAsStreamAsync();
                    var image = ImageSource.FromStream(() => imageStream);
                    return image;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /*[COMMAND] REGISTER USER TO DB*/
        [RelayCommand]
        public async Task RegisterUser()
        {
            /*FILE UPLOAD TO SERVER RESOURCES AND PATH IS INSERT INTO DATABASE*/
            string[] fileInfo = Utils.Utils.GetFileExtension(FileToUpload.FileName);
            fileInfo[0] = $"{Name.ToUpper()[0]}{Surname.ToUpper()[0]}_{Utils.Utils.GenerateRandomNumber(9)}.{fileInfo[1]}";

            await uploadFileRepository.UploadUserImage(FileToUpload, fileInfo[0]);

            /*CREATING USER WHICH WILL BE INSERTED TO DB*/
            User user = new User();
            user.Name = Name;
            user.Email = Email;
            user.Access = "user";
            user.Surname = Surname;
            user.Password = Password;
            user.Location = Location;
            user.ImagePath = fileInfo[0];
            user.BirthDate = DateOfBirth;
            user.PhoneNumber = PhoneNumber;
            await userRepository.Register(user);
        }


        //REGISTER VALIDATION
        public bool EntryValidation(string frame)
        {

            if (frame == "first")
            {
                Regex name_and_surname_regex = new Regex("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]{2,}$");

                /*NAME VALIDATION*/
                if (!String.IsNullOrWhiteSpace(Name))
                {
                    if (!name_and_surname_regex.IsMatch(Name))
                    {
                        NameError = true;
                        NameErrorText = "Pole imię musi mieć więcej niż 2 znaki!";
                    }
                    else
                    {
                        NameError = false;
                        NameErrorText = "";
                    }
                }
                else
                {
                    NameError = true;
                    NameErrorText = "Pole imię nie może być puste!";
                }

                /*SURNAME VALIDATION*/
                if (!String.IsNullOrWhiteSpace(Surname))
                {
                    if (!name_and_surname_regex.IsMatch(Surname))
                    {
                        SurnameError = true;
                        SurnameErrorText = "Pole nazwisko musi mieć więcej niż 2 znaki";
                    }
                    else
                    {
                        SurnameError = false;
                        SurnameErrorText = "";
                    }
                }
                else
                {
                    SurnameError = true;
                    SurnameErrorText = "Pole nazwisko nie może być puste!";
                }

                return NameError == true || SurnameError == true ? false : true;
            }
            else if (frame == "second")
            {
                Regex email_regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
                Regex phone_regex = new Regex(@"^\d{9}$");
                /*EMAIL VALIDATION*/
                if (!String.IsNullOrWhiteSpace(Email))
                {
                    if (!email_regex.IsMatch(Email))
                    {
                        EmailError = true;
                        EmailErrorText = "Niepoprawny email!";
                    }
                    else
                    {
                        EmailError = false;
                        EmailErrorText = "";
                    }
                }
                else
                {
                    EmailError = true;
                    EmailErrorText = "Pole email nie może być puste!";
                }

                /*PHONE NUMBER VALIDATION*/
                if (!String.IsNullOrWhiteSpace(PhoneNumber))
                {
                    if (!phone_regex.IsMatch(PhoneNumber))
                    {
                        PhoneNumberError = true;
                        PhoneNumberErrorText = "Niepoprawny numer telefonu!";
                    }
                    else
                    {
                        PhoneNumberError = false;
                        PhoneNumberErrorText = "";
                    }
                }
                else
                {
                    PhoneNumberError = true;
                    PhoneNumberErrorText = "Pole numer telefonu nie może być puste!";
                }

                return EmailError == true || PhoneNumberError == true ? false : true;
            }
            else if (frame == "third")
            {
                Regex password_regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#?!@$%^*-])[A-Za-z\d@$!%*?&]{8,}$");
                /*PASSWORD VALIDATION*/
                if (!String.IsNullOrWhiteSpace(Password))
                {
                    if (!password_regex.IsMatch(Password))
                    {
                        PasswordError = true;
                        PasswordErrorText = "Hasło musi się składać z dużych i małych liter , cyfr oraz zanków specjalnych!";
                    }
                    else
                    {
                        PasswordError = false;
                        PasswordErrorText = "";
                    }
                }
                else
                {
                    PasswordError = true;
                    PasswordErrorText = "Hasło nie może być puste!";
                }

                /*REPEAT PASSWORD VALIDATION*/
                if (!String.IsNullOrWhiteSpace(RepeatPassword))
                {
                    if (RepeatPassword != Password)
                    {
                        RepeatPasswordError = true;
                        RepeatPasswordErrorText = "Hasła różnią się od siebie!";
                    }
                    else
                    {
                        RepeatPasswordError = false;
                        RepeatPasswordErrorText = "";
                    }
                }
                else
                {
                    RepeatPasswordError = true;
                    RepeatPasswordErrorText = "Powtórz hasło!";
                }

                return PasswordError == true || RepeatPasswordError == true ? false : true;
            }
            else if (frame == "fourth")
            {
                if (Utils.Utils.CalculateAge(DateOfBirth) > 123 == false)
                {
                    DateOfBirthError = false;
                    DateOfBirthErrorText = "";
                }
                else
                {
                    DateOfBirthError = true;
                    DateOfBirthErrorText = "Ty jescze żyjesz!";
                }

                if (!String.IsNullOrWhiteSpace(Location))
                {
                    LocationError = false;
                    LocationErrorText = "";
                }
                else
                {
                    LocationError = true;
                    LocationErrorText = "Miejscowość zamieszkania nie może być pusta!";
                }

                return DateOfBirthError == true || LocationError == true ? false : true;
            }
            else if (frame == "fifth")
            {
                return true;
            }

            return false;
        }
    }
}
