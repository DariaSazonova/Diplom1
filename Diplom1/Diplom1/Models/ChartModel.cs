using Microcharts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom1.Models
{
    public class ChartModel
    {
        public List<chartData> list { get; set; }
        public List<ChartEntry> entries { get; set; } = new();
        public LineChart chart { get; set; } = new();
        public bool Indicator { get; set; }
    }
    public class chartData
    {
        public string date { get; set; }
        public int count { get; set; }
    }
}
