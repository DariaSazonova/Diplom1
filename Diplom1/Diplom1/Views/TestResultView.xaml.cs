using Diplom1.Models;
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
        public TestResultViewModel viewModel;
        public TestResultView(List<TestResultModel> list)
        {
            InitializeComponent();
            viewModel = new(list);
            BindingContext = viewModel;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listResults.SelectedItem = null;
        }
    }
}