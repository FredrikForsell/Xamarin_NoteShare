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
	public partial class SfList_Testing : ContentPage
	{
		public SfList_Testing ()
		{
			InitializeComponent ();
            MyMenu();
		}

        public class Name { public string name { get; set; } }

        //Creatin a collection for all notes (list doesnt update list automatically)
        ObservableCollection<Note> notes = new ObservableCollection<Note>();




        public void MyMenu()
        {
            notes.Add(new Note { Title = "Games", Description = "Stuff to remember", icon = "images.png", Id_Note = 1 });
            notes.Add(new Note { Title = "HomeWork", Description = "Todo", icon = "images.jpg", Id_Note = 2 });
            notes.Add(new Note { Title = "Traveldestinations", Description = "Places to travel", icon = "sunset.png", Id_Note = 3 });
            notes.Add(new Note { Title = "Movies I like", Description = "List", icon = "images.png", Id_Note = 4 });
            notes.Add(new Note { Title = "Movies I want to see", Description = "TODO", icon = "sunset.png", Id_Note = 5 });
            notes.Add(new Note { Title = "Games", Description = "Stuff to remember", icon = "images.png", Id_Note = 1 });
            notes.Add(new Note { Title = "HomeWork", Description = "Todo", icon = "images.jpg", Id_Note = 2 });
            notes.Add(new Note { Title = "Traveldestinations", Description = "Places to travel", icon = "sunset.png", Id_Note = 3 });
            notes.Add(new Note { Title = "Movies I like", Description = "List", icon = "images.png", Id_Note = 4 });
            notes.Add(new Note { Title = "Movies I want to see", Description = "TODO", icon = "sunset.png", Id_Note = 5 });



            //noteMenu.IsPullToRefreshEnabled = true;
            noteMenu.ItemsSource = notes; //Binding for menu
        }

        public class Note
        {
            public string Title
            {
                get;
                set;
            }

            public string Description
            {
                get;
                set;
            }
            public ImageSource icon
            {
                get;
                set;
            }

            public int Id_Note
            {
                get;
                set;
            }
        }

        private void NoteMenu_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                //  IsPresented = false;
                // Detail = new NavigationPage(notes.Page);
                // DisplayAlert("Id_Note", notes.ToString(), "OK");


            }
        }


      

        private void tap_expand(object sender, EventArgs e)
        {
            DisplayAlert("Expand", "", "OK");
        }
        private void img_tapped_upload(object sender, EventArgs e)
        {
            DisplayAlert("Expand", "", "OK");


            // btn_uploadIconAsync(); then iconPreview.Source = icon
        }
    }
}