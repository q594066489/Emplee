using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Emploee.Authorization;
using Emploee.Emploees.Companies.Authorization;
using Emploee.Web.Controllers;

namespace Emploee.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(CompanyAppPermissions.Company)]
    public class DashboardController : EmploeeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}