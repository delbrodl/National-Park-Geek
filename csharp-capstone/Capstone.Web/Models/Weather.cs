using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }

        public int Day { get; set; }

        public int Low { get; set; }

        public int High { get; set; }

        public string Forecast { get; set; }

        public char TempUnit { get; set; }

        public void CovertTemps()
        {
            this.High =(int)(this.High - 32 * (5.0 / 9));
            this.Low = (int)(this.Low - 32 * (5.0 / 9));
        }
    }
}
