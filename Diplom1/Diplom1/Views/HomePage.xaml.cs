using Diplom1.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : FlyoutPage
    {
        public HomePage(string page = null)
        {
            InitializeComponent();
            if (page == null)
            {
                if (PreferencesApp.role == "Абитуриент")
                    Detail = new NavigationPage(new HomePageDetail());
                else if (PreferencesApp.role == "Администратор")
                    Detail = new NavigationPage(new HomePageDetailAdmin());
            }
            else
            {
                switch (page)
                {
                    case "level1": 
                        Detail = new NavigationPage(new QuestView(1));
                        break;
                    case "level2":
                        Detail = new NavigationPage(new QuestView(2));
                        break;
                    case "level3":
                        Detail = new NavigationPage(new QuestView(3));
                        break;
                    case "history":
                        int userId = Convert.ToInt32(PreferencesApp.UserID);
                        Detail = new NavigationPage(new AbbRating(0, userId));
                        break;
                }
               
            }

        }
    }
}