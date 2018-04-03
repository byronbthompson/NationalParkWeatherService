using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkWeather
    {
        public Park Park { get; set; }
        public List<Weather> Weather { get; set; }
        public Weather Today
        {
            get
            {
                return Weather.Find(w => w.FiveDayForecastValue == 1);
            }
        }
        public Weather Tomorrow
        {
            get
            {
                return Weather.Find(w => w.FiveDayForecastValue == 2);
            }
        }
        public Weather TwoDaysFromNow
        {
            get
            {
                return Weather.Find(w => w.FiveDayForecastValue == 3);
            }
        }
        public Weather ThreeDaysFromNow
        {
            get
            {
                return Weather.Find(w => w.FiveDayForecastValue == 4);
            }
        }
        public Weather FourDaysFromNow
        {
            get
            {
                return Weather.Find(w => w.FiveDayForecastValue == 5);
            }
        }
        public string TempUnit { get; set; }


        public string GetAdvisory(string forecast, int high, int low)
        {
            string advisory = "";
            if (forecast == "sunny")
            {
                advisory += "Pack Sunblock.\n";
            }
            if (forecast == "thunderstorms")
            {
                advisory += "Seek shelter and avoid hiking on exposed ridges.\n";
            }
            if (forecast == "rain")
            {
                advisory += "Pack rain gear and wear waterproof shoes.\n";
            }
            if (forecast == "snow")
            {
                advisory += "Pack snowshoes.\n";
            }
            if (high > 75)
            {
                advisory += "Bring an extra gallon of water.\n";
            }
            if (high - low > 20)
            {
                advisory += "Wear breathable layers.\n";
            }
            if (low < 20)
            {
                advisory += "Beware the dangers of over exposure to frigid temperatures.\n";
            }
            return advisory;
        }


        public int ConvertTemp(int temp)
        {
            int convertedTemp = temp;

            if (TempUnit == "c")
            {
                convertedTemp = (int)((temp - 32) / 1.8);
            }
            return convertedTemp;
        }
    }
}