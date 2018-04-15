using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmazingRace.DAL;
using AmazingRace.Models.Models;

namespace AmazingRace.Areas.Staff.Controllers
{
    public class EventsController : Controller
    {
        EventsRespository rep = new EventsRespository();


        // GET: Staff/Events
        [HttpGet]
        public ActionResult Index()
        {

            IEnumerable<Events> events = rep.GetEvents();
            return View(events);
        }

        // GET: Staff/Events/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {

            Events events = new Events();
            return View(events);
        }


        // GET: Staff/Events/Create
        [HttpPost]
        public ActionResult Create(Events events)
        {
            try
            {
                rep.CreateEvents(events);
                rep.Save();
                return RedirectToAction("Index");
            }
            catch(Exception exp)
            {
                if(exp.GetType() != typeof(DbEntityValidationException))
                {
                    if(this.HttpContext.IsDebuggingEnabled)
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

        // POST: Staff/Events/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Events/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Staff/Events/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Events/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Staff/Events/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
