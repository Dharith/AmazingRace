using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AmazingRace.Models;

namespace AmazingRace.Areas.Staff.Controllers
{
    public class PitStopController : Controller
    {
        ApplicationDbContext rep = new ApplicationDbContext();

        // GET: Staff/PitStop
        [HttpGet]
        public ActionResult Index(String id)
        {
            IEnumerable<PitStops> pitStops = rep.PitStops.ToList();
            if (id != null)
            {
                var pitStopList = (from p in pitStops
                                   where p.EventName == id
                                   select p).ToList();
                //List<PitStops> PitStops = rep.PitStops.Find(id);
                return View(pitStopList);
            }
            return View();
        }

        // GET: Staff/PitStop/Details/5
        public ActionResult Details(int id)
        {
            var pitStops = rep.PitStops.Find(id);
            return View(pitStops);
        }

        [HttpGet]
        public ActionResult Create(string id)
        {
            PitStops pitStops = new PitStops();
            pitStops.EventName = id;
            return View(pitStops);
        }


        // GET: Staff/PitStop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PitStops PitStop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    rep.PitStops.Add(PitStop);
                    rep.SaveChanges();
                    return RedirectToAction("Index","Events", new { area = "Staff" });
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
            return View(PitStop.EventName);
        }


        // GET: Staff/PitStop/Edit/5
        public ActionResult Edit(int id)
        {
            var PitStop = rep.PitStops.Find(id);
            return View(PitStop);
        }

        // POST: Staff/PitStop/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PitStops PitStop)
        {

            if (ModelState.IsValid)
            {
                rep.Entry(PitStop).State = EntityState.Modified;
                rep.SaveChanges();
                return RedirectToAction("Index",new RouteValueDictionary( new { Id = PitStop.EventName }));
            }
            else
            {
                return View(PitStop);
            }
        }

        // GET: Staff/PitStop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PitStops deleteItem = rep.PitStops.Find(id);
            if (deleteItem == null)
            {
                return HttpNotFound();
            }
            return View(deleteItem);
        }

        // POST: Staff/PitStop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PitStops deletePitStop = rep.PitStops.Find(id);
            rep.PitStops.Remove(deletePitStop);
            rep.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Id = deletePitStop.EventName }));

        }

        //// POST: Staff/PitStop/Delete/5
        //[HttpPost]
        //public ActionResult Delete(PitStops PitStop)
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
