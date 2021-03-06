﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmazingRace.DAL;
using AmazingRace.DAL.Interface;
using AmazingRace.Models.Models;

namespace AmazingRace.Areas.Staff.Controllers
{
    public class EventsController : Controller
    {
        private IRepository<Events> rep = null;

        public EventsController()
        {
            this.rep = new EventsRespository<Events>();
        }

        // GET: Staff/Events
        [HttpGet]
        public ActionResult Index()
        {
            var events = rep.GetEvents();
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
                    rep.Create(events);
                    rep.Save();
                    return RedirectToAction("Index");
                }
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

        
        // GET: Staff/Events/Edit/5
        public ActionResult Edit(int id)
        {
            var events = rep.GetById(id);
            return View(events);
        }

        // POST: Staff/Events/Edit/5
        [HttpPost]
        public ActionResult Edit(Events events)
        {
            
                if (ModelState.IsValid)
                {
                    rep.Update(events);
                    rep.Save();
                    return RedirectToAction("Index");
                }
            else
            {
                return View(events);
            }
        }

        // GET: Staff/Events/Delete/5
        public ActionResult Delete(int id)
        {
            var events = rep.GetById(id);
            return View(events);
        }

        // POST: Staff/Events/Delete/5
        [HttpPost]
        public ActionResult Delete(Events events)
        {
            try
            {
                //yet to be written
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
