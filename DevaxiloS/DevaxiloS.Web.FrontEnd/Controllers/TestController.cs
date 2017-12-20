using System.Threading.Tasks;
using System.Web.Mvc;
using DevaxiloS.Services.Commands.Web.Customer;
using DevaxiloS.Services.DomainModels.Customer;

namespace DevaxiloS.Web.FrontEnd.Controllers
{
    public class TestController : BaseWebController
    {
        // GET: Test
        public async Task<ActionResult> Index(CustomerRequest model)
        {
            if (!ModelState.IsValid)
            {
                return ErrorModelToClient();
            }
            var cmd = new SaveCustomerCommand(0, model);
            await CommandBus.Send(cmd);
            var response = cmd.Response.ResponseObj;
            return View();
        }
    }
}