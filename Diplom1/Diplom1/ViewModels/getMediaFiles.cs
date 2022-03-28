using Diplom1.Client;
using Diplom1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diplom1.ViewModels
{
    public class getMediaFiles
    {
        public async Task<List<MediaPageModel>> get()
        {
            if (GetClientConnection.CheckConnection())
            {
                using HttpClient client = new();
                var response = await client.GetAsync(RequestStrings.getMediaFiles);
                if (response.IsSuccessStatusCode)
                {
                    var js = response.Content.ReadAsStringAsync().Result;
                    List<MediaPageModel> list = JsonConvert.DeserializeObject<List<MediaPageModel>>(js);
                    return list;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Ошибка", "Не удалось получить данные с сервера", "ОК");
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
