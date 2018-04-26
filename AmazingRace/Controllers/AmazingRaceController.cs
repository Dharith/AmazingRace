using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmazingRace.Models;

namespace AmazingRace.Controllers
{
    public class AmazingRaceController : Controller
    {
        ApplicationDbContext rep = new ApplicationDbContext();
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


        public ActionResult LeaderBoard()
        {
            ViewBag.events = rep.Events.ToList();
            return View();
        }



        public ActionResult GotoDashBoard()
        {
            return RedirectToAction("index", "Dashboard", new { area = "Staff" });
        }

        public ActionResult Events()
        {
            return RedirectToAction("index", "Events", new { area = "Staff" });
        }

        public ActionResult Team()
        {
            return RedirectToAction("index", "Team", new { area = "Staff" });
        }
        public ActionResult Race()
        {
            return RedirectToAction("index", "Race", new { area = "Staff" });
        }
    }
}
