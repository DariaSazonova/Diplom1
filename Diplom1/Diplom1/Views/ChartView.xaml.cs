using Diplom1.ViewModels;
using Microcharts;
using SkiaSharp;
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
    public partial class ChartView : ContentView
    {
        public ChartViewModel viewModel;
        public ChartView()
        {
            InitializeComponent();
            viewModel = new();
            BindingContext = viewModel;
            Chart.Chart = viewModel.Chart;
        }

        private async void Button_ClickedMonth(object sender, EventArgs e)
        {
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            var clicked = await Application.Current.MainPage.DisplayActionSheet("Выберите месяц", "Отмена", "Окей", months);
            if (months.Contains(clicked))
            {
                for(var i = 0; i < months.Count(); i++)
                {
                    if(months[i] == clicked)
                    {
                        viewModel = new(i+1);
                        BindingContext = viewModel;
                        Chart.Chart = viewModel.Chart;
                        break;
                    }
                }
            }
        }
    }
}