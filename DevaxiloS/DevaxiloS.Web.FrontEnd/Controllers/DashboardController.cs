﻿using System.Web.Mvc;

namespace DevaxiloS.Web.FrontEnd.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}