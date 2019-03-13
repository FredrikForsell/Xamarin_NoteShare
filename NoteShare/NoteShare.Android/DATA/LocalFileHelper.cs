using System;
using System.IO;
using Xamarin.Forms;
using NoteShare.DATA;
using NoteShare.Droid.DATA;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace NoteShare.Droid.DATA
{
    public class LocalFileHelper : ILocalFileHelper
    {

        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);

            
        }
    }
}