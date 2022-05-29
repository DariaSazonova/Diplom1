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
        public string error = "";
        public async Task<List<MediaPageModel>> get(string type)
        {
            if (GetClientConnection.CheckConnection())
            {
                using HttpClient client = new();
                HttpResponseMessage result = await client.GetAsync(RequestStrings.getMediaFiles(type));
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
                        error = "Не удалось получить данные";
                        return null;
                    }
                }
                else
                {
                    error = $"Ошибка сервера {result.StatusCode}";
                    return null;
                }
            }
            else
            {
                error = "Отсутствует интернет соединение";
                return null;
            }
        }
    }
}
