using System.Web.Mvc;
using Abp.Auditing;

namespace Emploee.Web.Controllers
{
    public class ErrorController : EmploeeControllerBase
    {
        [DisableAuditing]
        public ActionResult E404()
        {
            return View();
        }
    }
}