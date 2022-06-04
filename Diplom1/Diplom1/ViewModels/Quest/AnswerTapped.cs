using Diplom1.Client;
using Diplom1.Models;
using Diplom1.Toast;
using Diplom1.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diplom1.ViewModels.Quest
{
    public class AnswerTapped
    {
        private int count;
        private List<Answers> answers = new();
        public async Task answerTapped(string answer, QuestViewModel viewModel, int Level, ListView ListButtons, Label LabelQuestion)
        {
            try
            {
                List<QuestTestModel> viewModelList = new();
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
                        viewModel.progress = 1f / viewModel.ListQuestions.Count();
                        viewModelList.Add(viewModel.model);
                        count++;
                        if (count != viewModel.model.listQuestions.Count())
                        {
                            ListButtons.ItemsSource = viewModel.Answers;
                            LabelQuestion.Text = viewModel.Question;
                        }
                    }

                }
            }
            catch (Exception e)
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
                            Application.Current.MainPage = new QuestResult(Convert.ToInt32(countTrueAnswers), Convert.ToInt32(countAll), Level);
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
    }
}
