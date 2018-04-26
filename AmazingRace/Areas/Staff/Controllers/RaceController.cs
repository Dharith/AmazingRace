using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmazingRace.Models;

namespace AmazingRace.Areas.Staff.Controllers
{
    public class RaceController : Controller
    {
        ApplicationDbContext rep = new ApplicationDbContext();
        // GET: Staff/Race
        public ActionResult Index()
        {

            var events = rep.Events.ToList();
            return View(events);
        }
        public ActionResult Simulation()
        {
            return View();
        }

        public ActionResult Simulation2()
        {
            return View();
        }
    }
}