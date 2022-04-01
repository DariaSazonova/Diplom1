using Diplom1.Client;
using Diplom1.Toast;
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
                if (!String.IsNullOrWhiteSpace(res1) && resultUser.IsSuccessStatusCode)
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
                        Application.Current.MainPage.Toast($"Не удалось загрузить данные, {resultApplicant.RequestMessage}", status.error);
                        return false;
                    }
                }
                else
                {
                    viewModel.IndicatorIsVisible = false;
                    Application.Current.MainPage.Toast("Не удалось загрузить данные на сервер", status.error);
                    return false;
                }
            }
            else
            {
                viewModel.IndicatorIsVisible = false;
                Application.Current.MainPage.Toast("Нет подключения к интернету", status.error);
                return false;
            }
        }
    }
}
