using System.Web.Http;
using System.Web.Mvc;

namespace Vino.Server.Api.Controllers
{
    public class HomeController:Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
