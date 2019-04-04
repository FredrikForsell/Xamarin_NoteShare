using NoteShare.Database;
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
    public partial class NoteView : ContentPage
    {
        
        IEnumerable<NoteContent> noteContents;
        NoteContentDataAccess noteDB = new NoteContentDataAccess();
        int elementid;


        public NoteView(int elementid, string title)
        {
            this.elementid = elementid;
            InitializeComponent();

            noteDB = new NoteContentDataAccess();
            updateList();

            Title = title;

            MessagingCenter.Subscribe<App>((App)Application.Current, "OnSaveNote", (sender) => {
                updateList();
            });


        }
        public void updateList()
        {
            noteContents = noteDB.GetFilteredNotes(elementid);
            noteMenu.ItemsSource = noteContents;
        }
        private async void addNoteContentAsync(object sender, ClickedEventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(
                new PopupView(elementid)
                );
            
        }


        private void DeleteAllNotes(object sender, EventArgs e)
        {
            noteDB.DeleteNoteContent();
            updateList();
        }
    }
}