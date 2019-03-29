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

        public ObservableCollection<NoteContent> NoteContents
        {
            get;
            set;
        }

        public NoteContentDataAccess()
        {
            database =
               DependencyService.Get<IDatabaseConnection>().
               DbConnection();
            database.CreateTable<NoteContent>();

            this.NoteContents =
                new ObservableCollection<NoteContent>(database.Table<NoteContent>());

        }

        public void AddNewNoteContent(NoteContent noteContents)
        {
            lock (collisionLock)
            {
                database.Insert(noteContents);
                this.NoteContents.Add(
                new NoteContent
                {
                    NoteId = noteContents.NoteId,
                    NoteItem = noteContents.NoteItem
                });
            }

        }


        public bool DeleteNoteContent(NoteContent noteContents)
        {
            lock (collisionLock)
            {
                if (noteContents.NoteContentId != 0)
                {
                    database.Delete<NoteContent>(noteContents.NoteContentId);
                    this.NoteContents.Remove(noteContents);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IEnumerable<NoteContent> GetFilteredNotes(int noteId)
        {
            lock (collisionLock)
            {
                var query = from note in database.Table<NoteContent>()
                            where note.NoteId == noteId
                            select note;
                return query.AsEnumerable();
            }
        }
    }
}
