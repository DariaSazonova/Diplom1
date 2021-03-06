using Diplom1.Client;
using Diplom1.Models;
using Diplom1.Toast;
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
        public string error = "";
        public async Task<List<MediaPageModel>> get()
        {
            if (GetClientConnection.CheckConnection())
            {
                using HttpClient client = new();
                var response = await client.GetAsync(RequestStrings.getMediaFiles());
                if (response.IsSuccessStatusCode)
                {
                    var js = response.Content.ReadAsStringAsync().Result;
                    List<MediaPageModel> list = JsonConvert.DeserializeObject<List<MediaPageModel>>(js);
                    return list;
                }
                else
                {
                    error = "Не удалось получить данные с сервера";
                    return null;
                }
            }
            else
            {
                error = "Нет подключения к интернету";
                return null;
            }
        }
    }
}
