using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AmazingRace.Models.Models;
using Newtonsoft.Json;

namespace AmazingRace.Areas.Staff.Controllers
{
    [RequireHttps]
    public class EventsController : Controller
    {
        // EventServiceClient client = new EventServiceClient();
        string Baseurl = "http://localhost:51702/api/";
        public EventsController()
        {
        }

        // GET: Staff/Events
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<Events> events = new List<Events>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HTTP GET
                HttpResponseMessage response = await client.GetAsync("AllEvents");
                // response.Wait();
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    events = JsonConvert.DeserializeObject<List<Events>>(result);
                }
            }
           
        return View(events);
        }

        // GET: Staff/Events/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Events events=new Events();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HTTP GET
                HttpResponseMessage response = await client.GetAsync("DeleteEvent");
                // response.Wait();
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    events = JsonConvert.DeserializeObject<Events>(result);
                }
            }
            if (events == null)
                return HttpNotFound();
            return View(events);
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
        
      
        // GET: Staff/Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Events events)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Baseurl);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var json = JsonConvert.SerializeObject(events);
                        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                        //HTTP GET
                        HttpResponseMessage response = await client.GetAsync("CreateEvent");
                        // response.Wait();
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
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
