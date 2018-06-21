using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vino.Server.Web.Areas.Admin.Controllers;
using Vino.Server.Web.Models.Home;

namespace Vino.Server.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        // GET: Home
        public ActionResult Index()
        {
            return Redirect("~/admin/airexps");
        }

    }
}
