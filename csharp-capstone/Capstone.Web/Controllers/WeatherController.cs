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
            var tempUnits = GetTempPreference();
            if (tempUnits == "F")
            {
                var weather = weatherDAL.GetWeather(parkCode);
                return View(weather);
            }
            else
            {
                var weather = weatherDAL.GetWeather(parkCode);
                foreach (var w in weather)
                {
                    w.CovertTemps();
                }
                return View(weather);
            }

        }

        [HttpPost]
        public IActionResult ChangeTempUnits(string tempUnits, string parkCode)
        {
            SaveTempUnits(tempUnits);
            return RedirectToAction("Index", new { parkCode = parkCode} );
        }

        private string GetTempPreference()
        {
            var tempUnits = HttpContext.Session.GetString("tempUnits");
            if (tempUnits == null)
            {
                tempUnits = "F";
                HttpContext.Session.SetString("tempUnits", "F");
            }
            return tempUnits;
        }

        private void SaveTempUnits(string tempUnit)
        {
            HttpContext.Session.SetString("tempUnits", tempUnit);
        }

    }
}