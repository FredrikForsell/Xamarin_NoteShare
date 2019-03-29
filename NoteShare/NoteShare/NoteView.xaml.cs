using NoteShare.Database;
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

        public NoteView()
        {
            InitializeComponent();
        }

        public NoteView(int elementid)
        {
            this.elementid = elementid;
            InitializeComponent();

            noteDB = new NoteContentDataAccess();
            updateList();


        }
        public void updateList()
        {
            noteContents = noteDB.GetFilteredNotes(elementid);
            noteMenu.ItemsSource = noteContents;
        }
        private void addNoteContent(object sender, ClickedEventArgs e)
        {
            NoteContent tempNoteContent = new NoteContent
            {
                NoteId = elementid,
                NoteItem = "Test"
            };

            noteDB.AddNewNoteContent(tempNoteContent);
            updateList();


        }
    }
}