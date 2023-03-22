using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }
    }
}