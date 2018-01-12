using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using DevaxiloS.Services.Commands.Web.Customer;
using DevaxiloS.Services.CustomIdentity;
using DevaxiloS.Services.DomainModels.Customer;
using DevaxiloS.Web.FrontEnd.Common;

namespace DevaxiloS.Web.FrontEnd.Controllers
{
    [Authorize]
    public class ProfileController : BaseWebController
    {
        public ActionResult Index()
        {
            var model = new UserInfoRequest
            {
                FullName = User.GetFullName(),
                Phone = User.GetPhone(),
                Email = User.GetEmail()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveInfo(UserInfoRequest model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            model.UserId = User.GetUserDbId();
            var cmd = new UpdateUserInfoCommand(0, model);
            await CommandBus.Send(cmd);
            var isOk = cmd.Response.ResponseObj;
            if (isOk)
            {
                User.AddUpdateClaim("FullName", model.FullName);
                User.AddUpdateClaim(ClaimTypes.MobilePhone, model.Phone);
            }
            return RedirectToAction("Index");
        }
    }
}