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
    public class NoteDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Note> Notes
        {
            get;
            set;
        }

        public NoteDataAccess()
        {
            database =
                DependencyService.Get<IDatabaseConnection>().
                DbConnection();
            database.CreateTable<Note>();

            this.Notes =
                new ObservableCollection<Note>(database.Table<Note>());

            //If the table is empty
            if (!database.Table<Note>().Any())
            {
                //Create an empty note for testing purposes
                //AddNewNote();
            }
        }


        //Adds an already defined note
        public void AddNewNote()
        {
            //this note is not inserted into the table
            //Added to the list so it will display 
            this.Notes.Add(
                new Note
                {
                    Title = "Note title...",
                    Description = "Note name...",
                }
                );
        }

        public void AddNewNote(Note notes)
        {
            lock (collisionLock)
            {
                database.Insert(notes);
                this.Notes.Add(
                new Note
                {
                    Title = notes.Title,
                    Description = notes.Description,
                    Content = notes.Content,
                    Content_isVisible = notes.Content_isVisible,
                    Icon = notes.Icon,

                });
            }

        }

        public bool DeleteNote(Note notes)
        {
            lock (collisionLock)
            {
                if(notes.NoteId != 0)
                {
                    database.Delete<Note>(notes.NoteId);
                    this.Notes.Remove(notes);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void InsertNote(Note notes)
        {
            lock (collisionLock)
            {
                foreach (var noteInstance in this.Notes)
                {
                    if (noteInstance.NoteId == notes.NoteId){
                        database.Update(noteInstance);
                        this.Notes = new ObservableCollection<Note>(database.Table<Note>());
                    }
                }
            }
        }

        //Dropping the table
        public void DropTable()
        {
            lock (collisionLock)
            {
                //Dropping and recreating table
                database.DropTable<Note>();
                database.CreateTable<Note>();
            }
            //Creating a new list for all notes
            this.Notes = null;
            this.Notes = new ObservableCollection<Note>(database.Table<Note>());
        }


        //Example of queries
        public ObservableCollection<Note> GetAllNotes()
        {
            lock (collisionLock)
            {
                //var query = from note in database.Table<Note>()
                //            select note;
                //return query.AsEnumerable().ToList();
                Notes = new ObservableCollection<Note>(
                    from all in database.Table<Note>() select all
                    );
                return Notes;

            }
        }

        //Example of queries
        public IEnumerable<Note> GetFilteredNotes(string Name)
        {
            lock (collisionLock)
            {
                var query = from note in database.Table<Note>()
                            where note.Title == Name
                            select note;
                return query.AsEnumerable();
            }
        }

        //Example of SQL queries
        public IEnumerable<Note> GetFilteredNotes()
        {
            lock (collisionLock)
            {
                return database.
                    Query<Note>
                    ("SELECT * FROM Item WHERE Name = 'family'")
                    .AsEnumerable();
            }
        }
    }
}
