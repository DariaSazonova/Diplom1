using Diplom1.ViewModels.AbbRating;
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
    public partial class AbbRating : ContentPage
    {
        public AbbRatingViewModel viewModel;
        public AbbRating(int level, int appid=0)
        {
            InitializeComponent();
            viewModel = new(level, appid);
            BindingContext = viewModel;
        }
        private void StudentsRating_Refreshing(object sender, EventArgs e)
        {

        }

        private void StudentsRating_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void StudentsRating_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}