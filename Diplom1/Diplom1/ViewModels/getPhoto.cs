using Diplom1.Client;
using Diplom1.Toast;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diplom1.ViewModels
{
    public class getPhoto
    {
        public string error = "";
        public async Task<string> get(string name)
        {
            if (GetClientConnection.CheckConnection())
            {
                using HttpClient client = new();
                HttpResponseMessage response = await client.GetAsync(RequestStrings.getPhotos+name);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return res;
                }
                else
                {
                    error = "Ошибка сервера";
                    return null;
                }

            }
            else
            {
                error = "Отутствует интернет соединение";
                return null;
            }
        }
    }
}
