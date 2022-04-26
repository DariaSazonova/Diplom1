using Diplom1.Client;
using Microcharts;
using SkiaSharp;
using Diplom1.Models;
using Diplom1.Toast;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diplom1.ViewModels
{
    public class ChartViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ChartModel model { get; set; } = new();
        public ChartViewModel(int month=0)
        {
            if(month == 0)
            {
                month = Convert.ToInt32(DateTime.Now.Month.ToString());
            }
            var js = Task.Run(async () => await Get(month)).Result;
            if (js != null)
            {
                model.list = JsonConvert.DeserializeObject<List<chartData>>(js);
                foreach(var item in model.list)
                {
                    var entry = new ChartEntry(item.count)
                    {
                        Label = item.date,
                        ValueLabel = item.count.ToString()
                    };
                    model.entries.Add(entry);
                }
                model.chart = new LineChart
                {
                    Entries = model.entries,
                    LineMode = LineMode.Straight,
                    LineSize = 8,
                    PointMode = PointMode.Square,
                    PointSize = 18,
                    IsAnimated = true,
                    AnimationProgress = 1,
                    AnimationDuration = TimeSpan.FromSeconds(5),
                    LabelColor = SKColor.Parse("#000000"),
                    LabelOrientation = Orientation.Horizontal,
                    LabelTextSize = 25,
                    ValueLabelOrientation = Orientation.Horizontal
                };

            }

        }
        public LineChart Chart
        {
            get { return model.chart; }
            set
            {
                model.chart = value;
                OnPropertyChanged("Chart");
            }
        }
        public List<chartData> List
        {
            get { return model.list; }
            set
            {
                model.list = value;
                OnPropertyChanged("List");
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public async Task<string> Get(int month)
        {
            if (GetClientConnection.CheckConnection())
            {
                using HttpClient client = new();
                HttpResponseMessage result = await client.GetAsync(RequestStrings.getChart(month));
                if (result.IsSuccessStatusCode)
                {
                    var res = await result.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(res))
                    {
                        return res;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                Application.Current.MainPage.Toast("Отсутствует интернет соединение", status.error);
                return null;
            }
        }
    }
}
