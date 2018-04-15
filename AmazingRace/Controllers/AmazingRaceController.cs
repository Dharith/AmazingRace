using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmazingRace.DAL;
using AmazingRace.Models.Models;

namespace AmazingRace.Controllers
{
    public class AmazingRaceController : Controller
    {

        // GET: AmazingRace
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Intro()
        {
            return View();
        }

        public ActionResult Login()
        {
            return PartialView();
        }

        public ActionResult GotoDashBoard()
        {
            return View("~/Areas/Staff/Views/Dashboard/index.cshtml");
        }

        public ActionResult Events()
        {
            return View("~/Areas/Staff/Views/Events/index.cshtml");
        }
    }
}