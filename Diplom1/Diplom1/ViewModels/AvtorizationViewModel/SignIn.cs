using Diplom1.Client;
using Diplom1.Views;
using Diplom1.ViewModels.AvtorizationViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using Diplom1.Models;
using Newtonsoft.Json.Linq;


namespace Diplom1.ViewModels.AvtorizationViewModel
{
    public class SignIn:ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }
        public readonly AvtorizationViewModel viewModel;
        public SignIn(AvtorizationViewModel vm)
        {
            viewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public async void Execute(object parameter)
        {
            if (GetClientConnection.CheckConnection())
            {
                viewModel.IndicatorIsVisible = true;
                using HttpClient client = new();
                HttpResponseMessage result = await client.GetAsync(RequestStrings.user(viewModel.Email, viewModel.Password));
                var res = await result.Content.ReadAsStringAsync();
                if (!String.IsNullOrWhiteSpace(res))
                {
                    var user = JsonConvert.DeserializeObject<UserModel>(res);
                    PreferencesApp.UserID = user.id;
                    PreferencesApp.role = user.role;
                    PreferencesApp.Login = user.Login;
                    PreferencesApp.Password = user.Password;

                    if (PreferencesApp.role == "admin")
                    {
                        result = await client.GetAsync(RequestStrings.admin(viewModel.Email));
                        PreferencesApp.role = "Администратор";
                    }
                    else if (PreferencesApp.role == "applicant")
                    {
                        result = await client.GetAsync(RequestStrings.applicant(viewModel.Email));
                        PreferencesApp.role = "Абитуриент";
                    }
                    res = await result.Content.ReadAsStringAsync();
                    var userData = JsonConvert.DeserializeObject<UserModel>(res);
                    PreferencesApp.Surname = userData.Surname;
                    PreferencesApp.Name = userData.Name;
                    PreferencesApp.Patronymic = userData.Patronymic;
                    PreferencesApp.Phone = userData.Phone;
                    PreferencesApp.DateOfBirth = userData.DateOfBirth.ToString();

                    //AvtorizationViewModel.model.role = PreferencesApp.role;
                    
                    viewModel.IndicatorIsVisible = false;

                    Application.Current.MainPage = new NavigationPage(new Views.HomePage());

                }
                else
                {
                    viewModel.IndicatorIsVisible = false;
                    await Application.Current.MainPage.DisplayAlert("Ошибка", "Неправильный логин или пароль", "ОК");
                }

            }
            else
            {
                viewModel.IndicatorIsVisible = false;
                await Application.Current.MainPage.DisplayAlert("Ошибка", "Нет подключения к интернету", "ОК");
            }
        }
    }
}
