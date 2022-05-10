using Diplom1.Client;
using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Linq;
using Diplom1.Toast;

namespace Diplom1.ViewModels.Quest
{
    public class GetQuestResult
    {
        public async Task<string> getRatingApplicant(QuestResultViewModel vm, int level)
        {
            vm.IndicatorIsVisible = true;
            if (GetClientConnection.CheckConnection())
            {
                string toReturn;
                using HttpClient client = new();
                HttpResponseMessage response = await client.GetAsync(RequestStrings.getRating(Convert.ToInt32(PreferencesApp.UserID)));
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    List<QuestRatingModel> listRes = JsonConvert.DeserializeObject<List<QuestRatingModel>>(result);
                    if (listRes.Count > 1)
                    {
                        listRes = listRes.Where(s=>s.IdQuest==level).OrderByDescending(el => el.id).ToList();
                        if (listRes.Count == 1)
                        {
                            toReturn = "Это Ваша первая попытка)";
                        }
                        else if (Convert.ToDouble(listRes[0].Result) > Convert.ToDouble(listRes[1].Result))
                        {
                            toReturn = "Поздравляем вы улучшили свой результат!";
                        }
                        else if (Convert.ToDouble(listRes[0].Result) == 1)
                        {
                            toReturn = "Отличный результат!";
                        }
                        else if(Convert.ToDouble(listRes[0].Result) == 0)
                        {
                            toReturn = "К сожалению в прошлый раз Ваш результат был лучше.\n Но Вы всегда можете попробовать еще раз!";
                            
                        }
                        else if (listRes[0].Result == listRes[1].Result)
                        {
                            toReturn = "Стабильность признак мастерства!";
                        }
                        else
                        {
                            toReturn = "К сожалению в прошлый раз Ваш результат был лучше.\n Но Вы всегда можете попробовать еще раз!";
                        }
                    }
                    else
                    {
                        toReturn = "Это Ваша первая попытка)";
                    }
                    vm.IndicatorIsVisible = false;
                    return toReturn;

                }
                else
                {
                    vm.IndicatorIsVisible = false;
                    Application.Current.MainPage.Toast($"Ошибка {response.StatusCode} ", status.error);
                    return null;
                }
            }
            else
            {
                vm.IndicatorIsVisible = false;
                Application.Current.MainPage.Toast("Нет подключения к интернету", status.error);
                return null;
            }
        }
    }
}
