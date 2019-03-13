using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace NoteShare.DATA
{
    public class NotesDatabase
    {
        readonly SQLiteAsyncConnection database;

        public NotesDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Notes>();
        }




        public Task<List<Notes>> GetNotesAsync()
        {
            return database.Table<Notes>().ToListAsync();
        }

        public async Task<ObservableCollection<Notes>> GetItemsAsync()
        {
            var list = await database.Table<Notes>().ToListAsync();
            return new ObservableCollection<Notes>(list);
        }



        public Task<Notes> GetNotesAsync(int id)
        {
            return database.Table<Notes>().Where(i => i.NoteId == id).FirstOrDefaultAsync();
        }





        public Task<int> SaveNoteAsync(Notes note)
        {
            if (note.NoteId != 0)
            {
                return database.UpdateAsync(note);
            }
            else
            {
                return database.InsertAsync(note);
                
            }
        }





        public Task<int> DeleteNoteAsync(Notes note)
        {
            return database.DeleteAsync(note);
        }
    


    }
}
