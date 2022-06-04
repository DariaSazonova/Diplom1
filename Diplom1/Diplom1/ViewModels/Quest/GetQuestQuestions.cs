using Diplom1.Client;
using System.Net.Http;
using System.Threading.Tasks;

namespace Diplom1.ViewModels.Quest
{
    public class GetQuestQuestions 
    {
        public string error = "";
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
                    error = $"Ошибка {result.StatusCode} ";
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
