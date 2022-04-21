using Diplom1.Toast;
using Diplom1.ViewModels.AvtorizationViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistarationView : ContentPage
    {
        private RegistrationViewModel vm = new();
        bool isPassword = false;
        bool isEmail = false;
        bool isDate = false;
        bool isPhone = false;
        public RegistarationView()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(500);
            await Task.Run(async () =>
            {
                await FadeAnimY(PancakeView);
            });
        }
        private static async Task FadeAnimY(View view)
        {
            await Task.WhenAll
               (
                   view.FadeTo(1, 350),
                    view.TranslateTo(0, 0, 350)
               );
        }
        private void BorderlessEntry_TextChangedEmail(object sender, TextChangedEventArgs e)
        {
            var validEmailPattern = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$", RegexOptions.IgnoreCase);

            if (!validEmailPattern.IsMatch(e.NewTextValue))
            {
                (sender as Entry).TextColor = Color.Red;
            }
            else
            {
                (sender as Entry).TextColor = Color.Black;
                isEmail = true;
                
            }
        }
        private void BorderlessEntry_TextChangedPassword(object sender, TextChangedEventArgs e)
        {
            var validEmailPattern = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{8,16}$", RegexOptions.IgnoreCase);

            if (!validEmailPattern.IsMatch(e.NewTextValue))
            {
                (sender as Entry).TextColor = Color.Red;

            }
            else
            {
                if (Password.Text == AgainPassword.Text)
                {
                    AgainPassword.TextColor = Color.Black;
                    Password.TextColor = Color.Black;
                    isPassword = true;
                }
                else (sender as Entry).TextColor = Color.Red;
            }
        }

        private void BorderlessEntry_TextChangedIsNull(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue)|| e.NewTextValue.Length<2)
            {
                (sender as Entry).TextColor = Color.Red;
            }
            else
            {
                (sender as Entry).TextColor = Color.Black;
            }
        }

        private void BorderlessEntry_TextChangedDate(object sender, TextChangedEventArgs e)
        {
            var validDataPattern = new Regex(@"^\s*(3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:19|20)\d{2})\s*$",
                RegexOptions.IgnoreCase);

            if (!validDataPattern.IsMatch(e.NewTextValue))
            {
                if (e.NewTextValue.Length == 2) (sender as Entry).Text += ".";
                else if (e.NewTextValue.Length == 5) (sender as Entry).Text = e.NewTextValue + ".";
                (sender as Entry).TextColor = Color.Red;
            }
            else
            {
                (sender as Entry).TextColor = Color.Black;
                isDate = true;

            }
        }
        private void BorderlessEntry_TextChangedPhone(object sender, TextChangedEventArgs e)
        {
            var validPhonePattern = new Regex(@"^[8][0-9]{10}", RegexOptions.IgnoreCase);
            if (e.NewTextValue == null || e.NewTextValue == "")
            {
                (sender as Entry).Text = "8";
            }
            else if (!validPhonePattern.IsMatch(e.NewTextValue))
            {
                (sender as Entry).TextColor = Color.Red;
            }
            else
            {
                (sender as Entry).TextColor = Color.Black;
                isPhone = true;


            }
        }
        private void ImageButton_ClickedBack(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AvtorizationPage();
        }

        private void BorderlessEntry_FocusedPhone(object sender, FocusEventArgs e)
        {
            var text = (sender as Entry).Text;
            if (text == null || text=="")
            {
                (sender as Entry).Text = "8";
            }
        }

        private async void Button_ClickedReg(object sender, EventArgs e)
        {
            if (isPhone && isEmail && isDate && isPassword)
            {
                var res = await vm.registrationClicked.reg(vm);
                if (res)
                {
                    Application.Current.MainPage.Toast("Вы успешно зарегистрировались", status.message);
                    Application.Current.MainPage = new AvtorizationPage();

                }
            }
            else
            {
                Application.Current.MainPage.Toast("Не все поля заполнены", status.error);
            }
        }
    }
}