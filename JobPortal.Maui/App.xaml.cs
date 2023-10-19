using JobPortal.Maui.Model;

namespace JobPortal.Maui
{
    public partial class App : Application
    {
        public static User user;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}