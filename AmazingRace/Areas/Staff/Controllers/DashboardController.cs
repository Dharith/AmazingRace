using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmazingRace.Areas.Staff.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Staff/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}