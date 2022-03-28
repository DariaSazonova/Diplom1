using Diplom1.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diplom1.ViewModels.AvtorizationViewModel
{
    public  class Registration
    {
        public async Task<bool> reg(RegistrationViewModel viewModel)
        {
            if (GetClientConnection.CheckConnection())
            {
                viewModel.IndicatorIsVisible = true;
                using HttpClient client = new();
                var pass = MD5Hash.toString(viewModel.Password);
                HttpResponseMessage resultUser = await client.PostAsync(RequestStrings.postUser(viewModel.Email, pass), null);
                var res1 = await resultUser.Content.ReadAsStringAsync();
                if (!String.IsNullOrWhiteSpace(res1)&& resultUser.IsSuccessStatusCode)
                {
                    HttpResponseMessage resultApplicant = await client.PostAsync(RequestStrings.postApplicant(res1, viewModel.Surname, viewModel.Name, viewModel.Patronymic, viewModel.Phone, viewModel.Email, viewModel.DateOfBirth), null);
                    if (resultApplicant.IsSuccessStatusCode)
                    {
                        viewModel.IndicatorIsVisible = false;
                        return true;
                    }
                    else
                    {
                        viewModel.IndicatorIsVisible = false;
                        await Application.Current.MainPage.DisplayAlert("Ошибка", "Не удалось загрузить данные на сервер2", "ОК");
                        return false;
                    }
                }
                else
                {
                    viewModel.IndicatorIsVisible = false;
                    await Application.Current.MainPage.DisplayAlert("Ошибка", "Не удалось загрузить данные на сервер", "ОК");
                    return false;
                }

            }
            else
            {
                viewModel.IndicatorIsVisible = false;
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Нет подключения к интернету", "ОК");
                return false;
            }
        }
    }
}
