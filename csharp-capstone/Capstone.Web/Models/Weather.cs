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

        public bool IsCelsius { get; set; }



        public void ConvertFToC(int t)
        {
           int current = 0;
           if( IsCelsius == false)
            {
                current = t;
            }
           else
            {
                current = ((t - 32) * 5) / 9;
            }
            return current;
        }

    }
}
