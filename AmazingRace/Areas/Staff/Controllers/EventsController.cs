using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AmazingRace.Models.Models;

namespace AmazingRace.Areas.Staff.Controllers
{
    public class EventsController : Controller
    {
        EventServiceClient client = new EventServiceClient();

        public EventsController()
        {
        }

        // GET: Staff/Events
        [HttpGet]
        public ActionResult Index()
        {
            return View();
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
        // GET: Employee  
        public ActionResult EmployeeDetails()
        {
            return this.View();
        }
        //public async Task<ActionResult> EmpInfoData()
        //{
        //    try
        //    {

        //        return this.Json(await this.restClient.RunAsyncGetAll<Employee, Employee>("api/Employee/EmpDetails"), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (ApplicationException ex)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
        //    }
        //}

        //public async Task<ActionResult> InsertEmployeeInfo(Employee objEmp)
        //{
        //    try
        //    {
        //        return this.Json(await this.restClient.RunAsyncPost<Employee, string>("api/Employee/InsertEmpDetails", objEmp));
        //    }
        //    catch (ApplicationException ex)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
        //    }
        //}


        // GET: Staff/Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Events events)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //rep.Create(events);
                    //rep.Save();
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
            //var events = rep.GetById(id);
            return View();
        }

        // POST: Staff/Events/Edit/5
        [HttpPost]
        public ActionResult Edit(Events events)
        {
            
                if (ModelState.IsValid)
                {
                    //rep.Update(events);
                    //rep.Save();
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
            //var events = rep.GetById(id);
            return View();
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
