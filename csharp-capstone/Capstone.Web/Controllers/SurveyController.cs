using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL surveyDAL;
        public SurveyController(ISurveyDAL surveyDAL)
        {
            this.surveyDAL = surveyDAL;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var survey = new Survey();

            return View(survey);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveSurvey(Survey survey)
        {
            if (ModelState.IsValid)
            {
                surveyDAL.AddSurvey(survey);
                return RedirectToAction("Favorites", "Survey");
            }
            else
            {
                return RedirectToAction("Index", "Survey");
            }
           
        }

        [HttpGet]
        public IActionResult Favorites()
        {
            var surveyResults = surveyDAL.GetSurveys();
            return View(surveyResults);
        }

    }
}