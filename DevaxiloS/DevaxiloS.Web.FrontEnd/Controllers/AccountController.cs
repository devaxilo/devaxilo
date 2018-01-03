using System.Threading.Tasks;
using System.Web.Mvc;
using DevaxiloS.Services.Commands.Web.Customer;
using DevaxiloS.Services.DomainModels.Customer;

namespace DevaxiloS.Web.FrontEnd.Controllers
{
    public class AccountController : BaseWebController
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToDashboard();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(EmailValidationRequest model)
        {
            if (!ModelState.IsValid) return View(model);
            var cmd = new ValidateCustomerEmailCommand(0, model.Email);
            await CommandBus.Send(cmd);
            var isOk = cmd.Response.ResponseObj;
            if (!isOk)
            {
                ModelState.AddModelError("Account", cmd.Response.Message);
                return View(model);
            }
            ViewBag.Email = model.Email;
            return View("ValidateSuccess");
        }

        private ActionResult RedirectToDashboard()
        {
            return RedirectToAction("Index", "Dashboard");
        }
    }
}