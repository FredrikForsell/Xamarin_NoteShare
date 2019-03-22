using NoteShare.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NoteShare.Database
{
    public class NoteContentDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public NoteContentDataAccess()
        {


        }

        

    }
}
