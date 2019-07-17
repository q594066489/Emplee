using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Emploee.Web.Controllers;

namespace Emploee.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class WelcomeController : EmploeeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}