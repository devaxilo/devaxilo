using System.Threading.Tasks;
using System.Web.Mvc;
using DevaxiloS.Services.Commands.Web.Dashboard;

namespace DevaxiloS.Web.FrontEnd.Controllers
{
    [Authorize]
    public class DashboardController : BaseWebController
    {
        // GET: Dashboard
        public async Task<ActionResult> Index()
        {
            var cmd = new GetKetQuaXoSoCommand(0);
            await CommandBus.Send(cmd);
            ViewBag.Content  = cmd.Response.ResponseObj;
            
            return View();
        }
    }
}