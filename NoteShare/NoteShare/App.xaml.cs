using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoteShare.Database;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NoteShare
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("ODYxNjlAMzEzNzJlMzEyZTMwSUZoWlA3bjFLTTNva29zazZCdEx6M1h5dUllK1Y5QmhzY0NjcGxjRncrUT0=");
            InitializeComponent();

            MainPage = new HamburgerMenu();



        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
