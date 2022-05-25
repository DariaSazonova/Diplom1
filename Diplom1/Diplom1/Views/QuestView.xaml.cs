using Diplom1.Client;
using Diplom1.Models;
using Diplom1.Toast;
using Diplom1.ViewModels.Quest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class QuestView : ContentPage
    {
        public QuestViewModel viewModel;
        private int count;
        private int Level;
        private List<Answers> answers = new();
        public QuestView(int level)
        {
            InitializeComponent();
            QuestViewModel vm = new(level);
            Level = level;
            viewModel = vm; 
            BindingContext = viewModel;

        }
        protected async override void OnAppearing()
        {
            if (viewModel.model.listQuestions.Count == 0)
            {
                Application.Current.MainPage.Toast("В этом тесте еще нет вопросов", status.warning);
                Application.Current.MainPage = new NavigationPage(new Views.HomePage());
            }
            base.OnAppearing();
            //await FadeAnimateY(QuestionList);
        }
        private static async Task FadeAnimateY(View view)
        {
            await Task.WhenAll
               (
                    view.FadeTo(1, 350),
                    view.TranslateTo(0, 0, 350)
               );
        }
       
        private async Task answerTapped(string answer)
        {
            try
            {
                List<QuestTestModel> viewModelList = new();
                ListButtons.ItemsSource = null;
                foreach (var i in viewModel.ListQuestions)
                {
                    if (i.answers.Contains(answer))
                    {

                        if (i.answers.ElementAt(Convert.ToInt32(i.answer)) == answer)
                            i.IsAnswered = true;
                        else i.IsAnswered = false;
                        i.accepted = true;
                        Answers a = new();
                        a.id = count;
                        a.trueAnswer = i.answer;
                        var yourAnswer = i.answers.Where(x => x == answer).FirstOrDefault().ToString();
                        a.yourAnswer = i.answers.IndexOf(yourAnswer).ToString();
                        answers.Add(a);
                        ListButtons.ItemsSource = i.answers;
                        viewModel.progress = 1f / viewModel.ListQuestions.Count();
                        viewModelList.Add(viewModel.model);
                        count++;
                        if (count != viewModel.model.listQuestions.Count())
                        {
                            //progressBar.Progress = 
                            ListButtons.ItemsSource = viewModel.Answers;
                            LabelQuestion.Text = viewModel.Question;
                        }
                    }

                }
            }
            catch(Exception e)
            {
                Application.Current.MainPage.Toast(e.Message, status.error);
            }

            if (count == viewModel.model.listQuestions.Count())
            {
                try
                {

                    viewModel.IndicatorIsVisible = true;
                    double countTrueAnswers = viewModel.model.listQuestions.Where(l => l.IsAnswered == true).Count();
                    double countAll = viewModel.model.listQuestions.Count();
                    var Result = Math.Round(countTrueAnswers / countAll, 3).ToString().Replace(",", ".");


                    using (HttpClient client = new())
                    {
                        string date = DateTime.Now.ToString();
                        var content = new StringContent(JsonConvert.SerializeObject(answers), Encoding.UTF8, "application/json");
                        var response = await client.PostAsync(RequestStrings.postQuestResult + $"?idquest={viewModel.idQuest}&idapplicatn={PreferencesApp.UserID}&res={Result}&date={date}", content);
                        if (response.IsSuccessStatusCode)
                        {
                            //await Application.Current.MainPage.DisplayAlert("Результа", $"{countTrueAnswers} из  {countAll}", "ок");

                            //await Navigation.PopAsync();
                            await Navigation.PushAsync(new QuestResult(Convert.ToInt32(countTrueAnswers), Convert.ToInt32(countAll), Level));
                            viewModel.IndicatorIsVisible = false;
                        }
                        else
                        {
                            Application.Current.MainPage.Toast($"Не удалось отправить данные\n {response.Content}", status.error);
                            Application.Current.MainPage = new Diplom1.Views.HomePage();
                            viewModel.IndicatorIsVisible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Application.Current.MainPage.Toast(ex.Message, status.error);
                    viewModel.IndicatorIsVisible = false;
                    Application.Current.MainPage = new Diplom1.Views.HomePage();
                }
            }

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
                (sender as Grid).TranslateTo(500, 0, 350)
            );
            (sender as Grid).TranslationX = 0;
            Label d = (Label)(sender as Grid).Children.Where(x => x is Label).FirstOrDefault();
            var d1 = d.Text;
            ListButtons.ItemsSource = null;
            await answerTapped(d1);
        }
    }
}