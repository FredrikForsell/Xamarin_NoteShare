using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace NoteShare.DATA
{




    public class Notes
    {

        [PrimaryKey, AutoIncrement]
        public int NoteId
        {
            get;
            set;
        }

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

        public string Content
        {
            get;
            set;
        }


        public string Icon
        {
            get;
            set;
        }

        public bool Content_isVisible
        {
            get;
            set;
        }

    }
}
