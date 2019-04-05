using Plugin.Media;
using Plugin.Media.Abstractions;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.ListView.XForms.Control.Helpers;
using NoteShare.Database;
using TEditor.Abstractions;
using TEditor;
using System.ComponentModel;
using Rg.Plugins.Popup.Services;

namespace NoteShare
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        //Commented to test if i can delete
        //public class Name {
        //    public string name {
        //        get;
        //        set;
        //    }
        //}

        Note swipedItem;


        //Creatin a collection for all notes (list doesnt update list automatically)
        ObservableCollection<Note> notes = new ObservableCollection<Note>();
        NoteDataAccess noteDB = new NoteDataAccess();

        public bool IsPresented { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            Title = "NoteShare";
            NavigationPage.SetHasNavigationBar(this, false);
            //this.BarBackgroundColor = Color.FromHex("33566D");

            //Updating the list
            MyMenuAsync();

            MessagingCenter.Subscribe<App>((App)Application.Current, "OnAddNote", (sender) => {
                // Updating ListView
                MyMenuAsync();

                DisplayAlert("Congrats", "The note has been created", "Ok");
            });
        }


        public void MyMenuAsync()
        {
            //noteDB to fix bug where ID isnt fetched (possibly due to autoIncrement)
            noteDB = new NoteDataAccess();

            notes = noteDB.Notes;
            noteMenu.ItemsSource = notes;
        }

        #region Tab 1
        public double SwipeOffset { get; set; }

        //Setting size of LeftSwipe
        private void ListView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Width" && noteMenu.Orientation == Orientation.Vertical && noteMenu.SwipeOffset != noteMenu.Width)
            {
                noteMenu.SwipeOffset = noteMenu.Width / 2.5;
            }
            else if (e.PropertyName == "Height" && noteMenu.Orientation == Orientation.Horizontal && noteMenu.SwipeOffset != noteMenu.Height)
            {
                noteMenu.SwipeOffset = noteMenu.Height;
            }

        }
        private async void SfListVIew_OnTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {

            if (e.ItemData != null)
            {
                //reading the elementvalues from the selected list item:
                Note tappeditem = e.ItemData as Note;
                bool iscontentvisible = tappeditem.Content_isVisible;
                int elementid = Convert.ToInt32(tappeditem.NoteId);
                var currentindex = noteMenu.DataSource.DisplayItems.IndexOf(tappeditem);

                await Navigation.PushAsync(new NoteView(elementid, tappeditem.Title));
            }


        }

        private void NoteMenu_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            //Saves the current note that is swiped.

            swipedItem = e.ItemData as Note;
            //Can now run functions that use the note //Example: OnTapDelete




        }

        public void OnTapDelete(object sender, EventArgs e)
        {
            if (swipedItem != null)
            {
                bool deleteCheck = noteDB.DeleteNote(swipedItem);

                noteMenu.ResetSwipe();
                MyMenuAsync();
            }
        }

        public async void OnTapEditListItem(object sender, EventArgs e)
        {
            if (swipedItem != null)
            {
                await Navigation.PushAsync(new EditListItem(swipedItem));

            }
        }





        #endregion

        private async void addNoteAsync(object sender, EventArgs e)
        {

            await PopupNavigation.Instance.PushAsync(
                    new AddNoteView()
                    );

        }
    }
}