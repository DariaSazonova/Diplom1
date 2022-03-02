using Diplom1.Client;
using Diplom1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Diplom1.ViewModels.Quest
{
    public class GetQuestQuestions 
    {
        public async Task<string> getQuestQuestions(int level)
        {
            if (GetClientConnection.CheckConnection())
            {
                using HttpClient client = new();
                HttpResponseMessage result = await client.GetAsync(RequestStrings.getQuestions(level));
                if (result.IsSuccessStatusCode)
                {
                    var js = result.Content.ReadAsStringAsync().Result;
                    return js;

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Ошибка", $"Ошибка {result.StatusCode} ", "ОК");
                    return null;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Нет подключения к интернету", "ОК");
                return null;
            }
        }
    }
}
