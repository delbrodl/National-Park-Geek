using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
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

        private void SaveTempPreference(Weather weather)
        {
            HttpContext.Session.Set<Weather>();
        }


    }
}