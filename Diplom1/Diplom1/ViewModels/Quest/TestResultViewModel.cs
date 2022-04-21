using Diplom1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Diplom1.ViewModels.Quest
{
    public class TestResultViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TestResultModel model { get; set; } = new();
        private List<TestResultModel> listModel { get; set; } = new();
        public GetTestResult testResult = new();
        public TestResultViewModel()
        {
            listModel = Task.Run(async()=>await testResult.Result()).Result;
        }

        public List<TestResultModel> list
        {
            get { return listModel; }
            set
            {
                if (listModel != value)
                {
                    listModel = value;
                    OnPropertyChanged("list");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
