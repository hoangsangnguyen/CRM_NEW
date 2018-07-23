using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vino.Server.Services.MainServices.CRM.Topic;
using Vino.Shared.Constants.Common;

namespace Vino.Server.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly TopicService _service;

        public HomeController(TopicService service)
        {
            _service = service;
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            return RedirectToAction("Intro", new { topicType = TopicType.Company});
        }

        public async Task<ActionResult> Intro(string topicType)
        {
            var model = await _service.GetTopicByTopicType(topicType);
            return View(model);
        }
    }
}