using Diplom1.Client;
using Diplom1.Models;
using Diplom1.Toast;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Diplom1.ViewModels
{
    public class SpecialityInformationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public SpecialityInformationModel model { get; set; } = new();
        private List<MediaPageModel> list { get; set; } = new ();
        public SpecialityInformationViewModel(List<MediaPageModel> res)
        {
            list = res;
        }
        public bool IsNotEdior
        {
            get { return model.isNotEdior; }
            set
            {
                if (model.isNotEdior != value)
                {
                    model.isNotEdior = value;
                    OnPropertyChanged("IsNotEdior");
                }
            }
        }
        public bool Indicator
        {
            get { return model.Indicator; }
            set
            {
                if (model.Indicator != value)
                {
                    model.Indicator = value;
                    OnPropertyChanged("Indicator");
                }
            }
        }

        public string Editor1
        {
            get { return list.Where(s => s.title == "Editor1").Select(s => s.path).FirstOrDefault().ToString();  }
            set
            {
                list[list.IndexOf(list.Where(s => s.title == "Editor1").FirstOrDefault())].path = value;
                OnPropertyChanged("Editor1");
                
            }
        }

        public string Editor2
        {
            get { return list.Where(s => s.title == "Editor2").Select(s => s.path).FirstOrDefault().ToString(); }
            set
            {

                list[list.IndexOf(list.Where(s => s.title == "Editor2").FirstOrDefault())].path = value;
                OnPropertyChanged("Editor2");
                
            }
        }

        public string Editor3
        {
            get { return list.Where(s => s.title == "Editor3").Select(s => s.path).FirstOrDefault().ToString();  }
            set
            {
                list[list.IndexOf(list.Where(s => s.title == "Editor3").FirstOrDefault())].path = value;
                OnPropertyChanged("Editor3");
            }
        }

        public string Editor4
        {
            get { return list.Where(s => s.title == "Editor4").Select(s => s.path).FirstOrDefault().ToString(); }
            set
            {
                list[list.IndexOf(list.Where(s => s.title == "Editor4").FirstOrDefault())].path = value;
                OnPropertyChanged("Editor4");
            }
        }

        public string Editor5
        {
            get { return list.Where(s => s.title == "Editor5").Select(s => s.path).FirstOrDefault().ToString(); }
            set
            {
                list[list.IndexOf(list.Where(s => s.title == "Editor5").FirstOrDefault())].path = value;
                OnPropertyChanged("Editor5");
            }
        }

        public string Editor6
        {
            get { return list.Where(s => s.title == "Editor6").Select(s => s.path).FirstOrDefault().ToString(); }
            set
            {
                list[list.IndexOf(list.Where(s => s.title == "Editor6").FirstOrDefault())].path = value;
                OnPropertyChanged("Editor6");
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public async Task<bool> Update()
        {
            if (GetClientConnection.CheckConnection())
            {
                int count = 0;
                using HttpClient client = new();
                foreach (var item in list)
                {
                    HttpResponseMessage result = await client.PutAsync(RequestStrings.getMediaFiles, new StringContent(
                       JsonConvert.SerializeObject(item),
                        Encoding.UTF8, "application/json"));

                    if (result.IsSuccessStatusCode)
                    {
                        count++;
                    }
                }
                return count == list.Count;
            }
            else
            {
                Application.Current.MainPage.Toast("Отсутствует интернет соединение", status.error);
                return false;
            }
           
        }
        
    }
}