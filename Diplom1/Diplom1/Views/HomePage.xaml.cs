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
        public HomePage()
        {
            InitializeComponent();
            if (PreferencesApp.role == "Абитуриент")
                Detail = new NavigationPage(new HomePageDetail());
            else if (PreferencesApp.role == "Администратор")
                Detail = new NavigationPage(new HomePageDetailAdmin());

        }
    }
}