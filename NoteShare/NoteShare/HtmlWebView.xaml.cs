using NoteShare.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteShare
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HtmlWebView : ContentPage
    {
        String htmlDatabase = "Empty";

        String html_Start = "<html>";
        String html_End = "</html>";

        String head_Start = "<head>";
        String head_End = "</head>";

        String title_Start = "<title>";
        String title_End = "</title>";

        String style_Start = "<style>";
        String style_End = "</style>";

        String body_Start = "<body>";
        String body_End = "</body>";

        String h1_Start = "<h1>";
        String h1_End = "</h1>";

        String body_Content = "<h1>Notes</h1>";
        String body_DefaultContent;

        public HtmlWebView()
        {
            InitializeComponent();

            HtmlExecute(htmlDatabase);
        }

        private void HtmlExecute(string htmlDatabase)
        {
            body_Content = "<h1>Notes will be edited here</h1>";
            body_DefaultContent = 
                @"<div class='footer'>
                    <p>Footer</p>
                </div>";
            htmlDatabase = htmlBuild(body_Content);

            var browser = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = htmlDatabase;
            browser.Source = htmlSource;

            Content = browser;
        }

        private String htmlBuild(String body_Content)
        {
            htmlDatabase =
                html_Start +
                head_Start +
                title_Start +
                "Editing note" +
                title_End +
            style_Start;

            
            /* Reference to the css resource file NoteCSS*/
            ResourceManager MyResourceClass = new ResourceManager(typeof(Resources));
            ResourceSet resourceSet = NoteCSS.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
           
            //Importing default css items
            foreach (DictionaryEntry entry in resourceSet)
            {
                htmlDatabase += entry.Value;
            }

            //Continoue making a complete html string
            htmlDatabase +=
                style_End +
                head_End +
                body_Start +
                body_DefaultContent +
                body_Content +
                "test"+
                body_End +
                html_End;

            return htmlDatabase;
        }
    }
}