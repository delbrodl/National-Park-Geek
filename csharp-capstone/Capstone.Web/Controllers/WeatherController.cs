﻿using System;
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

        [HttpGet]
        public IActionResult Index(string parkCode)
        {
            var tempUnits = GetTempPreference();
            if (tempUnits == "F")
            {
                var weather = weatherDAL.GetWeather(parkCode);
                weather[0].Units = 'F';
                return View(weather);
            }
            else
            {
                var weather = weatherDAL.GetWeather(parkCode);
                weather[0].Units = 'C';
                return View(weather);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeTempUnits(string tempUnits, string parkCode)
        {
            SaveTempUnits(tempUnits);
            return RedirectToAction("Index", new { parkCode = parkCode} );
        }

        public string GetTempPreference()
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