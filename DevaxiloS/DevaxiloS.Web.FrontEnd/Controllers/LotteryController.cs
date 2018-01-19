using System.Web.Mvc;

namespace DevaxiloS.Web.FrontEnd.Controllers
{
    [Authorize]
    public class LotteryController : Controller
    {
        public ActionResult MyLotto()
        {
            return View();
        }

        public ActionResult MyLottery()
        {
            return View();
        }
    }
}