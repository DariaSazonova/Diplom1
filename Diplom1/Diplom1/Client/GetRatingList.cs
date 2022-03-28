using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Diplom1.Models;
using Diplom1.ViewModels.AbbRating;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Diplom1.Client
{
    public class GetRating
    {
        public async Task<string> GetRatingList( int level, int applicantid)
        {
            if (GetClientConnection.CheckConnection())
            {
                using HttpClient client = new();
                HttpResponseMessage result = await client.GetAsync(RequestStrings.getAbbRating(level, applicantid));
                if (result.IsSuccessStatusCode)
                {
                    var res = await result.Content.ReadAsStringAsync();
                    if (!String.IsNullOrWhiteSpace(res))
                    {
                        return res;
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
                await Application.Current.MainPage.DisplayAlert("Предупреждение", "Отсутствует интернет соединение", "Ок");
                return null;
            }
            
        }
       
    }
}
