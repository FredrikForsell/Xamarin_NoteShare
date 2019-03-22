using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;
using SQLiteNetExtensions.Attributes;

namespace NoteShare.Database
{
    [Table("NoteContent")]
    public class NoteContent : INotifyPropertyChanged
    {

        #region NoteContentId

        private int _noteContentId;
        [PrimaryKey, AutoIncrement, Unique]
        public int NoteContentId
        {
            get
            {
                return _noteContentId;
            }
            set
            {
                this._noteContentId = value;

                OnPropertyChanged(nameof(NoteContentId));
            }
        }
        #endregion

        private int _noteId;

        [ForeignKey(typeof(Note)), NotNull]
        public int NoteId
        {
            get
            {
                return _noteId;
            }
            set
            {
                this._noteId = value;

                OnPropertyChanged(nameof(NoteId));
            }
        }

        #region NoteContent
        private string _noteItem;
        public string NoteItem
        {
            get
            {
                return _noteItem;
            }
            set
            {
                this._noteItem = value;

                OnPropertyChanged(nameof(NoteItem));
            }
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
