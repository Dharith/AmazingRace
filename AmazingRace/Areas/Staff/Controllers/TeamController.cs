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
    public class TeamController : Controller
    {
        private IRepository<Team> rep = null;

        public TeamController()
        {
            this.rep = new EventsRespository<Team>();
        }

        // GET: Staff/Team
        [HttpGet]
        public ActionResult Index()
        {
            var Team = rep.GetEvents();
            return View(Team);
        }

        // GET: Staff/Team/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        // GET: Staff/Team/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team Team)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    rep.Create(Team);
                    rep.Save();
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
        public ActionResult Edit(int id)
        {
            var Team = rep.GetById(id);
            return View(Team);
        }

        // POST: Staff/Team/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Team Team)
        {

            if (ModelState.IsValid)
            {
                rep.Update(Team);
                rep.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(Team);
            }
        }

        // GET: Staff/Team/Delete/5
        public ActionResult Delete(int id)
        {
            var Team = rep.GetById(id);
            return View(Team);
        }

        // POST: Staff/Team/Delete/5
        [HttpPost]
        public ActionResult Delete(Team Team)
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
