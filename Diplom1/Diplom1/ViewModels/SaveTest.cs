using Diplom1.Client;
using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using Diplom1.Toast;

namespace Diplom1.ViewModels
{
    public class questionsToSave
    {
        public string question { get; set; }
        public IEnumerable<string> answers { get; set; }
        public string answer { get; set; }
    }
    public class QuestModelToSave
    {
        public int idQuest { get; set; }
        public string questions { get; set; }
    }
    public class SaveTest
    {
        public async Task<bool> Save(TestUpdateViewModel vm)
        {
            vm.IndicatorIsVisible = true;
            if (GetClientConnection.CheckConnection())
            {
                List<questionsToSave> listquest = new();
                foreach(var item in vm.listQuestions)
                {
                    questionsToSave newItem = new()
                    {
                        question = item.question,
                        answers = item.answers,
                        answer = item.answer
                    };
                    listquest.Add(newItem);
                }
                var jslistquest = JsonConvert.SerializeObject(listquest);
                QuestModelToSave model = new()
                {
                    idQuest = vm.idQuest,
                    questions = jslistquest
                };
                var t = new StringContent(
                   JsonConvert.SerializeObject(model),
                    Encoding.UTF8, "application/json").ReadAsStringAsync().Result;
                using HttpClient client = new();
                HttpResponseMessage response = await client.PutAsync(RequestStrings.putQuestions(), new StringContent(
                   JsonConvert.SerializeObject(model),
                    Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                   response = await client.PostAsync(RequestStrings.putQuestions(), new StringContent(
                   JsonConvert.SerializeObject(model),
                    Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                vm.IndicatorIsVisible = false;
                Application.Current.MainPage.Toast("Нет подключения к интернету", status.error);
                return false;
            }
        }
    }
}
