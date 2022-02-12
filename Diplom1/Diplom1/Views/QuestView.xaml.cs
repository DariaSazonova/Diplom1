﻿using Diplom1.Client;
using Diplom1.Models;
using Diplom1.ViewModels.Quest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplom1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestView : ContentPage
    {
        public QuestViewModel viewModel;
        private int count;
        public QuestView(int level)
        {
            InitializeComponent();
            QuestViewModel vm = new(level);
            viewModel = vm; 
            BindingContext = viewModel;
        }

        private async void ListButtons_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tapped = e.Item;
            List<QuestTestModel> viewModelList = new();
            (sender as ListView).ItemsSource = null;
            foreach (var i in viewModel.listQuestions)
            {
                if (i.answers.Contains(tapped))
                {
                    count++;
                    if (i.answers.ElementAt(Convert.ToInt32(i.answer)) == tapped)
                        i.IsAnswered = true;
                    else i.IsAnswered = false;
                    i.accepted = true;
                    (sender as ListView).ItemsSource = i.answers;
                    viewModel.progress = 1f / viewModel.listQuestions.Count();
                    viewModelList.Add(viewModel.model[0]);
                    BindableLayout.SetItemsSource(ParStackLayout, viewModelList);
                    BindableLayout.SetItemsSource(QuestionList, viewModel.listQuestions);

                }

                if (count == viewModel.model[0].listQuestions.Count())
                {

                    double countTrueAnswers = viewModel.model[0].listQuestions.Where(l => l.IsAnswered == true).Count();
                    double countAll = viewModel.model[0].listQuestions.Count();
                    var Result = Math.Round(countTrueAnswers / countAll, 3).ToString().Replace(",",".");

                    
                    using(HttpClient client = new())
                    {
                        var response = await client.PostAsync(RequestStrings.postQuestResult+$"?idquest={viewModel.idQuest}&idapplicatn={PreferencesApp.UserID}&res={Result}", null);
                        if (response.IsSuccessStatusCode)
                        {
                            await Application.Current.MainPage.DisplayAlert("Результа", $"{countTrueAnswers} из  {countAll}", "ок");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Ошибка", $"Не удалось отправить данные", "ок");
                            await Navigation.PopAsync();
                        }
                    }
                }
            }
        }
    }
}