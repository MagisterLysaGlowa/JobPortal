using JobPortal.Maui.Controlls;
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

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
            });
        }
    }
}