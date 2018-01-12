using System.Web.Mvc;

namespace DevaxiloS.Web.FrontEnd.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}