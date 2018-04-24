using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models.Models;

namespace WebAPI.Areas.Staff.Controllers
{
    public class PitStopController : Controller
    {

        public PitStopController()
        {
            
        }

        // GET: Staff/PitStop
        [HttpGet]
        public ActionResult Index()
        {
            //var PitStop = rep.GetEvents();
            return View();
        }

        // GET: Staff/PitStop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        // GET: Staff/PitStop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PitStop PitStop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //rep.Create(PitStop);
                    //rep.Save();
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
            //var PitStop = rep.GetById(id);
            return View();
        }

        // POST: Staff/PitStop/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PitStop PitStop)
        {

            if (ModelState.IsValid)
            {
                //rep.Update(PitStop);
                //rep.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(PitStop);
            }
        }

        // GET: Staff/PitStop/Delete/5
        public ActionResult Delete(int id)
        {
            //var PitStop = rep.GetById(id);
            return View();
        }

        // POST: Staff/PitStop/Delete/5
        [HttpPost]
        public ActionResult Delete(PitStop PitStop)
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
