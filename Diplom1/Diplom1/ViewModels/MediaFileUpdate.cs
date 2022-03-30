using Diplom1.Client;
using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Diplom1.ViewModels
{
    public  class MediaFileUpdate
    {
        public async Task<bool> Update(MediaFileRedactViewModel vm)
        {
            vm.Indicator = true;
            if (GetClientConnection.CheckConnection())
            {
                using HttpClient client = new();
                HttpResponseMessage response = await client.PutAsync(RequestStrings.getMediaFiles, new StringContent(
                   JsonConvert.SerializeObject(vm.model),
                    Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                vm.Indicator = false;
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Нет подключения к интернету", "ОК");
                return false;
            }
        }
        public async Task<bool> Add(MediaFileRedactViewModel vm)
        {
            vm.Indicator = true;
            if (GetClientConnection.CheckConnection())
            {
                using HttpClient client = new();
                HttpResponseMessage response = await client.PostAsync(RequestStrings.getMediaFiles, new StringContent(
                   JsonConvert.SerializeObject(vm.model),
                    Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                vm.Indicator = false;
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Нет подключения к интернету", "ОК");
                return false;
            }
        }
        public async Task<bool> Remove(string id)
        {
            if (GetClientConnection.CheckConnection())
            {
                using HttpClient client = new();
                HttpResponseMessage response = await client.DeleteAsync(RequestStrings.getMediaFiles+"/"+id);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Нет подключения к интернету", "ОК");
                return false;
            }
        }
    }
}
