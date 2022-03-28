using Diplom1.Client;
using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

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
                using HttpClient client = new();
                HttpResponseMessage response = await client.PutAsync(RequestStrings.putQuestions(), new StringContent(
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
                vm.IndicatorIsVisible = false;
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Нет подключения к интернету", "ОК");
                return false;
            }
        }
    }
}
