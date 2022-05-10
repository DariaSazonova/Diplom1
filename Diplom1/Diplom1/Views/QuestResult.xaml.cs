using Diplom1.Client;
using Diplom1.Toast;
using Diplom1.ViewModels.Quest;
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
    public partial class QuestResult : ContentPage
    {
        private QuestResultViewModel vm;
        public QuestResult(int countTrueAnswers, int countAll, int level)
        {
            InitializeComponent();
            vm = new(countTrueAnswers, countAll, level);
            Diplom1.ViewModels.Quest.GetTestResult GetTestResult = new();
            var res = Task.Run(async () => await GetTestResult.Result(Convert.ToInt32(PreferencesApp.UserID), 0)).Result;
            if (res != null)
                contentView.Content = new TestResultView(res);
            else
            {
                Application.Current.MainPage.Toast($"Тест был изменен\nИнформация о результатах недоступна", status.error);
            }
            BindingContext = vm;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new HomePage());
        }

        private void Button_ClickedViewRes(object sender, EventArgs e)
        {
            Testresults.IsVisible = true;
        }
        private void Close(object sender, EventArgs e)
        {
            Testresults.IsVisible = false;
        }
    }
}