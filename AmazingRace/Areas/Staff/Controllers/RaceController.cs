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

        [HttpGet]
        public ActionResult Simulation(String eventName)
        {
            IEnumerable<PitStops> pitStops = rep.PitStops.ToList();
            if (eventName != null)
            {
                var pitStopList = (from p in pitStops
                                   where p.EventName == eventName
                                   select p).ToList();
                //List<PitStops> PitStops = rep.PitStops.Find(id);
                return View(pitStopList);
            }
            return View();
        }

        public ActionResult Simulation2()
        {
            return View();
        }
    }
}