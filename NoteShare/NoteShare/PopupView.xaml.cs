using NoteShare.Database;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteShare
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupView
	{
        int elementid;
        public PopupView (int elementid)
		{
			InitializeComponent ();
            this.elementid = elementid;
        }
        public PopupView()
        {
            InitializeComponent();
        }

        public async void btn_submitAsync(object sender, ClickedEventArgs e)
        {
            String taskName = entry_taskName.Text;
            NoteContentDataAccess noteDB = new NoteContentDataAccess();

            NoteContent tempNoteContent = new NoteContent
            {
                NoteId = elementid,
                NoteItem = taskName
            };

            noteDB.AddNewNoteContent(tempNoteContent);

            //Remove popup
            await PopupNavigation.Instance.PopAsync(true);
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Send<App>((App)Application.Current, "OnSaveNote");
            base.OnDisappearing();
        }

        private void Entry_taskName_Focused(object sender, FocusEventArgs e)
        {
            entry_taskName.Text = null;

        }
    }
}