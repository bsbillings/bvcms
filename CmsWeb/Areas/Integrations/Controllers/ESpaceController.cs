using System.Web.Http;
using System.Web.Mvc;

namespace CmsWeb.Areas.Integrations.Controllers
{
    public class ESpaceController : Controller
    {
        // GET: Integrations/ESpace
        public ActionResult Index()
        {
            return View();
        }
    }

    public class ESpaceApiController : ApiController
    {
        public ESpaceApiController()
        {
        }
    }
}
