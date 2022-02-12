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
    public partial class AvtorizationPage : ContentPage
    {
        private readonly AvtorizationViewModel vm = new();
        private bool IsEmail = false;
        private bool IsPassword = false;
        public AvtorizationPage()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private void BorderlessEntry_TextChangedPassword(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 7)
            {
                (sender as Entry).TextColor = Color.Black;
                IsPassword = true;
                if (IsEmail == true)
                    vm.IsButtonEnabled = true;
            } 
            else 
                (sender as Entry).TextColor = Color.Red;
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
                IsEmail = true;
                if (IsPassword == true)
                    vm.IsButtonEnabled = true;
            }
        }
    }
}