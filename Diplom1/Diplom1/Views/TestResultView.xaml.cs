using Diplom1.ViewModels.Quest;
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
    public partial class TestResultView : ContentView
    {
        public TestResultViewModel viewModel = new();
        public TestResultView()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listResults.SelectedItem = null;
        }
    }
}