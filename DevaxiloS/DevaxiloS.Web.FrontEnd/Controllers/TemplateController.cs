using System.Web.Mvc;

namespace DevaxiloS.Web.FrontEnd.Controllers
{
    [Authorize]
    public class TemplateController : Controller
    {
        // GET: Template
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Coin()
        {
            return View();
        }
    }
}