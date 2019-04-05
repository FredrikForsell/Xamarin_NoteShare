using NoteShare.Database;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteShare
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNoteView
	{

        ObservableCollection<Note> notes = new ObservableCollection<Note>();
        ImageSource currentImage;
        string imageLocation;
        NoteDataAccess noteDB = new NoteDataAccess();


        public AddNoteView ()
		{
			InitializeComponent ();
		}

        private void Btn_newNote(object sender, ClickedEventArgs e)
        {
            String title = entry_Title.Text;
            String description = entry_Description.Text;

            Note tempNote = new Note
            {
                Title = title,
                Description = description,
                Content = "alal lalal lalal all alla lalla lalal lalal alll content",
                Icon = imageLocation,
                Content_isVisible = false
            };

            noteDB.AddNewNote(tempNote);

            //Tell Mainpage that there has been added a new note
            MessagingCenter.Send<App>((App)Application.Current, "OnAddNote");
        }


        private void clearDatabase(object sender, EventArgs e)
        {
            //Dropping the noteDB table
            //noteDB.DropTable();

            //Updating the listView
            //MyMenuAsync();
        }

        private void Entry_Title_Focused(object sender, FocusEventArgs e)
        {
            entry_Title.Text = null;
        }

        private void Entry_Description_Focused(object sender, FocusEventArgs e)
        {
            entry_Description.Text = null;
        }

        private void img_tapped_upload(object sender, EventArgs e)
        {
            


            // btn_uploadIconAsync(); then iconPreview.Source = icon
        }



        #region Xamaring Plugin Media
        private async void Btn_takePicIconAsync(object sender, EventArgs e)
        {

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "NoteShare_icon",
                SaveToAlbum = true,
                CompressionQuality = 15,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Rear
            });

            if (file == null)
                return;


            // await DisplayAlert("File Location", file.Path, "OK");
            imageLocation = file.Path;

            currentImage = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;

            });
            iconPreview.Source = currentImage;


        }


        private async void Btn_uploadIconAsync(object sender, EventArgs e)
        {

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                CompressionQuality = 15,
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,

            });


            if (file == null)
                return;

            imageLocation = file.Path;
            currentImage = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
            iconPreview.Source = currentImage;

        }
        #endregion
    }
}
