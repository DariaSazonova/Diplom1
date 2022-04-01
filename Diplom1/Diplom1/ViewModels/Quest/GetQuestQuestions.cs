using Diplom1.Client;
using Diplom1.Models;
using Diplom1.Toast;
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
            await Task.Delay(1000);
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
                    Application.Current.MainPage.Toast($"Ошибка {result.StatusCode} ", status.error);
                    return null;
                }
            }
            else
            {
                Application.Current.MainPage.Toast("Нет подключения к интернету", status.error);
                return null;
            }
        }
    }
}
