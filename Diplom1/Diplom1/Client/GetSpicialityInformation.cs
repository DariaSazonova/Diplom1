using Diplom1.Models;
using Diplom1.Toast;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diplom1.Client
{
    public class GetSpicialityInformation
    {
        public async Task<List<MediaPageModel>> get()
        {
            if (GetClientConnection.CheckConnection())
            {
                using HttpClient client = new();
                HttpResponseMessage result = await client.GetAsync(RequestStrings.getMediaFilesSpecialityInformation);
                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync().Result;
                    if (content != null)
                    {
                        var res = JsonConvert.DeserializeObject<List<MediaPageModel>>(content);
                        return res;
                    }
                    else
                    {
                        Application.Current.MainPage.Toast("Не удалось получить данные", status.error);
                        return null;
                    }
                }
                else
                {
                    //await Application.Current.MainPage.DisplayAlert("Предупреждение", $"Ошибка сервера {result.StatusCode}", "Ок");
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
