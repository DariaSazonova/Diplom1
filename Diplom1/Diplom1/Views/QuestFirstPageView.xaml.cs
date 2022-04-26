using Diplom1.Client;
using Diplom1.ViewModels.Quest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestFirstPageView : ContentPage
    {
        public  QuestFirstViewModel vm = new();
        public QuestFirstPageView()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await FadeAnimateY(MainLabel);
            await FadeAnimateY(SeconLabel);
            await FadeAnimateY(LabelLevel1);
            await FadeAnimateY(LabelLevel2);
            await FadeAnimateY(LabelLevel3);
            await FadeAnimateY(LabelHistory);
        }
        private static async Task FadeAnimateY(View view)
        {
            await Task.WhenAll
               (
                    view.FadeTo(1, 350),
                    view.TranslateTo(0, 0, 350)
               );
        }
    }
}