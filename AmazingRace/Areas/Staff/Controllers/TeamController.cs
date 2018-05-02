using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmazingRace.Models;

namespace AmazingRace.Areas.Staff.Controllers
{
    public class TeamController : Controller
    {
        ApplicationDbContext rep = new ApplicationDbContext();

        // GET: Staff/Team
        [HttpGet]
        public ActionResult Index()
        {
            var Team = rep.Teams.ToList();
            return View(Team);
        }

        // GET: Staff/Team/Details/5
        public ActionResult Details(string id)
        {
            var teams = rep.Teams.Find(id);
            return View(teams);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var eventList = GetEvents();
            Teams team = new Teams();
            team.EventsList = eventList;
            ViewBag.eventList = eventList;
            return View(team);
        }

        public IEnumerable<SelectListItem> GetEvents()
        {
            using (var context = new ApplicationDbContext())
            {
                List<SelectListItem> eventList = context.Events.AsNoTracking()
                    .OrderBy(n => n.EventName)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.EventName.ToString(),
                            Text = n.EventName
                        }).ToList();
                var eventSelection = new SelectListItem()
                {
                    Value = null,
                    Text = "Select Event"
                };
                eventList.Insert(0, eventSelection);
                return new SelectList(eventList, "Value", "Text");
            }
        }


        // GET: Staff/Team/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teams Team)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    rep.Teams.Add(Team);
                    rep.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception exp)
            {
                if (exp.GetType() != typeof(DbEntityValidationException))
                {
                    if (this.HttpContext.IsDebuggingEnabled)
                    {
                        ModelState.AddModelError(String.Empty, exp.ToString());
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, "Some error has occured");
                    }
                }
            }
            return View(Team);
        }


        // GET: Staff/Team/Edit/5
        public ActionResult Edit(string id)
        {
            var Teams = rep.Teams.Find(id);
            var eventList = GetEvents();
            Teams.EventsList = eventList;
            ViewBag.eventList = eventList;
            return View(Teams);
        }

        // POST: Staff/Team/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teams Team)
        {

            if (ModelState.IsValid)
            {
                rep.Entry(Team).State = EntityState.Modified;
                rep.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(Team);
            }
        }

        // GET: Staff/PitStop/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teams deleteItem = rep.Teams.Find(id);
            if (deleteItem == null)
            {
                return HttpNotFound();
            }
            return View(deleteItem);
        }

        // POST: Staff/PitStop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Teams deleteTeam = rep.Teams.Find(id);
            rep.Teams.Remove(deleteTeam);
            rep.SaveChanges();
            return RedirectToAction("Index");

        }

        //// POST: Staff/Team/Delete/5
        //[HttpPost]
        //public ActionResult Delete(Team Team)
        //{
        //    try
        //    {
        //        //yet to be written
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
