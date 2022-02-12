using Diplom1.ViewModels;
using Diplom1.ViewModels.AvtorizationViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageFlyout : ContentPage
    {
        private HomePageViewModel vm = new();
        public HomePageFlyout()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        
    }
}