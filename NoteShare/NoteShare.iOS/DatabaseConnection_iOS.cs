using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using NoteShare.Interfaces;
using NoteShare.iOS;
using SQLite;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_iOS))]
namespace NoteShare.iOS
{

    public class DatabaseConnection_iOS : IDatabaseConnection{
        public SQLiteConnection DbConnection()
        {
            var dbName = "LocalDb.db3";
            string personalFolder =
                System.Environment.
                GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder =
                Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }

}