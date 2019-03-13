using System;
using System.Collections.Generic;
using System.Text;

namespace NoteShare.DATA
{
    public interface ILocalFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
