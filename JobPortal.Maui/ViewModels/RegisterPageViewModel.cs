using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.ViewModels
{
    public partial class RegisterPageViewModel : ObservableObject
    {
        /*REGISTER PROPERTIES*/
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private bool nameError = false;
        [ObservableProperty]
        private string surname;
        [ObservableProperty]
        private bool surnameError = false;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string phoneNumber;
        [ObservableProperty]
        private string location;
        [ObservableProperty]
        private DateTime dateOfBirth;


        /*UI PROPERTIES*/
        [ObservableProperty]
        private int step = 0;
        [ObservableProperty]
        private bool isBusy;
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
            IsBusy = true;
            Step--;
            await Task.Delay(550);
            IsBusy = false;
            EntryValidation(frame);
        }


        public bool EntryValidation(string frame)
        {
            if (frame == "first")
            {
                if(Name.Length < 5)
                {
                    NameError = true;
                }
                else
                {
                    NameError = false;
                }

                if (Surname.Length < 5)
                {
                    SurnameError = true;
                }
                else
                {
                    SurnameError = false;
                }

                return NameError == true || SurnameError == true ? false : true;
            }
            else if(frame == "second")
            {
                
            }

            return false;
        }
    }
}
