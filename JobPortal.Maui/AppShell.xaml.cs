using JobPortal.Maui.Model;
using JobPortal.Maui.Repository;
using JobPortal.Maui.ViewModels;
using System.ComponentModel;

namespace JobPortal.Maui
{
    public partial class AppShell : Shell
    {
        private static IFileOperationRepository uploadFileService = new FileOperationsService();
        private static Image userImage;
        private static ShellContent jobOfertShellContent;
        private static ShellContent currentApplicationsShellContent;
        private static ShellContent favouriteJobOfertsShellContent;
        private static User user;
        public static User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                UpdateUi();
            }
        }
        public AppShell()
        {
            InitializeComponent();
            userImage = userProfileImage;
            jobOfertShellContent = jobOfertShellContentControll;
            currentApplicationsShellContent = currentApplicationsShellContentControll;
            favouriteJobOfertsShellContent = favouriteJobOfertsShellContentControll;
        }

        public async static void UpdateUi()
        {
            Shell.Current.BindingContext = User;
            userImage.Source = await uploadFileService.ImportUserImage(User.ImagePath);
            if(User.Access != "admin" && User.Access != "employer")
            {
                jobOfertShellContent.FlyoutItemIsVisible = false;
                jobOfertShellContent.IsEnabled = false;
                currentApplicationsShellContent.FlyoutItemIsVisible = true;
                currentApplicationsShellContent.IsEnabled = true;
                favouriteJobOfertsShellContent.FlyoutItemIsVisible = true;
                favouriteJobOfertsShellContent.IsEnabled = true;
            }
            else
            {
                currentApplicationsShellContent.FlyoutItemIsVisible = false;
                currentApplicationsShellContent.IsEnabled = false;
                favouriteJobOfertsShellContent.FlyoutItemIsVisible = false;
                favouriteJobOfertsShellContent.IsEnabled = false;
            }

        }
    }
}