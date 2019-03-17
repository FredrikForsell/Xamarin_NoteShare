using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NoteShare.Database
{
    [Table("Note")]
    public class Note: INotifyPropertyChanged
    {

        #region NoteId
        private int _noteId;
        [PrimaryKey, AutoIncrement, Unique]
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
        #endregion

        #region Title
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                this._title = value;

                OnPropertyChanged(nameof(Title));
            }
        }
        #endregion

        #region Description
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                this._description = value;

                OnPropertyChanged(nameof(Description));
            }
        }
        #endregion

        #region Content
        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                this._content = value;

                OnPropertyChanged(nameof(Content));
            }
        }
        #endregion

        #region Icon
        private string _icon;
        public string Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                this._icon = value;

                OnPropertyChanged(nameof(Icon));
            }
        }
        #endregion

        #region Content_isVisible
        private bool _content_isVisible;
        public bool Content_isVisible
        {
            get
            {
                return _content_isVisible;
            }
            set
            {
                this._content_isVisible = value;

                OnPropertyChanged(nameof(Content_isVisible));
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
