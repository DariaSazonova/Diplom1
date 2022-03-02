using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoCollegeView : ContentPage
    {
        public InfoCollegeView()
        {
            InitializeComponent();
        }

        private async void Button_ClickedTelegram(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://t.me/ukit_college");
        }

        private async void Button_ClickedInstagram(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://www.instagram.com/ukit_college/");
        }
    }
}