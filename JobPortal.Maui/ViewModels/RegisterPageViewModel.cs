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
        [ObservableProperty]
        private int step = 0;
        [ObservableProperty]
        private bool isBusy;
        [RelayCommand]
        public async Task NextStep()
        {
            IsBusy = true;
            Step++;
            await Task.Delay(600);
            IsBusy = false;
        }
    }
}
