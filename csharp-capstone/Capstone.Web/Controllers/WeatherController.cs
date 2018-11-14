using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherDAL weatherDAL;
        public WeatherController(IWeatherDAL weatherDAL)
        {
            this.weatherDAL = weatherDAL;
        }

        public IActionResult Index(string parkCode)
        {
            var weather = weatherDAL.GetWeather(parkCode);
            return View(weather);
        }


        private string GetTempPreference()
        {
            var tempUnits = HttpContext.Session.Get<string>("tempUnits");
            if (tempUnits == null)
            {
                tempUnits = "F";
                HttpContext.Session.Set("tempUnits", "F");
            }
            return tempUnits;
        }

        private void SaveTempUnits(string tempUnit)
        {
            HttpContext.Session.Set("tempUnits", tempUnit);
        }


    }
}