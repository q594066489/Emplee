using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Emploee.Authorization;
using Emploee.Web.Controllers;

namespace Emploee.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : EmploeeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}