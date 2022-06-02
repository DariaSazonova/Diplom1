
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Diplom1.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Diplom1.ViewModels
{
    public class GetInfoColledge
    {
        public string error = "";
        private string uri = "https://www.mgkit.ru/kolledz";
        public async Task<List<string>> get()
        {
            if (GetClientConnection.CheckConnection())
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        HttpContent content = response.Content;
                        string result = content.ReadAsStringAsync().Result;
                        //IHtmlDocument angle = new HtmlParser(result).Parse();
                        //foreach (IElement element in angle.QuerySelectorAll("h3.r a"))
                        //    Console.WriteLine(element.GetAttribute("href"));
                        //return result;
                        List<string> hrefTags = new();
                        var parser = new HtmlParser();
                        var document = parser.ParseDocument(result);
                        foreach (IElement element in document.QuerySelectorAll("p"))
                        {
                            hrefTags.Add(element.Text());
                        }
                        return hrefTags;
                    }
                    else
                    {
                        error = "Отсутствует соединение с сайтом";
                        return null;
                    }
                }

                return null;

            }
            else
            {
                error = "Отсутствует интернет соединение";
                return null;
            }

        }
    }
}
