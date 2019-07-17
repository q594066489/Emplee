using System.Web.Mvc;

namespace Emploee.Web.Controllers
{
    public class AboutController : EmploeeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}