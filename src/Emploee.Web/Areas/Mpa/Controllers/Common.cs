using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Emploee.Web.Areas.Mpa.Models.Common.Modals;
using Emploee.Web.Controllers;

namespace Emploee.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class CommonController : EmploeeControllerBase
    {
        public PartialViewResult LookupModal(LookupModalViewModel model)
        {
            return PartialView("Modals/_LookupModal", model);
        }
    }
}