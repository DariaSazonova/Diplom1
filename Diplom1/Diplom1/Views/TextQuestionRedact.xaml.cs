using Diplom1.Models;
using Diplom1.Toast;
using Diplom1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextQuestionRedact : ContentPage
    {
        public TestUpdateViewModel vm;
        private int index;
        public TextQuestionRedact(Questions item, TestUpdateViewModel viewModel)
        {
            InitializeComponent();
           
            vm = viewModel;
            if (item != null)
            {
                vm.idQuestionn = item.id;
                trueAnswer.Text = item.answers.ElementAt(Convert.ToInt32(item.answer));
                BindingContext = vm;
            }
            else
            {
                Questions newq = new()
                {
                    question = null,
                    answer = null,
                    accepted = false,
                    answers = new List<string>() { " " },
                    id = vm.listQuestions.Count()
                };
                vm.listQuestions.Add(newq);
                vm.idQuestionn = newq.id;
                BindingContext = vm;
            }

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListAnswers.ItemsSource = vm.answers;
            ListAnswers.BindingContext = vm.answers;
        }

        private async void Button_ClickedSave(object sender, EventArgs e)
        {
            vm.IndicatorIsVisible = true;

            var i = 0;
            foreach(var item in vm.answers)
            {
                i++;
                if (item.Trim() == trueAnswer.Text.Trim())
                {
                    vm.answer = (i - 1).ToString();
                    break;
                }
            }
            if (int.TryParse(vm.answer, out int num))
            {
                var res = await vm.savetest.Save(vm);
                if (res)
                {
                    vm.IndicatorIsVisible = false;
                    Application.Current.MainPage.Toast("Тест изменен", status.message);
                }
                else
                {
                    vm.IndicatorIsVisible = false;
                    Application.Current.MainPage.Toast("Не удалось обновить тест", status.warning);
                }
            }
            else
            {
                Application.Current.MainPage.Toast("Не найден правильный вариант ответа", status.error);
            }
        }

        private void BorderlessEntry_Focused(object sender, FocusEventArgs e)
        {
            var value = (sender as BorderlessEntry).Text;
            for (int i = 0; i < vm.answers.Count(); i++)
            {
                if (vm.answers[i] == value) index = i;
            }
        }

        private void BorderlessEntry_Unfocused(object sender, FocusEventArgs e)
        {
            var value = (sender as BorderlessEntry).Text;
            for (int i = 0; i < vm.answers.Count(); i++)
            {
                if (i == index)
                {
                    vm.answers[i] = value;
                }
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (vm.answers == null) vm.answers = new() {" "};
            vm.answers.Add(" ");
            vm.answers = vm.answers;
            ListAnswers.ItemsSource = null;
            ListAnswers.BindingContext = null;
            ListAnswers.ItemsSource = vm.answers;
            ListAnswers.BindingContext = vm.answers;
        }

        private async void ImageButton_ClickedDelete(object sender, EventArgs e)
        {
            vm.IndicatorIsVisible = true;
            var value = (sender as ImageButton).AutomationId;
            for (int i = 0; i < vm.answers.Count(); i++)
            {
                if (vm.answers[i] == value) vm.answers.RemoveAt(i);
            }
            var res = await vm.savetest.Save(vm);
            if (res)
            {
                vm.answers = vm.answers;
                ListAnswers.ItemsSource = null;
                ListAnswers.BindingContext = null;
                ListAnswers.ItemsSource = vm.answers;
                ListAnswers.BindingContext = vm.answers;
            }
            else
            {
                vm.IndicatorIsVisible = false;
            }
            vm.IndicatorIsVisible = false;
        }

        private void ListAnswers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}