using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using AmazingRace.Models;

namespace AmazingRace.Areas.Staff.Controllers
{
    [RequireHttps]
    public class EventsController : Controller
    {
        ApplicationDbContext rep = new ApplicationDbContext();

        // GET: Staff/Event
        [HttpGet]
        public ActionResult Index()
        {
            var events = rep.Events.ToList();
            return View(events);
        }

        // GET: Staff/Events/Details/5
        public ActionResult Details(int id)
        {
            var events = rep.Events.Find(id);
            return View(events);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        // GET: Staff/Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Events events)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    rep.Events.Add(events);
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
            return View(events);
        }


        // GET: Staff/Events/Edit/5
        public ActionResult Edit(int id)
        {
            var events = rep.Events.Find(id);
            return View(events);
        }

        // POST: Staff/Events/Edit/5
        [HttpPost]
        public ActionResult Edit(Events events)
        {

            if (ModelState.IsValid)
            {
                rep.Entry(events).State = EntityState.Modified;
                rep.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(events);
            }
        }

        // GET: Staff/Events/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events deleteItem = rep.Events.Find(id);
            if (deleteItem == null)
            {
                return HttpNotFound();
            }
            return View(deleteItem);
        }


        // POST: Staff/Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Events deleteEvent = rep.Events.Find(id);
            rep.Events.Remove(deleteEvent);
            rep.SaveChanges();
            return RedirectToAction("Index");

        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Events deleteItem = rep.Events.Find(id);
        //    rep.Events.Remove(deleteItem);
        //    rep.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public PartialViewResult DeleteConfirm(int id)
        //{
        //    var deleteItem = rep.Events.Find(id);  // I'm using 'Items' as a generic term for whatever item you have

        //    return PartialView("Delete", deleteItem);  // assumes your delete view is named "Delete"
        //}
    }
}

