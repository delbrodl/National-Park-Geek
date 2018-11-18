using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public Weather()
        {
            Units = 'F';
        }

        public string ParkCode { get; set; }

        public int Day { get; set; }

        public int Low { get; set; }

        public int High { get; set; }

        public string Forecast { get; set; }

        public char Units { get; set; }

        public int TempConvert(int temp)
        {
            int converted = 0;
            converted = (int)((temp - 32) * 5.0 / 9);
            return converted;
        }

        public string Messages()
        {
            string m = "";
            if (this.Forecast == "snow")
            {
                m = "Pack Snowshoes. ";
            }
            else if (this.Forecast == "rain")
            {
                m = "Pack rain gear and waterproof shoes. ";
            }
            else if (Forecast == "thunderstorms")
            {
                m = "Seek shelter and avoid hiking on exposed trails. ";
            }
            else if (Forecast == "sun")
            {
                m = "Pack sunblock. ";
            }

            if (this.High > 75 || this.Low > 75)
            {
                m = m + "Bring an extra gallon of water.";
            }
            else if (this.High - this.Low > 20)
            {
                m = m + "Wear breathable layers.";
            }
            else if (this.High < 20 || this.Low < 20)
            {
                m = m + "There is a danger of exposure to frigid tempatures.";
            }
            return m;
        }
    }
}
