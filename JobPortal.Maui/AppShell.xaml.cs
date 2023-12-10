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
        }

        public async static void UpdateUi()
        {
            Shell.Current.BindingContext = User;
            userImage.Source = await uploadFileService.ImportUserImage(User.ImagePath);
            if(User.Access != "admin" && User.Access != "employer")
            {
                jobOfertShellContent.FlyoutItemIsVisible = false;
                jobOfertShellContent.IsEnabled = false;
            }
        }
    }
}