using JobPortal.Maui.Controlls;
using JobPortal.Maui.Model;

namespace JobPortal.Maui
{
    public partial class App : Application
    {
        public static User user;
        //public static string apiDevTunnel = "https://3l8lk8z6-7260.euw.devtunnels.ms";
        public static string apiDevTunnel = "https://xlz15nb7-7260.euw.devtunnels.ms";
        //public static string apiDevTunnel = "https://2b68g0x3-7260.euw.devtunnels.ms";
        //public static string apiDevTunnel = "https://localhost:7260";
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
            });
        }
    }
}