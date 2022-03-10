using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediaPageView : ContentPage
    {
        public MediaPageView()
        {
            InitializeComponent();;
        }

        private void VideoPriem_Navigated(object sender, WebNavigatedEventArgs e)
        {
            Indicator.IsVisible = false;
        }

        private void VideoPriem_Navigating(object sender, WebNavigatingEventArgs e)
        {
            Indicator.IsVisible = true;
        }
    }
}