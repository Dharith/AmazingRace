﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmazingRace.Models;
using AmazingRace.Models.Models;

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
            var pitStopList = rep.PitStops.Single(m => m.EventName == id);
            //List<PitStops> PitStops = rep.PitStops.Find(id);
            return View(pitStopList);
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
            return View(PitStop);
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
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");

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
