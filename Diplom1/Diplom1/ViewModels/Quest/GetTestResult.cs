using Diplom1.Client;
using Diplom1.Models;
using Diplom1.Toast;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diplom1.ViewModels.Quest
{
    public class GetTestResult
    {
        public GetTestResult()
        {

        }
        public async Task<List<TestResultModel>> Result(int applicantId, int idTest)
        {
            if (GetClientConnection.CheckConnection())
            {
                using HttpClient client = new();
                HttpResponseMessage result = await client.GetAsync(RequestStrings.getRating(Convert.ToInt32(applicantId), idTest));
                if (result.IsSuccessStatusCode)
                {
                    var res = await result.Content.ReadAsStringAsync();
                    if (!String.IsNullOrWhiteSpace(res))
                    {
                        List<QuestRatingModel> listRes = JsonConvert.DeserializeObject<List<QuestRatingModel>>(res);
                        var item = listRes[listRes.Count - 1];
                        List<Answers> listAnswers = JsonConvert.DeserializeObject<List<Answers>>(item.answers);
                        result = await client.GetAsync(RequestStrings.getQuestions(Convert.ToInt32(item.IdQuest)));
                        if (result.IsSuccessStatusCode)
                        {
                            res = await result.Content.ReadAsStringAsync();
                            if (!String.IsNullOrWhiteSpace(res))
                            {
                                var js = JObject.Parse(res);
                                List<Questions> listQuest = JsonConvert.DeserializeObject<List<Questions>>(js["questions"].ToString());
                                List<TestResultModel> TestResultModel = new();
                                var count = 0;
                                foreach(var i in listAnswers)
                                {
                                    TestResultModel answer = new();
                                    answer.question = listQuest[count].question;
                                    answer.trueAnswer = listQuest[count].answers[Convert.ToInt32(listQuest[count].answer)];
                                    answer.yourAnswer = listQuest[count].answers[Convert.ToInt32(listAnswers[count].yourAnswer)];
                                    answer.color = answer.trueAnswer== answer.yourAnswer?Color.Green:Color.Red;
                                    TestResultModel.Add(answer);
                                    count++;
                                }
                                return TestResultModel;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Предупреждение", $"Ошибка сервера {result.StatusCode}", "Ок");
                    return null;
                }
            }
            else
            {
                Application.Current.MainPage.Toast("Отсутствует интернет соединение", status.error);
                return null;
            }
        }
    }
}


