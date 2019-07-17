using System.Web.Mvc;

namespace Emploee.Web.Controllers
{
    public class HomeController : EmploeeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}