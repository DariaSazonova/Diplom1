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
    public partial class QuestResult : ContentPage
    {
        private QuestResultViewModel vm;
        public QuestResult(int countTrueAnswers, int countAll, int level)
        {
            InitializeComponent();
            vm = new(countTrueAnswers, countAll, level);
            BindingContext = vm;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new HomePage());
        }
    }
}