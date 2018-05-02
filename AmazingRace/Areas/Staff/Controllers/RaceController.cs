using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AmazingRace.Models;
using System.Globalization;

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
        public ActionResult Simulation(String id)
        {
            IEnumerable<PitStops> pitStops = rep.PitStops.ToList();
            IEnumerable<Teams> teams = rep.Teams.ToList();
            var events = rep.Events.ToList();
            if (id != null)
            {
                var pitStopList = (from p in pitStops
                                   where p.EventName == id
                                   select p).ToList();
                var teamList = (from t in teams
                                where t.SelectedEvent == id
                                select t).ToList();
                var query = from e in events
                            join pitstop in pitStopList on e.EventName equals pitstop.EventName
                            select new { eventDate = e.Date, eventTime = e.StartTime };

                DateTime date = new DateTime();
                TimeSpan time = new TimeSpan();
                
                foreach (var item in query)
                {

                    date = item.eventDate.Date;
                    time = item.eventDate.TimeOfDay;
                    

                }

                var pitstopMarkers = "[";
                foreach(var pitstop in pitStopList)
                {
                    pitstopMarkers += "{";
                    pitstopMarkers += string.Format("'location': '{0}',", pitstop.Location);
                    pitstopMarkers += string.Format("'lat': {0},", pitstop.Latitude);
                    pitstopMarkers += string.Format("'lng': {0}", pitstop.Longitude);
                    pitstopMarkers += "},";
                }
                pitstopMarkers += "]";
               
                ViewBag.TeamCount = teamList.Count;
                //ViewBag.TeamDetails = teamsDetails;
                ViewBag.PitStopMarkers = pitstopMarkers;
                MyViewModel viewModel = new MyViewModel();
                viewModel.date = date;
                viewModel.time = time;
                return View(viewModel);
            }
            return View();
        }

        public ActionResult Simulation2()
        {
            return View();
        }

        
    }
}