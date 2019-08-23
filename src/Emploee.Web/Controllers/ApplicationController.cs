using System.Web.Mvc;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.Web.Mvc.Authorization;

namespace Emploee.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ApplicationController : EmploeeControllerBase
    {
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private readonly IAbpSession _IAbpSession;
        public ApplicationController(
            IRepository<UserRole, long> userRoleRepository,
            IAbpSession IAbpSession)
        {
            _userRoleRepository = userRoleRepository;
            _IAbpSession = IAbpSession;
        }
        [DisableAuditing]
        public ActionResult Index()
        {
            var uid = _IAbpSession.UserId ;
            var _roleid = _userRoleRepository.FirstOrDefault(t => t.UserId == uid);
            if (_roleid.RoleId !=5)
            {
                /* Enable next line to redirect to Multi-Page Application */
                return RedirectToAction("Index", "Home", new { area = "Mpa" });
            }

            /* Enable next line to redirect to Multi-Page Application */
            return RedirectToAction("Index", "Home"); 

            //return View("~/App/common/views/layout/layout.cshtml"); //Layout of the angular application.
        }
    }
}