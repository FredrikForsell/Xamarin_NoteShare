using System;
using System.Collections.Generic;
using System.Text;

namespace NoteShare.Interfaces
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
