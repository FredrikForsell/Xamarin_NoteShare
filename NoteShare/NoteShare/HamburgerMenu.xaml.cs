using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteShare
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HamburgerMenu : MasterDetailPage
	{
		public HamburgerMenu ()
		{
			InitializeComponent ();
            MyMenu();
		}



        public void MyMenu()
        {
            var nav = new NavigationPage();
            nav.PushAsync(new MainPage());
            // nav.BarBackgroundColor = Color.Black;
            // nav.BarTextColor = Color.White;

            Detail = nav;

            // Detail = new NavigationPage(new Games_redirectPage()); //Homepage


            List<Menu> menu = new List<Menu> { 
                //Create menu items
                
                new Menu {Page = new MainPage(), MenuTitle = "Main page", MenuDetail = "Original", icon = "note.png"},
                new Menu {Page = new HtmlWebView(), MenuTitle = "Html", MenuDetail = "Testing", icon = "note.png"},
                new Menu {Page = new MainPage(), MenuTitle = "New Note", MenuDetail = "Testing", icon = "note.png"},
                new Menu {Page = new About_ThirdPartyLibraries(), MenuTitle = "Libraries", MenuDetail = "Third party libraries", icon = "note.png"},
            };
            ListMenu.ItemsSource = menu;
        }

        private void HamburgerMenu_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);


            }
        }


        public class Menu
        {
            public string MenuTitle
            {
                get;
                set;
            }

            public string MenuDetail
            {
                get;
                set;
            }

            public ImageSource icon
            {
                get;
                set;
            }

            public Page Page
            {
                get;
                set;
            }
        }
    }
}