using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAL parkDAL;
        public HomeController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
        }


        public IActionResult Index(Park park)
        {
            var parks = parkDAL.GetAllParks();

            park.Parks = parks;

            return View(parks);
        }

        public IActionResult Detail(string parkCode)
        {
            ParkDetail park = parkDAL.GetParkDetails(parkCode);

            return View(park);
        }
        
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
