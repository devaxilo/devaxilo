using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DevaxiloS.Services.Commands.Web.Customer;
using DevaxiloS.Services.CustomIdentity;
using DevaxiloS.Services.DomainModels.Customer;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace DevaxiloS.Web.FrontEnd.Controllers
{
    public class AccountController : BaseWebController
    {
        public UserManager<AspnetIdentityUser> UserManager { get; }
        protected IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public AccountController()
            : this(new UserManager<AspnetIdentityUser>(new UserStore()))
        {
        }

        public AccountController(UserManager<AspnetIdentityUser> userManager)
        {
            UserManager = userManager;
        }

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

        public async Task<ActionResult> SecurityLogin(UserValidationRequest model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Email = model.Email;
                return View("ValidateError");
            }
            /*Dang cho*/
            return null;

        }

        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            Session.Abandon();
            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-30);
            return RedirectToAction("Login", "Account");
        }

        private ActionResult RedirectToDashboard()
        {
            return RedirectToAction("Index", "Dashboard");
        }
    }
}