using Diplom1.Toast;
using Diplom1.ViewModels.Quest;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class QuestView : ContentPage
    {
        public QuestViewModel viewModel;
        private int Level;
        public QuestView(int level)
        {
            InitializeComponent();
            QuestViewModel vm = new(level);
            Level = level;
            viewModel = vm; 
            if(viewModel.idQuest!=0)
                BindingContext = viewModel;

        }
        protected override void OnAppearing()
        {
            if (viewModel.idQuest != 0)
            {
                if (viewModel.model.listQuestions.Count == 0)
                {
                    Application.Current.MainPage.Toast("В этом тесте еще нет вопросов", status.warning);
                    Application.Current.MainPage = new NavigationPage(new Views.HomePage());
                }
            }
            else
            {
                Application.Current.MainPage.Toast(viewModel.getQuestions.error, status.error);
                Application.Current.MainPage = new NavigationPage(new Views.HomePage());
            }
            base.OnAppearing();
        }

        private void ListButtons_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListButtons.SelectedItem = null;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Task.WhenAll
            (
                (sender as Grid).FadeTo(1, 350),
                (sender as Grid).TranslateTo(1000, 0, 350)
            );
            (sender as Grid).TranslationX = 0;
            Label d = (Label)(sender as Grid).Children.Where(x => x is Label).FirstOrDefault();
            var d1 = d.Text;
            ListButtons.ItemsSource = null;
            await viewModel.AnswerTapped.answerTapped(d1,viewModel, Level, ListButtons, LabelQuestion);
        }
    }
}