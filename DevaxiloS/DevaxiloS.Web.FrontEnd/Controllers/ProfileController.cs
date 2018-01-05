using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevaxiloS.Web.FrontEnd.Controllers
{
    //[Authorize]
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}