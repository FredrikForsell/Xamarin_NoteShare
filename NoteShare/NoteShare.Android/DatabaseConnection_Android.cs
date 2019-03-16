using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NoteShare.Droid;
using NoteShare.Interfaces;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace NoteShare.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        

        public SQLiteConnection DbConnection()
        {
            var dbName = "LocalDb.db3";
            var path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.SpecialFolder.Personal), 
                dbName);
            return new SQLiteConnection(path);
        }
    }
}