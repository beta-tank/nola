using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Nola.Core.Models.Results;
using Nola.Core.Models.Users;

namespace Nola.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var CourseResults = new List<CourseResult>();
            var Students = new List<StudentUser>();
            var sortedStudents =
                Students.OrderByDescending(s => CourseResults
                    .Where(r => r.User == s)
                    .Sum(r => r.RightPercent));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}