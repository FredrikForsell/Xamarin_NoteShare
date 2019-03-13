using NoteShare.DATA;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NoteShare
{
    public partial class App : Application
    {
        static NotesDatabase database;
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTY1NzJAMzEzNjJlMzQyZTMwUkI3bmpiTFNYYmJZcDZyd3MvY1YrRVRxZEk4a0VUS3ZIY1FlUFViT0dBaz0=");
            InitializeComponent();

            MainPage = new HamburgerMenu();

        }

        public static NotesDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NotesDatabase(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("Notes.db3"));
                }
                return database;
            }
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
