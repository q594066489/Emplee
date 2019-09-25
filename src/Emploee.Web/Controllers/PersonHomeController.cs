using System.Web.Mvc;

namespace Emploee.Web.Controllers
{
    public class PersonHomeController : EmploeeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}